using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TedarikciBasvurusu : System.Web.UI.Page
{
    cls_Tedarikci T = new cls_Tedarikci();
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSitesiLbl.Text = Ortak.SiteAdresi;
    }
    private void BeniAra_MailGonder(string _SiteAdi, string _AdSoyad, string _FirmaAdi, string _IsTelefonu, string _CepTlf, string _Eposta, string _WebAdres)
    {
        string Logo = Ortak.SiteAdresi_http + "/Image/logo.jpg";
        MailDefinition mailTarifi = new MailDefinition();
        mailTarifi.BodyFileName = "~/EpostaSablon/EPosta_TedarikciFormu.html"; //Şablon 
        mailTarifi.From = Ortak.Eposta;
        ListDictionary degistirmeListesi = new ListDictionary();
        degistirmeListesi.Add("<%SiteAdi%>", _SiteAdi);
        degistirmeListesi.Add("<%Logo%>", Logo);
        degistirmeListesi.Add("<%AdSoyad%>", _AdSoyad);
        degistirmeListesi.Add("<%FirmaAdi%>", _FirmaAdi);
        degistirmeListesi.Add("<%IsTelefonu%>", _IsTelefonu);
        degistirmeListesi.Add("<%CepTelefonu%>", _CepTlf);
        degistirmeListesi.Add("<%EPosta%>", _Eposta);
        degistirmeListesi.Add("<%WebAdres%>", _WebAdres);
        degistirmeListesi.Add("<%Tarih%>", DateTime.Now.ToString());
        string mailTo = Ortak.EPosta_Gidicek_Adresler[0].ToString();

        MailMessage mailMesaj = mailTarifi.CreateMailMessage(mailTo, degistirmeListesi, this);
        mailMesaj.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mailMesaj.IsBodyHtml = true;
        mailMesaj.Subject = Ortak.SiteAdresiKısa + " | Tedarikçi Başvuru Formu";
        for (int i = 1; i < Ortak.EPosta_Gidicek_Adresler.Length; i++)
        {
            mailMesaj.Bcc.Add(new MailAddress(Ortak.EPosta_Gidicek_Adresler[i].ToString()));
        }
        //buradan sonrasını değiştirmedim, bildiğiniz gibi
        SmtpClient smtp = new SmtpClient(Ortak.MailServer, 587);
        smtp.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        smtp.Send(mailMesaj);
    }
    protected void GonderBtn_Click(object sender, EventArgs e)
    {
        try
        {

            if (T.Tedarikci_Kayit(AdSoyadBox.Text, FirmaAdiBox.Text, IsTlfBox.Text, CepTlfBox.Text, EPostaBox.Text, WebAdresiBox.Text) == true)
            {
                BeniAra_MailGonder(Ortak.SiteAdresi, AdSoyadBox.Text, FirmaAdiBox.Text, IsTlfBox.Text, CepTlfBox.Text, EPostaBox.Text, WebAdresiBox.Text);
                Response.Write("<script>alert('Müşteri hizmetleri yetkilisi en yakın sürede sizinle irtibata geçecektir. İlginiz için teşekkürler.')</script>");

                AdSoyadBox.Text = "";
                FirmaAdiBox.Text = "";
                IsTlfBox.Text = "";
                CepTlfBox.Text = "";
                EPostaBox.Text = "";
                WebAdresiBox.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Hata!! Lütfen bilgileri kontrol ediniz.')</script>");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
    }
}
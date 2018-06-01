using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Iletisim : System.Web.UI.Page
{
    cls_Iletisim Ilet = new cls_Iletisim();
    protected void Page_Load(object sender, EventArgs e)
    {
        FirmaAdiLbl.Text = Ortak.SirketAdi;
        TicaretSicilLbl.Text = Ortak.TicaretSicil;
        AdresLbl.Text = Ortak.Adresi;
        EPostaLbl.Text = Ortak.Eposta;
        TelefonLbl.Text = Ortak.Telefon;
        FaxLbl.Text = Ortak.Fax;
    }
    protected void GonderBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(SiziArayalimAdSoyadBox.Text) && !string.IsNullOrEmpty(SiziArayalimCepTlfBox.Text))
            {
                if (Ilet.Ara_Beni_Kayit(SiziArayalimAdSoyadBox.Text, SiziArayalimCepTlfBox.Text) == true)
                {
                    BeniAra_MailGonder(Ortak.SiteAdresi, SiziArayalimAdSoyadBox.Text, SiziArayalimCepTlfBox.Text, DateTime.Now.ToString());
                    Response.Write("<script>alert('Müşteri hizmetleri yetkilisi en yakın sürede sizinle irtibata geçecektir. İlginiz için teşekkürler.')</script>");

                    SiziArayalimAdSoyadBox.Text = "";
                    SiziArayalimCepTlfBox.Text = "";

                }
                else
                {
                    Response.Write("<script>alert('Hata!! Lütfen bilgileri kontrol ediniz.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Tüm alanları doldurunuz.')</script>");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
    }
    protected void IletisimGonderBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(IletisimAdSoyadBox.Text) && !string.IsNullOrEmpty(IletisimEPostaBox.Text) && !string.IsNullOrEmpty(IletisimCepBox.Text) && !string.IsNullOrEmpty(IletisimKonuBox.Text) && !string.IsNullOrEmpty(IletisimAciklamaBox.Text))
            {
                if (Ilet.Iletisim_Kayit(IletisimAdSoyadBox.Text, IletisimEPostaBox.Text, IletisimCepBox.Text, IletisimKonuBox.Text, IletisimAciklamaBox.Text) == true)
                {
                    Iletisim_MailGonder(Ortak.SiteAdresi, IletisimAdSoyadBox.Text, IletisimEPostaBox.Text, IletisimCepBox.Text, IletisimKonuBox.Text, IletisimAciklamaBox.Text, DateTime.Now.ToString());

                    Response.Write("<script>alert('Müşteri hizmetleri yetkilisi en yakın sürede sizinle irtibata geçecektir. İlginiz için teşekkürler.')</script>");
                    IletisimAdSoyadBox.Text = "";
                    IletisimEPostaBox.Text = "";
                    IletisimCepBox.Text = "";
                    IletisimKonuBox.Text = "";
                    IletisimAciklamaBox.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Hata!! Lütfen bilgileri kontrol ediniz.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Tüm alanları doldurunuz.')</script>");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
    }
    private void BeniAra_MailGonder(string _SiteAdi, string _AdSoyad, string _CepTel, string _Tarih)
    {
        string Logo = Ortak.SiteAdresi_http + "/Image/logo.jpg";
        MailDefinition mailTarifi = new MailDefinition();
        mailTarifi.BodyFileName = "~/EpostaSablon/EPosta_BeniAraTalepFormu.html"; //Şablon 
        mailTarifi.From = Ortak.Eposta;
        ListDictionary degistirmeListesi = new ListDictionary();
        degistirmeListesi.Add("<%SiteAdi%>", _SiteAdi);
        degistirmeListesi.Add("<%Logo%>", Logo);
        degistirmeListesi.Add("<%AdSoyad%>", _AdSoyad);
        degistirmeListesi.Add("<%CepTelefonu%>", _CepTel);
        degistirmeListesi.Add("<%Tarih%>", _Tarih);
        string mailTo = Ortak.EPosta_Gidicek_Adresler[0].ToString();

        MailMessage mailMesaj = mailTarifi.CreateMailMessage(mailTo, degistirmeListesi, this);
        mailMesaj.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mailMesaj.IsBodyHtml = true;
        mailMesaj.Subject = Ortak.SiteAdresiKısa + " | Beni Ara Talep Formu";
        for (int i = 1; i < Ortak.EPosta_Gidicek_Adresler.Length; i++)
        {
            mailMesaj.Bcc.Add(new MailAddress(Ortak.EPosta_Gidicek_Adresler[i].ToString()));
        }
        //buradan sonrasını değiştirmedim, bildiğiniz gibi
        SmtpClient smtp = new SmtpClient(Ortak.MailServer, 587);
        smtp.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        smtp.Send(mailMesaj);
    }
    private void Iletisim_MailGonder(string _SiteAdi, string _AdSoyad, string _EPosta, string _CepTel, string _Konu, string _Aciklama, string _Tarih)
    {
        string Logo = Ortak.SiteAdresi_http + "/Image/logo.jpg";
        MailDefinition mailTarifi = new MailDefinition();
        mailTarifi.BodyFileName = "~/EpostaSablon/EPosta_IletisimFormu.html"; //Şablon 
        mailTarifi.From = Ortak.Eposta;
        ListDictionary degistirmeListesi = new ListDictionary();
        degistirmeListesi.Add("<%SiteAdi%>", _SiteAdi);
        degistirmeListesi.Add("<%Logo%>", Logo);
        degistirmeListesi.Add("<%AdSoyad%>", _AdSoyad);
        degistirmeListesi.Add("<%EPosta%>", _EPosta);
        degistirmeListesi.Add("<%CepTelefonu%>", _CepTel);
        degistirmeListesi.Add("<%Konu%>", _Konu);
        degistirmeListesi.Add("<%Aciklama%>", _Aciklama);
        degistirmeListesi.Add("<%Tarih%>", _Tarih);
        string mailTo = Ortak.EPosta_Gidicek_Adresler[0].ToString();

        MailMessage mailMesaj = mailTarifi.CreateMailMessage(mailTo, degistirmeListesi, this);
        mailMesaj.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mailMesaj.IsBodyHtml = true;
        mailMesaj.Subject = Ortak.SiteAdresiKısa + " | İletişim Formu";
        for (int i = 1; i < Ortak.EPosta_Gidicek_Adresler.Length; i++)
        {
            mailMesaj.Bcc.Add(new MailAddress(Ortak.EPosta_Gidicek_Adresler[i].ToString()));
        }
        //buradan sonrasını değiştirmedim, bildiğiniz gibi
        SmtpClient smtp = new SmtpClient(Ortak.MailServer, 587);
        smtp.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        smtp.Send(mailMesaj);
    }
}
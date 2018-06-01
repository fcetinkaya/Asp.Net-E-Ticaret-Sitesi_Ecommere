using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class Admin_Default : System.Web.UI.Page
{
    private static string sifre;
    cls_Admin_Default A = new cls_Admin_Default();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string k = "info@gelisimsoft.com";
        //string s = "demo";
        //string ks = string.Format("{0}/--//--/{1}",Ortak.Encrypt(k),Ortak.Encrypt(s));
        //Response.Write(ks);
    }
    protected void GirisBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Sifrebox.Attributes.Add("value", Sifrebox.Text);
            sifre = Sifrebox.Text;
            if (A.PasvirdGel(EpostaBox.Text, sifre) == true)
            {
                Session.Add("eticaret", "gelisimSoft");
                Response.Redirect("Yonetim.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Kullanıcı adı veya şifre hatalı !!');</script>");
            }
        }
        catch (Exception)
        {
            Response.Write("<script language='javascript'>window.alert('Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.');</script>");
        }
    }
    public static void MailGonder(string HangiMail, string Mailinkonusu, string mailinicerigi)
    {
        SmtpClient hancimail = new SmtpClient(Ortak.MailServer, 587);
        MailMessage mesacum = new MailMessage();
        mesacum.From = new MailAddress(Ortak.Eposta, "E-Ticaret | Şifre Hatırlatma ");// Buraya Dikkkat
        mesacum.To.Add(new MailAddress(HangiMail.ToString()));
        mesacum.Subject = Mailinkonusu;
        mesacum.Body = mailinicerigi;
        hancimail.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        try
        {
            hancimail.Send(mesacum);
        }
        catch (Exception)
        {

        }
    }
    private void EpostaHatirlat() // Değişecek E-Posta Gönderim Bilgisi
    {
        try
        {
            if (!string.IsNullOrEmpty(A.EPosta_Hatirlat_Getir(EpostaHatirlatBox.Text)))
            {
                string EpostsAdres = EpostaHatirlatBox.Text;
                string sifre = A.EPosta_Hatirlat_Getir(EpostaHatirlatBox.Text);
                sifre = Ortak.Decrypt(sifre);
                string mesaj = "Sayın Yetkili, \n Kayıtlı üyelik bilgileriniz aşağıdaki gibidir.\n\nKullanıcı Adınız :" + EpostsAdres + "\n Şifre :" + sifre + "\n\n*Bu yalnızca gönderim amaçlı bir e-posta adresidir. Bu iletiyi yanıtladığınızda, yanıtınız izlenmez veya cevaplanmaz.";
                MailGonder(EpostsAdres, "Şifre Hatırlatma | E-Ticaret Giriş Bilgileri", mesaj);
                Response.Write("<script language='javascript'>window.alert('Şifre E-Posta adresinize gönderilmiştir.');</script>");
                EpostaHatirlatBox.Text = "";
                SifreDiv.Visible = false;
                GirisEkraniDiv.Visible = true;
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('E-posta adresi bulanamadı ya da hatalı.');</script>");
                EpostaHatirlatBox.Text = "";
            }
        }
        catch (Exception)
        {
            Response.Write("<script language='javascript'>window.alert('Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.');</script>");
        }
    }
    protected void SifremiUnuttumBtn_Click(object sender, EventArgs e)
    {
        SifreDiv.Visible = true;
        GirisEkraniDiv.Visible = false;
    }
    protected void SifreGonderBtn_Click(object sender, EventArgs e)
    {
        EpostaHatirlat();
    }
    protected void VazgecBtn_Click(object sender, EventArgs e)
    {
        SifreDiv.Visible = false;
        GirisEkraniDiv.Visible = true;
    }
}
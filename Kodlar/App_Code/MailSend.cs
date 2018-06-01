using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

/// <summary>
/// Summary description for MailSend
/// </summary>
public class MailSend : IDisposable
{
    public static void MailGonder(string hangimailegidicek, string Mailinkonusu, string mailinicerigi)
    {
        SmtpClient hancimail = new SmtpClient(Ortak.MailServer, 587);
        MailMessage mesacum = new MailMessage();
        mesacum.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mesacum.To.Add(new MailAddress(hangimailegidicek));
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
    public static void SifreYenileMail(string hangimailegidicek, string Mailinkonusu, string mailinicerigi)
    {
        SmtpClient hancimail = new SmtpClient(Ortak.MailServer, 587);
        MailMessage mesacum = new MailMessage();
        mesacum.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mesacum.To.Add(new MailAddress(hangimailegidicek));
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
    public static void Bildirim_MailGonder(string Mailinkonusu, string mailinicerigi)
    {
        SmtpClient hancimail = new SmtpClient(Ortak.MailServer, 587);
        MailMessage mesacum = new MailMessage();
        mesacum.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        for (int i = 0; i < Ortak.EPosta_Gidicek_Adresler.Length; i++)
        {
            mesacum.To.Add(new MailAddress(Ortak.EPosta_Gidicek_Adresler[i].ToString()));
        }
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
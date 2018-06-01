using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_KargoIslemleri : System.Web.UI.Page
{
    public static string Gelen_Aydi, Aranacak, Gidecek_Eposta;
    cls_Admin_KargoIslemleri K = new cls_Admin_KargoIslemleri();
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select Log_Index,EPostaBox from E_Personel where IsActive=1 and Log_Index like '%" + prefixText + "%'", conn))
            {
                //  cmd.Parameters.AddWithValue("@SearchText", prefixText);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string Gidicek = Ortak.Decrypt(sdr["EPostaBox"].ToString());
                        string Birlestir = sdr["Log_Index"].ToString() + "-" + Gidicek;
                        customers.Add(Birlestir);
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers_siparisNo(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select SiparisNoFiyat from E_SiparisTakip where IsActive=1 and IslemTamam=0 and SiparisNo like '%" + prefixText + "%'", conn))
            {
                //  cmd.Parameters.AddWithValue("@SearchText", prefixText);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["SiparisNoFiyat"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "Kurye İşlemleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Kurye İşlemleri";
                    Gel_Bildirimler_Hepsi();
                    if (Request.QueryString["SiparisNoFiyat"] != null)
                    {
                        SiparisNoBox.Text = K.Siparis_No_Gonder(Request.QueryString["SiparisNoFiyat"].ToString());
                        MusteriAdiBox.Text = K.Musteri_AdSoyad_Gonder(Request.QueryString["AdSoyad"].ToString());
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    public void Gel_Bildirimler_Hepsi()
    {
        DataTable dt = K.Kargo_Bilgileri();
        if (dt.Rows.Count != 0)
        {
            KargoListesi_Grid.DataSource = dt;
            KargoListesi_Grid.DataBind();
            GridKayitYokDiv.Visible = false;
        }
        else
        {
            GridKayitYokDiv.Visible = true;
            KargoListesi_Grid.DataBind();
        }
    }
    private void Gel_Bildirimler_Arama()
    {
        DataTable dt = K.Kargo_Bilgileri_Arama_Kriter(Aranacak);
        if (dt.Rows.Count != 0)
        {
            KargoListesi_Grid.DataSource = dt;
            KargoListesi_Grid.DataBind();
            GridKayitYokDiv.Visible = false;
        }
        else
        {
            GridKayitYokDiv.Visible = true;
            KargoListesi_Grid.DataBind();
        }
    }
    protected void KargoEkleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string[] dizi = MusteriAdiBox.Text.Split('-');
            string Siparis_ID = K.Siparis_ID_Gonder(SiparisNoBox.Text);
            string Gun_Musteri = K.Musteri_bilgi_Gonder(dizi[0]);
            Gidecek_Eposta = dizi[1];
            string link = Ortak.SiteAdresi_http + "/SiparisKargoTakibi.aspx";
            if (K.Kayit(KargoDrop.SelectedItem.Text, TakipNoBox.Text.Trim(), Siparis_ID, Gun_Musteri) == true)
            {
                Kargo_MailGonder(Ortak.SiteAdresi, dizi[0], SiparisNoBox.Text, TakipNoBox.Text, KargoDrop.SelectedItem.Text, link, Gidecek_Eposta);
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = TakipNoBox.Text + " takip no başarı ile kayıt edildi.";
                HataVar.Visible = false;
                TakipNoBox.Text = "";
                MusteriAdiBox.Text = "";
                TakipNoBox.Text = "";
                Gel_Bildirimler_Hepsi();
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void KargoListesi_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        KargoListesi_Grid.PageIndex = e.NewPageIndex;
        if (!string.IsNullOrEmpty(Aranacak))
        {
            Gel_Bildirimler_Arama();
        }
        else
        {
            Gel_Bildirimler_Hepsi();
        }
        //  Gel_Urunler();
        KargoListesi_Grid.DataBind();
    }
    protected void KargoListesi_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sil")
            {
                if (K.Sil(e.CommandArgument.ToString()) == true)
                {
                    if (!string.IsNullOrEmpty(Aranacak))
                    {
                        Gel_Bildirimler_Arama();
                    }
                    else
                    {
                        Gel_Bildirimler_Hepsi();
                    }
                    Ortak.MesajGoster("Kargo Takip No Silindi.");
                }
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void KargoListesi_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Adi_soyadi = e.Row.FindControl("AdSoyadLbl") as Label;
            Label TakipNo = e.Row.FindControl("TakipNoLbl") as Label;
            Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            TakipNo.Text = Ortak.Decrypt(TakipNo.Text);
        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Aranacak = "";
            if (Ara_KargoDrop.SelectedIndex != 0)
            {
                Aranacak = " and E_KargoTakibi.KargoFirmasi='" + Ara_KargoDrop.SelectedItem.Text + "'";
                Gel_Bildirimler_Arama();
            }
            if (!string.IsNullOrEmpty(Ara_TakipNoBox.Text))
            {
                Aranacak += " and E_KargoTakibi.TakipNo='" + Ortak.Encrypt(Ara_TakipNoBox.Text) + "'";
                Gel_Bildirimler_Arama();
            }
            if (!string.IsNullOrEmpty(Ara_MusteriAdiBox.Text))
            {
                Aranacak += " and E_Personel.AdSoyad='" + Ortak.Encrypt(Ara_MusteriAdiBox.Text) + "'";
                Gel_Bildirimler_Arama();
            }
            if (!string.IsNullOrEmpty(Ara_SiparisNoBox.Text))
            {
                Aranacak += " and E_SiparisTakip.SiparisNoFiyat='" + Ara_SiparisNoBox.Text + "'";
                Gel_Bildirimler_Arama();
            }
            else
            {
                Gel_Bildirimler_Arama();
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void KaydetBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string Gun_Siparis_ID = K.Siparis_ID_Gonder(Guncelle_SiparisNoBox.Text);
            string Gun_Musteri = K.Musteri_bilgi_Gonder(Guncelle_MusteriAdBox.Text);
            if (K.Guncelle(Guncelle_KargoFirmasi.SelectedItem.Text, Guncelle_TakipNoBox.Text.Trim(), Gun_Siparis_ID, Gun_Musteri, Gelen_Aydi) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = Guncelle_TakipNoBox.Text + " takip no başarı ile güncellendi";
                HataVar.Visible = false;
                TakipNoBox.Text = "";
                Gel_Bildirimler_Hepsi();
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void DuzenleBtn_Click(object sender, EventArgs e)
    {
        ImageButton G = sender as ImageButton;
        Gelen_Aydi = G.CommandArgument.ToString();
        string[] Gel = K.Guncelleme_Icin_Bilgiler(Gelen_Aydi);
        Guncelle_KargoFirmasi.Text = Gel[0].ToString();
        Guncelle_TakipNoBox.Text = Ortak.Decrypt(Gel[1].ToString());
        Guncelle_SiparisNoBox.Text = Gel[2].ToString();
        Guncelle_MusteriAdBox.Text = Ortak.Decrypt(Gel[3].ToString());
        mpe.Show();
    }
    private void Kargo_MailGonder(string _SiteAdi, string _AdSoyad, string _SiparisNo, string _TakipNo, string _KargoFirmasi, string _link, string _Eposta_Musteri)
    {
        string Logo = Ortak.SiteAdresi_http + "/Image/logo.jpg";
        MailDefinition mailTarifi = new MailDefinition();
        mailTarifi.BodyFileName = "~/EpostaSablon/EPosta_KargoTeslimati.html"; //Şablon 
        mailTarifi.From = Ortak.Eposta;
        ListDictionary degistirmeListesi = new ListDictionary();
        degistirmeListesi.Add("<%SiteAdi%>", _SiteAdi);
        degistirmeListesi.Add("<%Logo%>", Logo);
        degistirmeListesi.Add("<%AdSoyad%>", _AdSoyad);
        degistirmeListesi.Add("<%SiparisNo%>", _SiparisNo);
        degistirmeListesi.Add("<%KargoTakipNo%>", _TakipNo);
        degistirmeListesi.Add("<%KargoFirmasi%>", _KargoFirmasi);
        degistirmeListesi.Add("<%KargoTakipLinki%>", _link);
        string mailTo = Ortak.EPosta_Gidicek_Adresler[0].ToString();
        MailMessage mailMesaj = mailTarifi.CreateMailMessage(mailTo, degistirmeListesi, this);
        mailMesaj.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mailMesaj.IsBodyHtml = true;
        mailMesaj.Subject = Ortak.SiteAdresiKısa + " | Kargo Gönderim Bildirimi";
        for (int i = 1; i < Ortak.EPosta_Gidicek_Adresler.Length; i++)
        {
            mailMesaj.Bcc.Add(new MailAddress(Ortak.EPosta_Gidicek_Adresler[i].ToString()));
        }
        mailMesaj.Bcc.Add(new MailAddress(_Eposta_Musteri));
        //buradan sonrasını değiştirmedim, bildiğiniz gibi
        SmtpClient smtp = new SmtpClient(Ortak.MailServer, 587);
        smtp.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        smtp.Send(mailMesaj);
    }
}
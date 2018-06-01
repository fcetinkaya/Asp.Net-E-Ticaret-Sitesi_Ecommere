using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_UrunDuzenlemeOnay : System.Web.UI.Page
{
    public static string Gelen_Urun_ID,GelenTelefonID;
    cls_Admin_UrunDuzenleme UD = new cls_Admin_UrunDuzenleme();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["OID"] != null)
                    {
                        Gelen_Urun_ID = Request.QueryString["OID"].ToString();
                        Gelen_Urun_ID = Ortak.Decrypt(Gelen_Urun_ID);
                        IndirimOraniDoldur();
                        Kategori_GelListe();
                        Telefon_GelListe();
                        Urun_Bilgileri_Getir(Gelen_Urun_ID);
                        TelefonModel_GelListe(telefonDrop.SelectedValue);
                        dropTelefonModel.SelectedValue = GelenTelefonID;
                        Label label = Master.FindControl("UrlMaplbl") as Label;
                        label.Text = "Ürün Güncelleme";
                        Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                        label2.Text = "Ürün Güncelleme İşlemleri";
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
            //    HataVar.Visible = true;
        }
    }
    private void XmlYaz(string _Link)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("../Googlesitemap.xml"));
        DataRow dr = ds.Tables[0].NewRow();
        dr[0] = _Link;
        dr[1] = "daily";
        dr[2] = "0.90";
        ds.Tables[0].Rows.Add(dr);
        ds.AcceptChanges();
        ds.WriteXml(Server.MapPath("../Googlesitemap.xml"));
    }
    public void Ping_Gonder_AramaMotorlari()
    {
        string Adres = Ortak.SiteAdresi_http + "/Googlesitemap.xml";
        // resubmit to google
        System.Net.WebRequest reqGoogle = System.Net.WebRequest.Create("http://www.google.com/webmasters/tools/ping?sitemap=" + HttpUtility.UrlEncode(Adres));
        reqGoogle.GetResponse();

        // resubmit to bing
        System.Net.WebRequest reqBing = System.Net.WebRequest.Create("http://www.bing.com/webmaster/ping.aspx?siteMap=" + HttpUtility.UrlEncode(Adres));
        reqBing.GetResponse();

        //Ping Yandex
        System.Net.WebRequest reqYandex = System.Net.WebRequest.Create("http://blogs.yandex.ru/pings/?status=success&url=" + HttpUtility.UrlEncode(Ortak.SiteAdresi_http));
        reqYandex.GetResponse();

    }
    public void Urun_Bilgileri_Getir(string _Urun_Aydim)
    {
        string[] Gele_Teslimat = UD.Urun_Guncelleme_Turn_Details(_Urun_Aydim);
        UrunAdiBox.Text = Gele_Teslimat[0].ToString();
        ResimOnIzlemeLink.Attributes.Add("rel", "../Urunler/Logo/" + Gele_Teslimat[1].ToString());
        Fiyatbox.Text = Gele_Teslimat[2].ToString();
        IndirimOraniDrop.SelectedValue = Gele_Teslimat[3].ToString();
        AciklamaBox.Text = Gele_Teslimat[4].ToString();
        KategoriDrop.SelectedValue = Gele_Teslimat[5].ToString();
        telefonDrop.SelectedValue = Gele_Teslimat[6].ToString();
        GelenTelefonID = Gele_Teslimat[7].ToString();
    }
    public string KarekterDegistir(string HaberAdi)
    {
        //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
        string Temp = HaberAdi.ToLower();
        Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "-");
        Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
        Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
        Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
        Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
        Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
        Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
        Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
        Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
        Temp = Temp.Replace("?", ""); Temp = Temp.Replace(".", "_");
        Temp = Temp.Replace("ı", "i");
        return Temp;
    }
    public void Kategori_GelListe()
    {

        DataTable dt = UD.Alt_Kategori_AllList();
        if (dt.Rows.Count != 0)
        {
            DataRow dr = dt.NewRow();
            dr["KategoriAdi"] = "Lütfen Kategori Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            KategoriDrop.DataSource = dt;
            KategoriDrop.DataTextField = "KategoriAdi";
            KategoriDrop.DataValueField = "KategoriID";
            KategoriDrop.DataBind();
        }
    }
    public void Telefon_GelListe()
    {

        DataTable dt = UD.Telefon_AllList();
        if (dt.Rows.Count != 0)
        {
            DataRow dr = dt.NewRow();
            dr["TelAdi"] = "Lütfen Telefon Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            telefonDrop.DataSource = dt;
            telefonDrop.DataTextField = "TelAdi";
            telefonDrop.DataValueField = "TelefonID";
            telefonDrop.DataBind();
        }
    }
    public void TelefonModel_GelListe(string _GeliyorAydi)
    {
        DataTable dt = UD.TelefonModel_AllList(_GeliyorAydi);
        if (dt.Rows.Count != 0)
        {
            dropTelefonModel.Enabled = true;
            DataRow dr = dt.NewRow();
            dr["ModelAdi"] = "Lütfen Telefon Modelini Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            dropTelefonModel.DataSource = dt;
            dropTelefonModel.DataTextField = "ModelAdi";
            dropTelefonModel.DataValueField = "TelefonModelID";
            dropTelefonModel.DataBind();
        }
    }
    public void IndirimOraniDoldur()
    {
        IndirimOraniDrop.Items.Insert(0, new ListItem("İndirim Oranını Seçiniz.", "0"));
        for (int i = 1; i <= 100; i++)
        {
            IndirimOraniDrop.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
        }
    }
    public static void yukle(FileUpload fu, int Ksize, string Kaydedilecek_DosyaAdi)
    {
        System.Drawing.Image orjinalFoto = null;
        HttpPostedFile jpeg_image_upload = fu.PostedFile;
        orjinalFoto = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);
        KucukBoyut(orjinalFoto, Ksize, Kaydedilecek_DosyaAdi);
    }
    protected static void KucukBoyut(System.Drawing.Image orjinalFoto, int boyut, string dosyaAdi)
    {
        System.Drawing.Bitmap islenmisFotograf = null;
        System.Drawing.Graphics grafik = null;

        int hedefGenislik = boyut;
        int hedefYukseklik = boyut;
        int new_width, new_height;

        new_height = (int)Math.Round(((float)orjinalFoto.Height * (float)boyut) / (float)orjinalFoto.Width);
        new_width = hedefGenislik;
        hedefYukseklik = new_height;
        new_width = new_width > hedefGenislik ? hedefGenislik : new_width;
        new_height = new_height > hedefYukseklik ? hedefYukseklik : new_height;
        if (new_height > 210)
        {
            hedefYukseklik = 210;
        }
        islenmisFotograf = new System.Drawing.Bitmap(hedefGenislik, hedefYukseklik);
        grafik = System.Drawing.Graphics.FromImage(islenmisFotograf);
        grafik.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, hedefGenislik, hedefYukseklik));
        int paste_x = (hedefGenislik - new_width) / 2;
        int paste_y = (hedefYukseklik - new_height) / 2;

        grafik.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        grafik.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        grafik.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

        System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
        System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
        eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L);

        grafik.DrawImage(orjinalFoto, paste_x, paste_y, new_width, new_height);
        islenmisFotograf.Save(HttpContext.Current.Server.MapPath("../Urunler/Logo/" + dosyaAdi), codec, eParams);
    }
    public string KarekterDegistir_ResimAdi(string _ResimAdi)
    {
        //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
        string Temp = _ResimAdi.ToLower();
        Temp = Temp.Replace(" ", "-");
        Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
        Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
        Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
        Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
        Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
        Temp = Temp.Replace("ı", "i");
        return Temp;
    }
    public void Urun_Guncelleme_With_Image()
    {
        string Link = "1294" + Gelen_Urun_ID + "7454-" + KarekterDegistir(telefonDrop.SelectedItem.Text) + "-" + KarekterDegistir(dropTelefonModel.SelectedItem.Text) + "-" + KarekterDegistir(KategoriDrop.SelectedItem.Text) + "-cep-telefonu-aksesuarlari-" + KarekterDegistir(UrunAdiBox.Text) + ".aspx";
        decimal Eski_Fiyat = Convert.ToDecimal(Fiyatbox.Text);
        decimal Yeni_Fiyat = Eski_Fiyat;
        bool Indirim = false;
        if (IndirimOraniDrop.SelectedIndex != 0)
        {
            decimal Oran = Convert.ToDecimal(IndirimOraniDrop.SelectedValue);
            decimal Yeni_Fiyat_Indirim = Eski_Fiyat / 100 * Oran;
            Yeni_Fiyat = Yeni_Fiyat - Yeni_Fiyat_Indirim;
            Indirim = true;
        }
        string strFileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
        if (strFileExt.ToUpper() == ".JPG" || strFileExt.ToUpper() == ".GIF" || strFileExt.ToUpper() == ".PNG")
        {
            string KaydedilecekLogo = Guid.NewGuid().ToString().Remove(6) + "-" + FileUpload1.FileName;
            KaydedilecekLogo = KarekterDegistir_ResimAdi(KaydedilecekLogo);
            yukle(FileUpload1, 210, KaydedilecekLogo);
            if (UD.Urun_Guncelleme_With_Image(UrunAdiBox.Text, KaydedilecekLogo, Eski_Fiyat, Yeni_Fiyat, Convert.ToInt32(IndirimOraniDrop.SelectedValue), Indirim, AciklamaBox.Text, KategoriDrop.SelectedItem.Text, KategoriDrop.SelectedValue, telefonDrop.SelectedItem.Text, telefonDrop.SelectedValue, dropTelefonModel.SelectedItem.Text, dropTelefonModel.SelectedValue, Link, Gelen_Urun_ID) == true)
            {
                string Adres = Ortak.SiteAdresi_http + "/" + Link;
                XmlYaz(Adres);
                Ping_Gonder_AramaMotorlari();
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = UrunAdiBox.Text + " Ürün başarı ile güncellenmiştir. Lütfen fiyatları (Eski, Yeni ve Havale fiyatını  kontrol ediniz.)";
                UrunKontrolLink.Text = "Ürünü İncelemek İçin Tıklayınız.";
                string Urun_Link = Ortak.SiteAdresi_http + "/" + Link;
                UrunKontrolLink.NavigateUrl = Urun_Link;
                HataVar.Visible = false;
                UrunGuncellemeDiv.Visible = false;
            }
            else
            {
                KayitTamam.Visible = false;
                HataLbl.Text = "Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.";
                HataVar.Visible = true;
            }
        }
        else
        {
            KayitTamam.Visible = false;
            HataLbl.Text = "Uygun formatda  (.jpg, .gif ve .png) resim yükleyiniz.";
            HataVar.Visible = true;
        }
    }
    public void Urun_Guncelleme_Without_Image()
    {
        string Link = "1294" + Gelen_Urun_ID + "7454-" + KarekterDegistir(telefonDrop.SelectedItem.Text) + "-" + KarekterDegistir(dropTelefonModel.SelectedItem.Text) + "-" + KarekterDegistir(KategoriDrop.SelectedItem.Text) + "-cep-telefonu-aksesuarlari-" + KarekterDegistir(UrunAdiBox.Text) + ".aspx";
        decimal Eski_Fiyat = Convert.ToDecimal(Fiyatbox.Text);
        decimal Yeni_Fiyat = Eski_Fiyat;
        bool Indirim = false;
        if (IndirimOraniDrop.SelectedIndex != 0)
        {
            decimal Oran = Convert.ToDecimal(IndirimOraniDrop.SelectedValue);
            decimal Yeni_Fiyat_Indirim = Eski_Fiyat / 100 * Oran;
            Yeni_Fiyat = Yeni_Fiyat - Yeni_Fiyat_Indirim;
            Indirim = true;
        }
        if (UD.Urun_Guncelleme(UrunAdiBox.Text, Eski_Fiyat, Yeni_Fiyat, Convert.ToInt32(IndirimOraniDrop.SelectedValue), Indirim, AciklamaBox.Text, KategoriDrop.SelectedItem.Text, KategoriDrop.SelectedValue, telefonDrop.SelectedItem.Text, telefonDrop.SelectedValue, dropTelefonModel.SelectedItem.Text, dropTelefonModel.SelectedValue, Link, Gelen_Urun_ID) == true)
        {
            string Adres = Ortak.SiteAdresi_http + "/" + Link;
            XmlYaz(Adres);
            Ping_Gonder_AramaMotorlari();
            KayitTamam.Visible = true;
            KayitTamamLbl.Text = UrunAdiBox.Text + " Ürün başarı ile güncellenmiştir. Lütfen fiyatları (Eski, Yeni ve Havale fiyatını  kontrol ediniz.)";
            UrunKontrolLink.Text = "Ürünü İncelemek İçin Tıklayınız.";
            UrunKontrolLink.NavigateUrl = Ortak.SiteAdresi_http + "/" + Link;
            HataVar.Visible = false;
            UrunGuncellemeDiv.Visible = false;
        }
        else
        {
            KayitTamam.Visible = false;
            HataLbl.Text = "Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.";
            HataVar.Visible = true;
        }
    }
    protected void btnUrunKayit_Click(object sender, EventArgs e)
    {
        btnUrunKayit.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnUrunKayit, "").ToString());
        try
        {
            if (FileUpload1.HasFile)
            {
                Urun_Guncelleme_With_Image();
            }
            else
            {
                Urun_Guncelleme_Without_Image();
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataLbl.Text = "Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.";
            HataVar.Visible = true;
        }
    }
    protected void telefonDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (telefonDrop.SelectedIndex != 0)
        {
            dropTelefonModel.Items.Clear();
            TelefonModel_GelListe(telefonDrop.SelectedValue);
        }
        else
        {
            Ortak.MesajGoster("Telefonu seçiniz.");
        }
    }
}
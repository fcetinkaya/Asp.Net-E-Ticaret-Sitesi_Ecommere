using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class Rumrum_UrunEkleme : System.Web.UI.Page
{
    cls_Admin_Urunler U = new cls_Admin_Urunler();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "Ürün Ekleme";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Ürün Ekleme İşlemleri";
                    IndirimOraniDoldur();
                    Kategori_GelListe();
                    Telefon_GelListe();
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
    public void Kategori_GelListe()
    {

        DataTable dt = U.Alt_Kategori_AllList();
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

        DataTable dt = U.Telefon_AllList();
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
        DataTable dt = U.TelefonModel_AllList(_GeliyorAydi);
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
    protected void btnUrunKayit_Click(object sender, EventArgs e)
    {
        btnUrunKayit.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnUrunKayit, "").ToString());
        try
        {
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
                int GeliyorAyid = U.Urun_Ekleme(UrunAdiBox.Text, KaydedilecekLogo, Eski_Fiyat, Yeni_Fiyat, Convert.ToInt32(IndirimOraniDrop.SelectedValue), Indirim, AciklamaBox.Text, KategoriDrop.SelectedItem.Text, KategoriDrop.SelectedValue, telefonDrop.SelectedItem.Text, telefonDrop.SelectedValue, dropTelefonModel.SelectedItem.Text, dropTelefonModel.SelectedValue);
                if (GeliyorAyid > 0)
                {
                    string Link = "1294" + GeliyorAyid.ToString() + "7454-" + KarekterDegistir(telefonDrop.SelectedItem.Text) + "-" + KarekterDegistir(dropTelefonModel.SelectedItem.Text) + "-" + KarekterDegistir(KategoriDrop.SelectedItem.Text) + "-cep-telefonu-aksesuarlari-" + KarekterDegistir(UrunAdiBox.Text) + ".aspx";
                    if (U.UrunLink_Update(GeliyorAyid.ToString(), Link) == true)
                    {
                        string Adres = Ortak.SiteAdresi_http + "/" + Link;
                        XmlYaz(Adres);

                        Ping_Gonder_AramaMotorlari();

                        KayitTamam.Visible = true;
                        KayitTamamLbl.Text = UrunAdiBox.Text + " Ürün başarı ile eklenmiştir. Lütfen fiyatları (Eski, Yeni ve Havale fiyatını  kontrol ediniz.)";
                        UrunKontrolLink.Text = "Ürünü İncelemek İçin Tıklayınız.";
                        string Urun_Link = Ortak.SiteAdresi_http + "/" + Link;
                        UrunKontrolLink.NavigateUrl = Urun_Link;
                        Twetter.Attributes.Add("data-url", Urun_Link);
                        Facebook2.Attributes.Add("share_url", Urun_Link);
                        GooglePlus.Attributes.Add("data-href", Urun_Link);
                        string Urun_Image = Ortak.SiteAdresi_http + "/Urunler/Logo/" + KaydedilecekLogo;
                        Pinterest.HRef = "http://tr.pinterest.com/pin/create/button/?url=" + Urun_Link + "&media=" + Urun_Image + "&description=" + Urun_Link;
                        HataVar.Visible = false;
                        UrunEklemeDiv.Visible = false;
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
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataLbl.Text = "Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.";
            HataVar.Visible = true;
        }
    }
}
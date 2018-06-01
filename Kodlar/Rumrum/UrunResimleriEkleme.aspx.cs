using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_UrunResimleriEkleme : System.Web.UI.Page
{
    cls_Admin_ResimEkleme RE = new cls_Admin_ResimEkleme();
    public static int GelID;
    public static string UrunListesi_ID, Link;
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select UrunAdi from E_Urunler where IsActive=1 and UrunAdi like '%" + prefixText + "%'", conn))
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
                        customers.Add(sdr["UrunAdi"].ToString());
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
                    label.Text = "Resim Ekleme";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Ürün Resimleri Ekleme";
                    if (Request.QueryString["ID"] != null)
                    {
                        UrunListesi_ID = Ortak.Decrypt(Request.QueryString["ID"].ToString());
                        string[] Gel = RE.UrunDetay_UrunAdi_Dondur(UrunListesi_ID);
                        UrunAdiBox.Text = Gel[0].ToString();
                        Link = Gel[1].ToString();
                        Resimler_Gel(UrunListesi_ID);
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
            HataVar.Visible = true;
        }
    }
    private void Resimler_Gel(string _GelID)
    {
        DataTable dt = RE.UrunDetay_ResimGetir(_GelID);
        if (dt.Rows.Count != 0)
        {
            if (dt.Rows.Count == 8)
            {
                //Resim Yükleme İşlemleri
                ResimYukleme_field.Visible = false;
                ResimleriYukleBtn.Visible = false;
                ResimUploadYok.Visible = true;
                // Kayıtlı resimler
                YukluResimler.Visible = true;
                ResimlerYok.Visible = false;
                ResimleriSilBtn.Visible = true;
                ResimlerRepeater.DataSource = dt;
                ResimlerRepeater.DataBind();
            }
            else
            {
                ResimlerRepeater.DataSource = dt;
                ResimlerRepeater.DataBind();
                //Kayıt Edilecek Resimler
                ResimYukleme_field.Visible = true;
                ResimleriYukleBtn.Visible = true;
                ResimUploadYok.Visible = false;
            }
            KayitliResimler_Article.Visible = true;
            ResimUpload_Article.Visible = true;
        }
        else
        {
            // Genel İşlemler
            HataLbl.Visible = false;
            Urunyok.Visible = false;
            KayitTamam.Visible = false;
            // Kayıtlı Resimler
            KayitliResimler_Article.Visible = true;
            YukluResimler.Visible = false;
            ResimlerYok.Visible = true;
            ResimleriSilBtn.Visible = false;
            ResimlerRepeater.DataBind();
            // Resim Yükleme işlemleri
            ResimUpload_Article.Visible = true;
            ResimYukleme_field.Visible = true;
            ResimUploadYok.Visible = false;
            ResimleriYukleBtn.Visible = true;
        }
    }
    protected void urunBilgileriniGetirBtn_Click(object sender, EventArgs e)
    {
        try
        {
            GelID = RE.Urun_Arama_Turn_ID(UrunAdiBox.Text);
            if (!string.IsNullOrEmpty(UrunListesi_ID))
            {
                string[] Gel = RE.UrunDetay_UrunAdi_Dondur(UrunListesi_ID);
                UrunAdiBox.Text = Gel[0].ToString();
                Link = Gel[1].ToString();
                Resimler_Gel(UrunListesi_ID);
            }
            else if (GelID > 0)
            {
                string[] Gel = RE.UrunDetay_UrunAdi_Dondur(GelID.ToString());
                UrunAdiBox.Text = Gel[0].ToString();
                Link = Gel[1].ToString();
                Resimler_Gel(GelID.ToString());
            }
            else
            {
                HataLbl.Visible = false;
                Urunyok.Visible = true;
                KayitliResimler_Article.Visible = false;
            }
        }
        catch (Exception)
        {
            HataVar.Visible = true;
        }
    }
    public static void yukle(HttpPostedFile fu, int Ksize, string Kaydedilecek_DosyaAdi)
    {
        System.Drawing.Image orjinalFoto = null;
        HttpPostedFile jpeg_image_upload = fu;
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
        if (new_height > 480)
        {
            hedefYukseklik = 480;
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
        islenmisFotograf.Save(HttpContext.Current.Server.MapPath("../Urunler/Resimler/" + dosyaAdi), codec, eParams);
    }
    protected void ResimleriYukleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (UploadImages.HasFiles)
            {
                int Adet = 8 - ResimlerRepeater.Items.Count;
                if (Adet >= UploadImages.PostedFiles.Count)
                {
                    foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                    {
                        string KaydedilecekLogo = Guid.NewGuid().ToString().Remove(6) + "-" + uploadedFile.FileName;
                        yukle(uploadedFile, 640, KaydedilecekLogo);
                        if (!string.IsNullOrEmpty(UrunListesi_ID))
                        {
                            RE.Urun_Resimleri_Ekle(KaydedilecekLogo, UrunListesi_ID);
                        }
                        else
                        {
                            RE.Urun_Resimleri_Ekle(KaydedilecekLogo, GelID.ToString());
                        }
                    }
                    if (!string.IsNullOrEmpty(UrunListesi_ID))
                    {
                        Arama_Article.Visible = false;
                        ResimUpload_Article.Visible = false;
                        KayitliResimler_Article.Visible = false;
                        KayitTamamLbl.Text = UploadImages.PostedFiles.Count.ToString() + " Adet Resim Kaydedildi.";
                        KayitTamam.Visible = true;
                        string Urun_Link = Ortak.SiteAdresi_http + "/" + Link;
                        UrunKontrolLink.NavigateUrl = Urun_Link;
                        UrunKontrolLink.Text = "Ürünü İncelemek İçin Tıklayınız.";
                    }
                    else
                    {
                        Arama_Article.Visible = false;
                        ResimUpload_Article.Visible = false;
                        KayitliResimler_Article.Visible = false;
                        KayitTamamLbl.Text = UploadImages.PostedFiles.Count.ToString() + " Adet Resim Kaydedildi.";
                        KayitTamam.Visible = true;
                        string Urun_Link = Ortak.SiteAdresi_http + "/" + Link;
                        UrunKontrolLink.NavigateUrl = Urun_Link;
                        UrunKontrolLink.Text = "Ürünü İncelemek İçin Tıklayınız.";
                    }
                }
                else
                {
                    string Msaj = Adet.ToString() + " adet resim yükleyebilirsiniz.";
                    Ortak.MesajGoster(Msaj);
                }
            }
            else
            {
                Ortak.MesajGoster("Lütfen resim(ler) seçiniz.");
            }
        }
        catch (Exception)
        {
            HataVar.Visible = true;
        }
    }
    protected void ResimleriSilBtn_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList dizi = new ArrayList();
            foreach (RepeaterItem item in ResimlerRepeater.Items)
            {
                CheckBox c = (CheckBox)item.FindControl("ResimCheck");
                if (c.Checked)
                {
                    HiddenField ID = (HiddenField)item.FindControl("ResimID");
                    dizi.Add(ID.Value);
                }
            }
            if (dizi.Count != 0)
            {
                for (int i = 0; i < dizi.Count; i++)
                {
                    if (!string.IsNullOrEmpty(UrunListesi_ID))
                    {
                        RE.Urun_Resimleri_Delete(dizi[i].ToString(), UrunListesi_ID);
                        Resimler_Gel(UrunListesi_ID);
                    }
                    else
                    {
                        RE.Urun_Resimleri_Delete(dizi[i].ToString(), GelID.ToString());
                        Resimler_Gel(GelID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(UrunListesi_ID))
                {
                    Resimler_Gel(UrunListesi_ID);
                }
                else
                {
                    Resimler_Gel(GelID.ToString());
                }
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = dizi.Count.ToString() + " adet resim başarı ile silinmiştir.";
                HataVar.Visible = false;
            }
            else
            {
                KayitTamam.Visible = false;
                HataLbl.Text = "Silmek istediğiniz resim(leri) seçiniz.";
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            HataLbl.Visible = true;
        }
    }
}
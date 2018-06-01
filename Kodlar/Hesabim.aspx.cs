using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Hesabim : System.Web.UI.Page
{
    private static string GelenID = "1";
    SqlConnection con = new SqlConnection(Yol.ECon);
    cls_Hesabim cH = new cls_Hesabim();
    cls_Sepet cS = new cls_Sepet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["E_ticaretim"] != null)
            {
                string[] Gelenler = (string[])Session["E_ticaretim"];
                GelenID = Gelenler[0].ToString();
                string AdSoyad = Gelenler[1].ToString();
                AdSoyadLbl.Text = AdSoyad;
                if (!IsPostBack)
                {
                    SehirGetir_Kullanici();
                    SehirGetir_Fatura();
                    SehirGetir_Teslimat();
                    KullaniciveAdres_Bilgileri(GelenID);
                    Fatura_Adres_Bilgileri_Getir(GelenID);
                    Teslimat_Adres_Bilgileri_Getir(GelenID);
                }
            }
            else
            {
                Response.Redirect("Giris.aspx", false);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    private void SehirGetir_Kullanici()
    {
        DataTable dt = cls_DataAdaptore.TumSehirGetir();
        DataRow dr = dt.NewRow();
        dr["il_ad"] = "Lütfen Şehir Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        SehirDrop.DataSource = dt;
        SehirDrop.DataValueField = "il_id";
        SehirDrop.DataTextField = "il_ad";
        SehirDrop.DataBind();
    }
    private void SehirGetir_Teslimat()
    {
        DataTable dt = cls_DataAdaptore.TumSehirGetir();
        DataRow dr = dt.NewRow();
        dr["il_ad"] = "Lütfen Şehir Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        Teslimat_SehirDrop.DataSource = dt;
        Teslimat_SehirDrop.DataValueField = "il_id";
        Teslimat_SehirDrop.DataTextField = "il_ad";
        Teslimat_SehirDrop.DataBind();
    }
    private void SehirGetir_Fatura()
    {
        DataTable dt = cls_DataAdaptore.TumSehirGetir();
        DataRow dr = dt.NewRow();
        dr["il_ad"] = "Lütfen Şehir Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        Ft_FirmaSehirDrop.DataSource = dt;
        Ft_FirmaSehirDrop.DataValueField = "il_id";
        Ft_FirmaSehirDrop.DataTextField = "il_ad";
        Ft_FirmaSehirDrop.DataBind();
    }
    private void IlceGetirSehirSecimeGore_Kullanici(string GelenSehirID)
    {
        DataTable dt = cls_DataAdaptore.IlceGetirSehirSecimeGore(GelenSehirID);
        DataRow dr = dt.NewRow();
        dr["ilce_ad"] = "Lütfen İlçe Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        IlceDrop.DataSource = dt;
        IlceDrop.DataValueField = "ilce_id";
        IlceDrop.DataTextField = "ilce_ad";
        IlceDrop.DataBind();
    }
    private void IlceGetirSehirSecimeGore_Teslimat(string GelenSehirID)
    {
        DataTable dt = cls_DataAdaptore.IlceGetirSehirSecimeGore(GelenSehirID);
        DataRow dr = dt.NewRow();
        dr["ilce_ad"] = "Lütfen İlçe Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        Teslimat_IlceDrop.DataSource = dt;
        Teslimat_IlceDrop.DataValueField = "ilce_id";
        Teslimat_IlceDrop.DataTextField = "ilce_ad";
        Teslimat_IlceDrop.DataBind();
    }
    private void IlceGetirSehirSecimeGore_Firma(string GelenSehirID)
    {
        DataTable dt = cls_DataAdaptore.IlceGetirSehirSecimeGore(GelenSehirID);
        DataRow dr = dt.NewRow();
        dr["ilce_ad"] = "Lütfen İlçe Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        Ft_FirmaIlceDrop.DataSource = dt;
        Ft_FirmaIlceDrop.DataValueField = "ilce_id";
        Ft_FirmaIlceDrop.DataTextField = "ilce_ad";
        Ft_FirmaIlceDrop.DataBind();
    }
    public void KullaniciveAdres_Bilgileri(string Aydim)
    {
        string[] Gel_Personel_Bilgi = cH.Gonder_Personel_Bilgileri(GelenID);
        AdSoyadBox.Text = Gel_Personel_Bilgi[0].ToString();
        EvTlfBox.Text = Gel_Personel_Bilgi[1].ToString();
        IsTlfBox.Text = Gel_Personel_Bilgi[2].ToString();
        CepTlfBox.Text = Gel_Personel_Bilgi[3].ToString();
        SehirDrop.SelectedValue = Gel_Personel_Bilgi[4].ToString();
        IlceGetirSehirSecimeGore_Kullanici(Gel_Personel_Bilgi[4].ToString());
        IlceDrop.SelectedValue = Gel_Personel_Bilgi[5].ToString();
        EPostaBox.Text = Gel_Personel_Bilgi[6].ToString();
        Teslimat_EpostaBox.Text = Gel_Personel_Bilgi[6].ToString();
        Teslimat_EpostaBox.Text = Gel_Personel_Bilgi[6].ToString();
    }
    public void Teslimat_Adres_Bilgileri_Getir(string Aydim_Tes)
    {
        string[] Gele_Teslimat = cH.Gonder_Teslimat_Adresi(Aydim_Tes);
        Teslimat_TckimlikNoBox.Text = Gele_Teslimat[0].ToString();
        Teslimat_EpostaBox.Text = Gele_Teslimat[1].ToString();
        Teslimat_CepBox.Text = Gele_Teslimat[2].ToString();
        Teslimat_TelefonBox.Text = Gele_Teslimat[3].ToString();
        Teslimat_SehirDrop.SelectedValue = Gele_Teslimat[4].ToString();
        IlceGetirSehirSecimeGore_Teslimat(Gele_Teslimat[4].ToString());
        Teslimat_IlceDrop.SelectedValue = Gele_Teslimat[5].ToString();
        Teslimat_AdresBox.Text = Gele_Teslimat[6].ToString();
    }
    public void Fatura_Adres_Bilgileri_Getir(string Aydim_Fatura)
    {
        string[] Fatura_Gel = cH.Gonder_Fatura_Adresi(Aydim_Fatura);
        Ft_YetkiliAdSoyadBox.Text = Fatura_Gel[0].ToString();
        Ft_FirmaBox.Text = Fatura_Gel[1].ToString();
        Ft_VergiDairesiBox.Text = Fatura_Gel[2].ToString();
        Ft_VergiNoBox.Text = Fatura_Gel[3].ToString();
        Ft_FirmaSehirDrop.SelectedValue = Fatura_Gel[4].ToString();
        IlceGetirSehirSecimeGore_Firma(Fatura_Gel[4].ToString());
        Ft_FirmaIlceDrop.SelectedValue = Fatura_Gel[5].ToString();
        Ft_FirmaAdresBox.Text = Fatura_Gel[6].ToString();
        string Teslimatci = Fatura_Gel[7].ToString();
        if (Teslimatci == "True")
        {
            TeslimatIleFaturaAyniCheck.Checked = true;
            Ft_YetkiliAdSoyadBox.ReadOnly = true;
            Ft_FirmaBox.ReadOnly = true;
            Ft_VergiDairesiBox.ReadOnly = true;
            Ft_VergiNoBox.ReadOnly = true;
            Ft_FirmaSehirDrop.Enabled = false;
            Ft_FirmaIlceDrop.Enabled = false;
            Ft_FirmaAdresBox.ReadOnly = true;
        }
    }
    protected void KayitBtn_Click(object sender, EventArgs e)
    {
        KayitBtn.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(KayitBtn, "").ToString());
        try
        {
            if (cH.Kullanici_Guncelle(AdSoyadBox.Text, EvTlfBox.Text, IsTlfBox.Text, CepTlfBox.Text, SehirDrop.SelectedValue, IlceDrop.SelectedValue, GelenID) == true)
            {
                Ortak.MesajGoster("Bilgileri başarı ile güncellendi.");
            }
        }
        catch (Exception)
        {
            Ortak.MesajGoster("Hata oluştu !! Lütfen daha sonra tekrar deneyiniz.");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    protected void SehirDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SehirDrop.SelectedValue != "0")
        {
            IlceDrop.Items.Clear();
            string Gelen_SehirID = SehirDrop.SelectedValue;
            IlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore_Kullanici(Gelen_SehirID);
        }
    }
    protected void Teslimat_SehirDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Teslimat_SehirDrop.SelectedIndex != 0)
        {
            Teslimat_IlceDrop.Items.Clear();
            string Gelen_SehirID = Teslimat_SehirDrop.SelectedValue;
            Teslimat_IlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore_Teslimat(Gelen_SehirID);
        }
    }
    protected void Ft_FirmaSehirDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ft_FirmaSehirDrop.SelectedIndex != 0)
        {
            Ft_FirmaIlceDrop.Items.Clear();
            string Gelen_SehirID = Ft_FirmaSehirDrop.SelectedValue;
            Ft_FirmaIlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore_Firma(Gelen_SehirID);
        }
    }
    protected void TeslimatIleFaturaAyniCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (TeslimatIleFaturaAyniCheck.Checked)
        {
            Ft_YetkiliAdSoyadBox.ReadOnly = true;
            Ft_YetkiliAdSoyadBox.Text = AdSoyadBox.Text;
            Ft_FirmaAdresBox.Text = Teslimat_AdresBox.Text;
            Ft_FirmaBox.ReadOnly = true;
            Ft_VergiDairesiBox.ReadOnly = true;
            Ft_VergiNoBox.ReadOnly = true;
            Ft_FirmaSehirDrop.Enabled = false;
            Ft_FirmaIlceDrop.Enabled = false;
            Ft_FirmaAdresBox.ReadOnly = true;
        }
        else
        {
            Ft_YetkiliAdSoyadBox.ReadOnly = false;
            Ft_YetkiliAdSoyadBox.Text = "";
            Ft_FirmaBox.ReadOnly = false;
            Ft_VergiDairesiBox.ReadOnly = false;
            Ft_VergiNoBox.ReadOnly = false;
            Ft_FirmaSehirDrop.Enabled = true;
            Ft_FirmaIlceDrop.Enabled = true;
            Ft_FirmaAdresBox.ReadOnly = false;
        }
    }
    protected void DevamBtn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Ft_FirmaAdresBox.Text) || TeslimatIleFaturaAyniCheck.Checked)
        {
            if (cH.Siparis_Teslimat_Adresi_Guncelle(Teslimat_TckimlikNoBox.Text, Teslimat_EpostaBox.Text, Teslimat_CepBox.Text, Teslimat_TelefonBox.Text, Teslimat_SehirDrop.SelectedValue, Teslimat_SehirDrop.SelectedItem.Text, Teslimat_IlceDrop.SelectedValue, Teslimat_IlceDrop.SelectedItem.Text, Teslimat_AdresBox.Text, GelenID) == true)
            {
                bool Teslimat = false;
                string SehirID = Ft_FirmaSehirDrop.SelectedValue;
                string SehirAdi = Ft_FirmaSehirDrop.SelectedItem.Text;
                string IlceID = Ft_FirmaIlceDrop.SelectedValue;
                string IlceAdi = Ft_FirmaIlceDrop.SelectedItem.Text;
                if (TeslimatIleFaturaAyniCheck.Checked)
                {
                    Teslimat = true;
                    SehirID = Teslimat_SehirDrop.SelectedValue;
                    SehirAdi = Teslimat_SehirDrop.SelectedItem.Text;
                    IlceID = Teslimat_IlceDrop.SelectedValue;
                    IlceAdi = Teslimat_IlceDrop.SelectedItem.Text;
                }
                if (cH.Siparis_Fatura_Adresi_Guncelle(Ft_YetkiliAdSoyadBox.Text, Ft_FirmaBox.Text, Ft_VergiDairesiBox.Text, Ft_VergiNoBox.Text, SehirID, SehirAdi, IlceID, IlceAdi, Ft_FirmaAdresBox.Text, Teslimat, GelenID) == true)
                {
                    Ortak.MesajGoster("Teslimat ve fatura adresi başarı ile kayıt edildi.");
                }
                else
                {
                    Ortak.MesajGoster("Hata!! Bilgileri kontrol edip tekrar deneyiniz.");
                }
            }
            else
            {
                Ortak.MesajGoster("Hata!! Bilgileri kontrol edip tekrar deneyiniz.");
            }
        }
        else
        {
            Ortak.MesajGoster("Fatura adresini yazınız. Teslimat adresi ile aynı ise Teslimat Adresi ile Aynı seçeneğini işaretleyin.");
        }
    }
    protected void SifreKayitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            SifreKayitBtn.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(SifreKayitBtn, "").ToString());
            SifreTekrarBox.Attributes.Add("value", SifreTekrarBox.Text);
            string sifre = SifreTekrarBox.Text;
            if (cH.SifreYenileme(GelenID, sifre) == true)
            {
                SifreBox.Text = "";
                SifreTekrarBox.Text = "";
                Ortak.MesajGoster("Şifre başarı ile değişti.");
            }
            else
            {
                Ortak.MesajGoster("Hata !! Bilgileri kontrol edip tekrar deneyiniz.");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            SifreBox.Text = "";
            SifreBox.Attributes.Add("value", "");
        }
    }
    public void Ekle(string id, string ResimYol, string isim, double adet, double fiyat, double Toplam, string link)
    {
        try
        {
            DataTable dt = new DataTable();
            if (Session["sepet"] != null)
            {
                dt = (DataTable)Session["sepet"];
            }
            else
            {
                dt.Columns.Add("id");
                dt.Columns.Add("resim");
                dt.Columns.Add("isim");
                dt.Columns.Add("fiyat");
                dt.Columns.Add("adet");
                dt.Columns.Add("toplam");
                dt.Columns.Add("link");
            }
            bool varmi = Kontrol(id.ToString());
            if (varmi == false)
            {
                DataRow drow = dt.NewRow();
                drow["id"] = id;
                drow["resim"] = ResimYol;
                drow["isim"] = isim;
                drow["fiyat"] = fiyat;
                drow["adet"] = adet;
                drow["toplam"] = Toplam;
                drow["link"] = link;
                dt.Rows.Add(drow);
            }
            else
            {
                Artir(id, adet, fiyat);
            }
            Session["sepet"] = dt;
        }
        catch
        {
            Response.Redirect("Hata.aspx");
        }
    }
    private bool Kontrol(string id)
    {
        bool r = false;
        DataTable dt = new DataTable();
        if (Session["sepet"] != null)
        {
            dt = (DataTable)Session["sepet"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    r = true;
                    break;
                }
            }
        }
        return r;
    }
    private void Artir(string id, double adet, double fiyat)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    double adet1 = Convert.ToDouble(dt.Rows[i]["adet"].ToString());
                    double toplam1 = Convert.ToDouble(dt.Rows[i]["toplam"].ToString());
                    adet1 += adet;
                    toplam1 += toplam1;
                    dt.Rows[i]["adet"] = adet1.ToString();
                    dt.Rows[i]["toplam"] = toplam1.ToString();
                    Session["sepet"] = dt;
                    break;
                }
            }
        }
        catch
        {
            Response.Redirect("Hata.aspx");
        }
    }
}
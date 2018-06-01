using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Sepet : System.Web.UI.Page
{
    cls_Sepet cS = new cls_Sepet();
    cls_Siparis CSip = new cls_Siparis();
    cls_Hesabim cH = new cls_Hesabim();
    private static string GelenID, Gelen_FaturaID, Gelen_TeslimatID, Gelen_Isim;
    SqlConnection con = new SqlConnection(Yol.ECon);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Pay_SiparisNo"] != null)
                {
                    string S_N0 = Request.QueryString["Pay_SiparisNo"].Trim();
                    string G_ID = Request.QueryString["Pay_GelenID"].Trim();
                    string Odeme_Tutari = Request.QueryString["Pay_OdemeTutari"].Trim();
                    string G_Sepet_Fiyat = Request.QueryString["Pay_ODeme_SepetFiyat"].Trim();
                    string G_Sepet_KDV = Request.QueryString["Pay_Odeme_SepetKDV"].Trim();
                    string G_Kargo = Request.QueryString["Pay_Odeme_KargoBedeli"].Trim();
                    string G_Toplam = Request.QueryString["Pay_Odeme_GenelToplam"].Trim();
                    PayPayal_Odeme_Onay(G_ID, S_N0, Odeme_Tutari, G_Sepet_Fiyat, G_Sepet_KDV, G_Kargo, G_Toplam);
                }
                else
                {
                    GelBankalar();
                    KapidaOdemeBedeliLbl.Text = Ortak.Odenecek_Kapida_Odeme.ToString();
                    // Ödeme İşlemleri İçin Label Tanımları
                    //TaksitLi
                    FirmaAdi_Kredi_KartiTaksit_Lbl.Text = Ortak.SiteAdresiKısa;
                    FirmaAdi_Tesekkur_Kredi_Karti_TaksitLbl.Text = Ortak.SiteAdresiKısa;
                    KargoAdi_Kredi_Karti_Taksit_Lbl.Text = Ortak.KargoFirmalari;
                    //Tek
                    KargoAdi_Kredi_Karti_Tek_Lbl.Text = Ortak.KargoFirmalari;
                    FirmaAdi_Kredi_Karti_TekLbl.Text = Ortak.SiteAdresiKısa;
                    FirmaAdi_Tesekkur_Kredi_Karti_TekLbl.Text = Ortak.SiteAdresiKısa;
                    // Havale
                    KargoAdi_Havale_EftLbl.Text = Ortak.KargoFirmalari;
                    FirmaAdi_Havale_EFTLbl.Text = Ortak.SiteAdresiKısa;
                    FirmaAdi_Tesekkur_Havale_Eft.Text = Ortak.SiteAdresiKısa;
                    //Kapida Odeme
                    KargoAdi_Kapida_OdemeLbl.Text = Ortak.KargoFirmalari;
                    FirmaAdi_Kapida_Odeme_Lbl.Text = Ortak.SiteAdresiKısa;
                    FirmaAdi_Tesekkur_Kapida_OdemeLbl.Text = Ortak.SiteAdresiKısa;
                    //Paypal
                    KargoAdi_Paypal_OdemeLbl.Text = Ortak.KargoFirmalari;
                    FirmaAdi_Paypal_Odeme_Lbl.Text = Ortak.SiteAdresiKısa;
                    FirmaAdi_Tesekkur_Paypal_OdemeLbl.Text = Ortak.SiteAdresiKısa;
                    if (Session["E_ticaretim"] != null)
                    {
                        string[] Gelenler = (string[])Session["E_ticaretim"];
                        GelenID = Gelenler[0].ToString();
                        Gelen_Isim = Gelenler[1].ToString();
                        Veritabani_Uye_Sepet_Gel_Sil_Yeniden_Yukle(GelenID);
                        Veritabani_Uye_Sepet_Getir();
                        SehirGetir_Fatura();
                        SehirGetir_Teslimat();
                        BankaGetir();
                        Fatura_Adres_Bilgileri_Getir(GelenID);
                        Teslimat_Adres_Bilgileri_Getir(GelenID);
                    }
                    else
                    {
                        SepetGetir_Session();
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Hata.aspx", false);
            }
            finally
            {
                con.Close();
                con.Dispose();
                SqlConnection.ClearPool(con);
            }
        }
    }
    protected void AlisverisiTamamlaBtn_Click(object sender, EventArgs e)
    {
        if (Session["E_ticaretim"] != null)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Response.Redirect("Giris.aspx", false);
        }
    }
    private void SehirGetir_Teslimat()
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
    private void BankaGetir()
    {
        DataTable dt = cls_DataAdaptore.Banka_Getir();
        DataRow dr = dt.NewRow();
        dr["BankaAdi"] = "Banka Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        Kredi_Karti_Taksit_BankaDrop.DataSource = dt;
        Kredi_Karti_Taksit_BankaDrop.DataValueField = "E_BankaID";
        Kredi_Karti_Taksit_BankaDrop.DataTextField = "BankaAdi";
        Kredi_Karti_Taksit_BankaDrop.DataBind();
        // Tek Çekim
        //KrediKarti_Tek_Banka.DataSource = dt;
        //KrediKarti_Tek_Banka.DataValueField = "E_BankaID";
        //KrediKarti_Tek_Banka.DataTextField = "BankaAdi";
        //KrediKarti_Tek_Banka.DataBind();
    }
    private void Banka_Taksit_Getir(string Banka_Gel_ID)
    {
        Kredi_Karti_Taksit_TaksitSayisi_Drop.Items.Clear();
        int GeliyorNomero = cls_DataAdaptore.Banka_Taksit_Getir(Banka_Gel_ID);
        Kredi_Karti_Taksit_TaksitSayisi_Drop.Items.Add(new ListItem("Taksit Seçiniz", "0"));
        for (int i = 1; i <= GeliyorNomero; i++)
        {
            Kredi_Karti_Taksit_TaksitSayisi_Drop.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }


        //DataTable dt = ;
        //DataRow dr = dt.NewRow();
        //dr["TaksitSayisi"] = ;
        //dt.Rows.InsertAt(dr, 0);
        //Kredi_Karti_Taksit_TaksitSayisi_Drop.DataSource = dt;
        //Kredi_Karti_Taksit_TaksitSayisi_Drop.DataValueField = "E_BankaID";
        //Kredi_Karti_Taksit_TaksitSayisi_Drop.DataTextField = "TaksitSayisi";
        //Kredi_Karti_Taksit_TaksitSayisi_Drop.DataBind();
    }
    private void SehirGetir_Fatura()
    {
        DataTable dt = cls_DataAdaptore.TumSehirGetir();
        DataRow dr = dt.NewRow();
        dr["il_ad"] = "Lütfen Şehir Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        FirmaSehirDrop.DataSource = dt;
        FirmaSehirDrop.DataValueField = "il_id";
        FirmaSehirDrop.DataTextField = "il_ad";
        FirmaSehirDrop.DataBind();
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
    public void Teslimat_Adres_Bilgileri_Getir(string Aydim_Tes)
    {
        string[] Gele_Teslimat = cH.Gonder_Teslimat_Adresi(Aydim_Tes);
        TckimlikNoBox.Text = Gele_Teslimat[0].ToString();
        EPostaBox.Text = Gele_Teslimat[1].ToString();
        CepBox.Text = Gele_Teslimat[2].ToString();
        TelefonBox.Text = Gele_Teslimat[3].ToString();
        SehirDrop.SelectedValue = Gele_Teslimat[4].ToString();
        IlceGetirSehirSecimeGore_Teslimat(Gele_Teslimat[4].ToString());
        IlceDrop.SelectedValue = Gele_Teslimat[5].ToString();
        AdresBox.Text = Gele_Teslimat[6].ToString();
        Gelen_TeslimatID = Gele_Teslimat[9].ToString();
    }
    public void Fatura_Adres_Bilgileri_Getir(string Aydim_Fatura)
    {
        string[] Fatura_Gel = cH.Gonder_Fatura_Adresi(Aydim_Fatura);
        YetkiliAdSoyadBox.Text = Fatura_Gel[0].ToString();
        FirmaBox.Text = Fatura_Gel[1].ToString();
        VergiDairesiBox.Text = Fatura_Gel[2].ToString();
        VergiNoBox.Text = Fatura_Gel[3].ToString();
        FirmaSehirDrop.SelectedValue = Fatura_Gel[4].ToString();
        IlceGetirSehirSecimeGore_Firma(Fatura_Gel[4].ToString());
        FirmaIlceDrop.SelectedValue = Fatura_Gel[5].ToString();
        FirmaAdresBox.Text = Fatura_Gel[6].ToString();
        string Teslimatci = Fatura_Gel[7].ToString();
        if (Teslimatci == "True")
        {
            TeslimatIleFaturaAyniCheck.Checked = true;
            YetkiliAdSoyadBox.ReadOnly = true;
            FirmaBox.ReadOnly = true;
            VergiDairesiBox.ReadOnly = true;
            VergiNoBox.ReadOnly = true;
            FirmaSehirDrop.Enabled = false;
            FirmaIlceDrop.Enabled = false;
            FirmaAdresBox.ReadOnly = true;
        }
        Gelen_FaturaID = Fatura_Gel[10].ToString();
    }
    private void IlceGetirSehirSecimeGore_Teslimat(string GelenSehirID)
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
    private void IlceGetirSehirSecimeGore_Firma(string GelenSehirID)
    {
        DataTable dt = cls_DataAdaptore.IlceGetirSehirSecimeGore(GelenSehirID);
        DataRow dr = dt.NewRow();
        dr["ilce_ad"] = "Lütfen İlçe Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        FirmaIlceDrop.DataSource = dt;
        FirmaIlceDrop.DataValueField = "ilce_id";
        FirmaIlceDrop.DataTextField = "ilce_ad";
        FirmaIlceDrop.DataBind();
    }
    protected void SehirDrop_Adres_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SehirDrop.SelectedValue != "0")
        {
            IlceDrop.Items.Clear();
            string Gelen_SehirID = SehirDrop.SelectedValue;
            IlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore_Kullanici(Gelen_SehirID);
        }
    }
    protected void FirmaSehirDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FirmaSehirDrop.SelectedValue != "0")
        {
            FirmaIlceDrop.Items.Clear();
            string Gelen_SehirID = FirmaSehirDrop.SelectedValue;
            FirmaIlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore_Kullanici(Gelen_SehirID);
        }
    }
    protected void DevamBtn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(FirmaAdresBox.Text) || TeslimatIleFaturaAyniCheck.Checked)
        {
            if (cH.Siparis_Teslimat_Adresi_Guncelle(TckimlikNoBox.Text, EPostaBox.Text, CepBox.Text, TelefonBox.Text, SehirDrop.SelectedValue, SehirDrop.SelectedItem.Text, IlceDrop.SelectedValue, IlceDrop.SelectedItem.Text, AdresBox.Text, GelenID) == true)
            {
                bool Teslimat = false;
                string SehirID = FirmaSehirDrop.SelectedValue;
                string SehirAdi = FirmaSehirDrop.SelectedItem.Text;
                string IlceID = FirmaIlceDrop.SelectedValue;
                string IlceAdi = FirmaIlceDrop.SelectedItem.Text;
                if (TeslimatIleFaturaAyniCheck.Checked)
                {
                    Teslimat = true;
                    SehirID = SehirDrop.SelectedValue;
                    SehirAdi = SehirDrop.SelectedItem.Text;
                    IlceID = IlceDrop.SelectedValue;
                    IlceAdi = IlceDrop.SelectedItem.Text;
                }
                if (cH.Siparis_Fatura_Adresi_Guncelle(YetkiliAdSoyadBox.Text, FirmaBox.Text, VergiDairesiBox.Text, VergiNoBox.Text, FirmaSehirDrop.SelectedValue, FirmaSehirDrop.SelectedItem.Text, FirmaIlceDrop.SelectedValue, FirmaIlceDrop.SelectedItem.Text, FirmaAdresBox.Text, Teslimat, GelenID) == true)
                {
                    MultiView1.ActiveViewIndex = 2;
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
    protected void GeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    public void Veritabani_Uye_Sepet_Gel_Sil_Yeniden_Yukle(string Ay_di) // Sil ve Yeniden Kayıt
    {
        DataTable dt = cS.Uye_Siparis_Sepet_Gel(Ay_di);
        if (dt.Rows.Count != 0)
        {
            if (cS.Uyenin_Sepetini_Temizle(Ay_di) == true)
            {
                DataTable dt_sepet = new DataTable();
                dt_sepet = (DataTable)Session["sepet"];
                for (int i = 0; i < dt_sepet.Rows.Count; i++)
                {
                    cS.Uyenin_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Ay_di);
                }
            }
        }
        else
        {
            DataTable dt_sepet = new DataTable();
            if (Session["sepet"] != null)
            {
                dt_sepet = (DataTable)Session["sepet"];
                for (int i = 0; i < dt_sepet.Rows.Count; i++)
                {
                    cS.Uyenin_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Ay_di);
                }
            }
        }
    }
    private void Veritabani_Uye_Sepet_Getir()
    {
        DataTable dt = cS.Uye_Siparis_Sepet_Gel(GelenID);
        if (dt.Rows.Count != 0)
        {
            double toplam = 0;
            double toplamAdet = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dt.Rows[i]["fiyat"].ToString()) * Convert.ToDouble(dt.Rows[i]["adet"].ToString());
                toplamAdet += Convert.ToDouble(dt.Rows[i]["adet"].ToString());
            }
            double KDV = (toplam * 18) / 100;
            SepetFiyatLbl.Text = string.Format("{0:0.00}", toplam) + " TL";
            ODeme_SepetFiyatLbl.Text = toplam.ToString() + " TL";
            SepetKDVLbl.Text = KDV.ToString() + " TL";
            Odeme_SepetKDVLbl.Text = KDV.ToString() + " TL";
            GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
            Odeme_GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
            if (toplam > Ortak.SepetIcinKargo_Degeri)
            {
                KargoBedeliLbl.Text = "0.00 TL";
                Odeme_KargoBedeliLbl.Text = "0.00 TL";
                GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
                Odeme_GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
                double Havale_Hesap = (toplam + KDV) / 100 * Ortak.Odenecek_Havale_Indirim;
                double Havale_Toplam = toplam + KDV - Havale_Hesap;
                Odeme_HavaleOdeme.Text = string.Format("{0:0.00}", Havale_Toplam) + " TL";
            }
            else
            {
                KargoBedeliLbl.Text = Ortak.Odenecek_Kargo_Ucreti.ToString() + " TL";
                Odeme_KargoBedeliLbl.Text = Ortak.Odenecek_Kargo_Ucreti.ToString() + " TL";
                GenelToplamLbl.Text = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti).ToString() + " TL";
                Odeme_GenelToplamLbl.Text = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti).ToString() + " TL";
                double Havale_Hesap = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti) / 100 * Ortak.Odenecek_Havale_Indirim;
                double Havale_Toplam = toplam + KDV + Ortak.Odenecek_Kargo_Ucreti - Havale_Hesap;
                Odeme_HavaleOdeme.Text = string.Format("{0:0.00}", Havale_Toplam) + " TL";
            }
            ODeme_DataList.DataSource = dt;
            ODeme_DataList.DataBind();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        else
        {
            DataList1.DataBind();
            ODeme_DataList.DataBind();
            SepetYokDiv.Visible = true;
            panelsepet.Visible = false;
        }
    }
    public void Veritabani_Uye_Sepet_UrunSilme(string Uye_ID, string Sepet_ID)
    {
        if (cS.Uyenin_Sepeti_Urun_Sil(Uye_ID, Sepet_ID) == true)
        {
            DataTable dt = cS.Uye_Siparis_Sepet_Gel(GelenID);
            if (dt.Rows.Count != 0)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
            else
            {
                DataList1.DataBind();
                SepetYokDiv.Visible = true;
                panelsepet.Visible = false;
                Session["sepet"] = null;
            }
        }
        else
        {
            Ortak.MesajGoster("Hata!! Lütfen bilgileri kontrol edip tekrar deneyiniz.");
        }
    }
    public void GelBankalar()
    {
        BankaRepeater.DataSource = cls_Banka.GelBankaBilgiler();
        BankaRepeater.DataBind();
        Odeme_EFT_Havale_Repeater.DataSource = cls_Banka.GelBankaBilgiler();
        Odeme_EFT_Havale_Repeater.DataBind();
    }
    private void SepetGetir_Session()
    {
        if (Session["sepet"] != null)
        {
            double toplam = 0;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            if (dt.Rows.Count != 0)
            {
                DataList1.DataSource = null;
                ODeme_DataList.DataSource = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    toplam += Convert.ToDouble(dt.Rows[i]["fiyat"].ToString()) * Convert.ToDouble(dt.Rows[i]["adet"].ToString());
                }
                SepetFiyatLbl.Text = string.Format("{0:0.00}", toplam) + " TL";
                double KDV = (toplam * 18) / 100;
                SepetKDVLbl.Text = KDV.ToString() + " TL";
                GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
                SepetYokDiv.Visible = false;
                if (toplam > Ortak.SepetIcinKargo_Degeri)
                {
                    KargoBedeliLbl.Text = "0.00 TL";
                }
                else
                {
                    KargoBedeliLbl.Text = Ortak.Odenecek_Kargo_Ucreti.ToString() + " TL";
                    Odeme_KargoBedeliLbl.Text = Ortak.Odenecek_Kargo_Ucreti.ToString() + " TL";
                    GenelToplamLbl.Text = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti).ToString() + " TL";
                }
                DataList1.DataSource = dt.DefaultView;
                DataList1.DataBind();

            }
            else
            {
                DataList1.DataBind();
                SepetYokDiv.Visible = true;
                panelsepet.Visible = false;
                Session["sepet"] = null;
            }
        }
        else
        {
            DataList1.DataBind();
            panelsepet.Visible = false;
            SepetYokDiv.Visible = true;
        }
    }
    public void Sil(string id)
    {
        DataTable dt = new DataTable();
        if (Session["sepet"] != null)
        {
            dt = (DataTable)Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    dt.Rows[i].Delete();
                    Session["sepet"] = dt;
                    break;
                }
            }
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
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            string Aydim = e.CommandArgument.ToString();
            if (Session["E_ticaretim"] != null)
            {
                Veritabani_Uye_Sepet_UrunSilme(GelenID, Aydim);
                Sil(Aydim);
                SepetGetir_Session();
            }
            else
            {
                Sil(Aydim);
                SepetGetir_Session();
            }
        }
    }
    protected void SepetAdetGuncelleBtn_Click(object sender, EventArgs e)
    {
        if (Session["E_ticaretim"] != null)
        {
            if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
            {
                int count_Session = DataList1.Items.Count;
                for (int i = 0; i < count_Session; i++)
                {
                    ImageButton ID = DataList1.Items[i].FindControl("DeleteBtn") as ImageButton;
                    Image Resim = DataList1.Items[i].FindControl("Resim") as Image;
                    HyperLink AdiLbl = DataList1.Items[i].FindControl("UrunAdi") as HyperLink;
                    TextBox Adet = DataList1.Items[i].FindControl("AdetBox") as TextBox;
                    Label FiyatiLbl = DataList1.Items[i].FindControl("BirimFiyatLbl") as Label;
                    double fiyati = Convert.ToDouble(FiyatiLbl.Text);
                    double adeti = Convert.ToDouble(Adet.Text);
                    string Link = AdiLbl.NavigateUrl.ToString();
                    double toplam = fiyati * adeti;
                    string ResimYol = Resim.ImageUrl.ToString();
                    Sil(ID.CommandArgument.ToString());
                    Ekle(ID.CommandArgument.ToString(), ResimYol, AdiLbl.Text, adeti, fiyati, toplam, Link);
                    cS.Uyenin_Sepeti_Adet_Fiyat_Guncelle(ID.CommandArgument.ToString(), Convert.ToInt32(adeti), toplam, GelenID);
                }
            }
        }
        else
        {
            Session["sepet"] = null;
            int count = DataList1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                ImageButton ID = DataList1.Items[i].FindControl("DeleteBtn") as ImageButton;
                Image Resim = DataList1.Items[i].FindControl("Resim") as Image;
                HyperLink AdiLbl = DataList1.Items[i].FindControl("UrunAdi") as HyperLink;
                TextBox Adet = DataList1.Items[i].FindControl("AdetBox") as TextBox;
                Label FiyatiLbl = DataList1.Items[i].FindControl("BirimFiyatLbl") as Label;
                double fiyati = Convert.ToDouble(FiyatiLbl.Text);
                double adeti = Convert.ToDouble(Adet.Text);
                string Link = AdiLbl.NavigateUrl.ToString();
                double toplam = fiyati * adeti;
                string ResimYol = Resim.ImageUrl.ToString();
                Ekle(ID.CommandArgument.ToString(), ResimYol, AdiLbl.Text, adeti, fiyati, toplam, Link);
            }
        }
        Response.Redirect("Sepet.aspx", false);
    }
    protected void TeslimatIleFaturaAyniCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (TeslimatIleFaturaAyniCheck.Checked)
        {
            YetkiliAdSoyadBox.ReadOnly = true;
            FirmaBox.ReadOnly = true;
            VergiDairesiBox.ReadOnly = true;
            VergiNoBox.ReadOnly = true;
            FirmaSehirDrop.Enabled = false;
            FirmaIlceDrop.Enabled = false;
            FirmaAdresBox.ReadOnly = true;
        }
        else
        {
            YetkiliAdSoyadBox.ReadOnly = false;
            FirmaBox.ReadOnly = false;
            VergiDairesiBox.ReadOnly = false;
            VergiNoBox.ReadOnly = false;
            FirmaSehirDrop.Enabled = true;
            FirmaIlceDrop.Enabled = true;
            FirmaAdresBox.ReadOnly = false;
        }
    }
    protected void Kredi_Karti_Taksit_BankaDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Kredi_Karti_Taksit_BankaDrop.SelectedValue != "0")
        {
            Kredi_Karti_Taksit_TaksitSayisi_Drop.Items.Clear();
            string Gelen_BankaID = Kredi_Karti_Taksit_BankaDrop.SelectedValue;
            Kredi_Karti_Taksit_TaksitSayisi_Drop.Enabled = true;
            Banka_Taksit_Getir(Gelen_BankaID);
        }
    }
    protected void KrediKarti_TamamBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["sepet"] != null)
            {
                string Kayit_Odeme_Tutari = Odeme_GenelToplamLbl.Text.Substring(0, Odeme_GenelToplamLbl.Text.Length - 3);
                double KrediKarti_Tek = Convert.ToDouble(Kayit_Odeme_Tutari);
                int Son_Kullanim_Ay = Convert.ToInt32(KrediKarti_Tek_AyDrop.SelectedItem.Text);
                int Son_Kullanim_Yil = Convert.ToInt32(KrediKarti_Tek_Sene.SelectedItem.Text);
                int Guvenlik_Kodu = Convert.ToInt32(KrediKarti_Tek_GuvenlikKoduBox.Text);
                long Kart_Numarasi = Convert.ToInt64(KrediKarti_Tek_KartNumarasiBox.Text);
                string KartNumarasi_Kayit_Icin = Ortak.Encrypt(KrediKarti_Tek_KartNumarasiBox.Text.Substring(0, KrediKarti_Tek_KartNumarasiBox.Text.Length - 4));
                //     KrediKarti_SanalPos_Cekim(Son_Kullanim_Ay, Son_Kullanim_Yil, Guvenlik_Kodu, Kart_Numarasi, KrediKarti_Tek_AdSoyadBox.Text, 1, "Hangi Banka İsteniyorsa", KrediKarti_Tek);
                //   if (p.sonuc)
                //   {
                string Sanal_Referans = "NA";
                string Sanal_GroupID =  "NA";
                string Sanal_transId = "NA";
                string Sanal_Code =  "NA";

                string Siparis_NO = KodUret().ToUpper() + GelenID;
                SiparisNo_Tek_KrediKarti_Lbl.Text = Siparis_NO;
                string SiparisTarihi = DateTime.Now.ToString();
                SiparisTarihi = SiparisTarihi.Substring(0, SiparisTarihi.Length - 3);
                //Fiyat İşlemleri

                Odeme_Kredi_Karti_Tek_TutarLbl.Text = KrediKarti_Tek.ToString() + " TL";
                string SiparisNoFiyat = Siparis_NO + "-" + Odeme_Kredi_Karti_Tek_TutarLbl.Text;
                int Geliyor_SiparisID_ID = CSip.Siparis_Kaydet(Siparis_NO, SiparisTarihi, OdemeSecenekleri_RadioList.SelectedItem.Text, SiparisNoFiyat, KrediKarti_Tek, "15", GelenID, Gelen_FaturaID, Gelen_TeslimatID,KrediKarti_Tek_NotunuzBox.Text);
                if (Geliyor_SiparisID_ID > 0)
                {
                    DataTable dt_sepet = new DataTable();
                    dt_sepet = (DataTable)Session["sepet"];
                    for (int i = 0; i < dt_sepet.Rows.Count; i++)
                    {
                        cS.Siparis_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Geliyor_SiparisID_ID.ToString(), GelenID);
                    }
                    if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
                    {
                        if (CSip.Siparis_Kart_Cekim_Kayit(GelenID, Geliyor_SiparisID_ID.ToString(), "Uygun Banka Seçilecek", "1", Sanal_Referans, Sanal_GroupID, Sanal_transId, Sanal_Code, KartNumarasi_Kayit_Icin) == true)
                        {
                            // Bankadan bankaya değişiklik göstereceği için, alanlardan bazıları boş gelebilir.
                            OdemeBildirim_MailGonder(Gelen_Isim, Siparis_NO, ODeme_SepetFiyatLbl.Text, Odeme_SepetKDVLbl.Text, Odeme_KargoBedeliLbl.Text, Odeme_GenelToplamLbl.Text, Odeme_Kredi_Karti_Tek_TutarLbl.Text, "1", "0 TL", "0 TL", "0 TL", Gelen_Isim, AdresBox.Text, IlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text, CepBox.Text, YetkiliAdSoyadBox.Text, FirmaAdresBox.Text, FirmaIlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text);
                            Session["sepet"] = null;
                            MultiView1.ActiveViewIndex = 3;
                        }
                    }
                }
                //}
                //else
                //{
                //    // Hata kodlarının açıklamaları ilgili banka dökümantasyonunda belirtilmiştir.
                //    StringBuilder Mesaj = new StringBuilder();
                //    Mesaj.Append("Sonuç : " + p.referansNo);
                //    Mesaj.Append("\r");
                //    Mesaj.Append("Hata Mesajı : " + p.hataMesaji);
                //    Mesaj.Append("\r");
                //    Mesaj.Append("Hata Kodu : " + p.hataKodu);
                //    Mesaj.Append("\r");
                //    Ortak.MesajGoster(Mesaj.ToString());
                //}
            }
            else
            {
                Response.Redirect("Giris.aspx", false);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx", false);
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    protected void KrediKarti_GeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Kredi_Karti_Taksit_GeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Kredi_Karti_Taksit_TamamBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["sepet"] != null)
            {
                string Kayit_Odeme_Tutari = Odeme_GenelToplamLbl.Text.Substring(0, Odeme_GenelToplamLbl.Text.Length - 3);
                double KrediKarti_Taksit = Convert.ToDouble(Kayit_Odeme_Tutari);
                int Son_Kullanim_Ay = Convert.ToInt32(Kredi_Karti_Taksit_SonKullanmaAy.SelectedItem.Text);
                int Son_Kullanim_Yil = Convert.ToInt32(Kredi_Karti_Taksit_SonKullanmaSene.SelectedItem.Text);
                int Guvenlik_Kodu = Convert.ToInt32(Kredi_Karti_Taksit_GuvenlikBox.Text);
                long Kart_Numarasi = Convert.ToInt64(Kredi_Karti_Taksit_KartNoBox.Text);
                string KartNumarasi_Kayit_Icin = Ortak.Encrypt(Kredi_Karti_Taksit_KartNoBox.Text.Substring(0, Kredi_Karti_Taksit_KartNoBox.Text.Length - 4));
                string Kredi_Karti_TaksitSayisi = Kredi_Karti_Taksit_TaksitSayisi_Drop.SelectedItem.Value;
                //     KrediKarti_SanalPos_Cekim(Son_Kullanim_Ay, Son_Kullanim_Yil, Guvenlik_Kodu, Kart_Numarasi, KrediKarti_Tek_AdSoyadBox.Text, 1, "Hangi Banka İsteniyorsa", KrediKarti_Tek);
                //   if (p.sonuc)
                //   {
                string Sanal_Referans = "NA";
                string Sanal_GroupID =  "NA";
                string Sanal_transId =  "NA";
                string Sanal_Code =  "NA";

                string Siparis_NO = KodUret().ToUpper() + GelenID;
                SiparisNo_Taksit_KrediKarti_Lbl.Text = Siparis_NO;
                string SiparisTarihi = DateTime.Now.ToString();
                SiparisTarihi = SiparisTarihi.Substring(0, SiparisTarihi.Length - 3);
                //Fiyat İşlemleri

                Odeme_Kredi_Karti_Taksit_TutarLbl.Text = KrediKarti_Taksit.ToString() + " TL";
                string SiparisNoFiyat = Siparis_NO + "-" + Odeme_Kredi_Karti_Taksit_TutarLbl.Text;
                int Geliyor_SiparisID_ID = CSip.Siparis_Kaydet(Siparis_NO, SiparisTarihi, OdemeSecenekleri_RadioList.SelectedItem.Text, SiparisNoFiyat, KrediKarti_Taksit, "15", GelenID, Gelen_FaturaID, Gelen_TeslimatID,Kredi_Karti_Taksit_SiparisNotuBox.Text);
                if (Geliyor_SiparisID_ID > 0)
                {
                    DataTable dt_sepet = new DataTable();
                    dt_sepet = (DataTable)Session["sepet"];
                    for (int i = 0; i < dt_sepet.Rows.Count; i++)
                    {
                        cS.Siparis_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Geliyor_SiparisID_ID.ToString(), GelenID);
                    }
                    if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
                    {
                        if (CSip.Siparis_Kart_Cekim_Kayit(GelenID, Geliyor_SiparisID_ID.ToString(), Kredi_Karti_Taksit_BankaDrop.SelectedItem.Text,Kredi_Karti_TaksitSayisi, Sanal_Referans, Sanal_GroupID, Sanal_transId, Sanal_Code, KartNumarasi_Kayit_Icin) == true)
                        {
                            // Bankadan bankaya değişiklik göstereceği için, alanlardan bazıları boş gelebilir.
                            OdemeBildirim_MailGonder(Gelen_Isim, Siparis_NO, ODeme_SepetFiyatLbl.Text, Odeme_SepetKDVLbl.Text, Odeme_KargoBedeliLbl.Text, Odeme_GenelToplamLbl.Text, Odeme_GenelToplamLbl.Text, Kredi_Karti_TaksitSayisi, "0 TL", "0 TL", "0 TL", Gelen_Isim, AdresBox.Text, IlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text, CepBox.Text, YetkiliAdSoyadBox.Text, FirmaAdresBox.Text, FirmaIlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text);
                            Session["sepet"] = null;
                            MultiView1.ActiveViewIndex = 4;
                        }
                    }
                }
                //}
                //else
                //{
                //    // Hata kodlarının açıklamaları ilgili banka dökümantasyonunda belirtilmiştir.
                //    StringBuilder Mesaj = new StringBuilder();
                //    Mesaj.Append("Sonuç : " + p.referansNo);
                //    Mesaj.Append("\r");
                //    Mesaj.Append("Hata Mesajı : " + p.hataMesaji);
                //    Mesaj.Append("\r");
                //    Mesaj.Append("Hata Kodu : " + p.hataKodu);
                //    Mesaj.Append("\r");
                //    Ortak.MesajGoster(Mesaj.ToString());
                //}
            }
            else
            {
                Response.Redirect("Giris.aspx", false);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx", false);
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }









    }
    protected void EftHavaleGeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void EftHavaleTamamBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["sepet"] != null)
            {
                string Siparis_NO = KodUret().ToUpper() + GelenID;
                SiparisNo_EFT_Havale_Lbl.Text = Siparis_NO;
                string SiparisTarihi = DateTime.Now.ToString();
                SiparisTarihi = SiparisTarihi.Substring(0, SiparisTarihi.Length - 3);
                string Kayit_Odeme_Tutari = Odeme_HavaleOdeme.Text.Substring(0, Odeme_HavaleOdeme.Text.Length - 3);
                Odeme_Havale_TutarLbl.Text = Odeme_HavaleOdeme.Text;
                string SiparisNoFiyat = Siparis_NO + "-" + Odeme_Havale_TutarLbl.Text;
                int Geliyor_Havale_ID = CSip.Siparis_Kaydet(Siparis_NO, SiparisTarihi, OdemeSecenekleri_RadioList.SelectedItem.Text, SiparisNoFiyat, Convert.ToDouble(Kayit_Odeme_Tutari), "2", GelenID, Gelen_FaturaID, Gelen_TeslimatID,EftHavale_NotuBox.Text);
                if (Geliyor_Havale_ID > 0)
                {
                    DataTable dt_sepet = new DataTable();
                    dt_sepet = (DataTable)Session["sepet"];
                    for (int i = 0; i < dt_sepet.Rows.Count; i++)
                    {
                        cS.Siparis_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Geliyor_Havale_ID.ToString(), GelenID);
                    }
                    if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
                    {
                        OdemeBildirim_MailGonder(Gelen_Isim, Siparis_NO, ODeme_SepetFiyatLbl.Text, Odeme_SepetKDVLbl.Text, Odeme_KargoBedeliLbl.Text, Odeme_GenelToplamLbl.Text, "0 TL", "0", Odeme_HavaleOdeme.Text, "0 TL", "0 TL", Gelen_Isim, AdresBox.Text, IlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text, CepBox.Text, YetkiliAdSoyadBox.Text, FirmaAdresBox.Text, FirmaIlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text);
                        Session["sepet"] = null;
                        MultiView1.ActiveViewIndex = 5;
                    }
                }
            }
            else
            {
                Response.Redirect("Giris.aspx", false);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx", false);
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    public string KodUret()
    {
        Random r = new Random();
        string result = string.Empty;
        char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
        for (int i = 0; i < 6; i++)
        {
            result += cr[r.Next(0, cr.Length - 1)].ToString();
        }
        return result;
    }
    protected void KapidaOdeme_GeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void KapidaOdeme_TamamBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["sepet"] != null)
            {
                string Siparis_NO = KodUret().ToUpper() + GelenID;
                SiparisNo_Kapida_Odeme_Lbl.Text = Siparis_NO;
                string SiparisTarihi = DateTime.Now.ToString();
                SiparisTarihi = SiparisTarihi.Substring(0, SiparisTarihi.Length - 3);
                //Fiyat İşlemleri
                string Kayit_Odeme_Tutari = Odeme_GenelToplamLbl.Text.Substring(0, Odeme_GenelToplamLbl.Text.Length - 3);
                double Kapida_Odeme = Convert.ToDouble(Kayit_Odeme_Tutari) + 5;
                Odeme_KapidaOdeme_TutarLbl.Text = Kapida_Odeme.ToString() + " TL";
                string SiparisNoFiyat = Siparis_NO + "-" + Odeme_KapidaOdeme_TutarLbl.Text;
                int Geliyor_Havale_ID = CSip.Siparis_Kaydet(Siparis_NO, SiparisTarihi, OdemeSecenekleri_RadioList.SelectedItem.Text, SiparisNoFiyat, Kapida_Odeme, "14", GelenID, Gelen_FaturaID, Gelen_TeslimatID,KapidaOdeme_Notubox.Text);
                if (Geliyor_Havale_ID > 0)
                {
                    DataTable dt_sepet = new DataTable();
                    dt_sepet = (DataTable)Session["sepet"];
                    for (int i = 0; i < dt_sepet.Rows.Count; i++)
                    {
                        cS.Siparis_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Geliyor_Havale_ID.ToString(), GelenID);
                    }
                    if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
                    {
                        OdemeBildirim_MailGonder(Gelen_Isim, Siparis_NO, ODeme_SepetFiyatLbl.Text, Odeme_SepetKDVLbl.Text, Odeme_KargoBedeliLbl.Text, Odeme_GenelToplamLbl.Text, "0 TL", "0", "0 TL", Odeme_KapidaOdeme_TutarLbl.Text, "0 TL", Gelen_Isim, AdresBox.Text, IlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text, CepBox.Text, YetkiliAdSoyadBox.Text, FirmaAdresBox.Text, FirmaIlceDrop.SelectedItem.Text, SehirDrop.SelectedItem.Text);
                        Session["sepet"] = null;
                        MultiView1.ActiveViewIndex = 6;
                    }
                }
            }
            else
            {
                Response.Redirect("Giris.aspx", false);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx", false);
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    public string KarekterDegistir(string HaberAdi)
    {
        //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
        string Temp = HaberAdi.ToLower();
        Temp = Temp.Replace("-", ""); Temp = Temp.Replace("ı", "i");
        Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
        Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
        Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
        Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
        Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
        Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
        Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
        Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
        Temp = Temp.Replace("?", ""); Temp = Temp.Replace(".", "_");
        return Temp;
    }
    //Paypal'a Gönderilecek URL
    public string PayPal_Gidicek_URL(string Pay_Amount, string Pay_PayPalBaseUrl, string Pay_AccountEmail, string Pay_ItemName, string Pay_ItemNumber, string Pay_ImageUrl, string Pay_SuccessUrl, string Pay_CancelUrl)
    {
        //Amerikada "." kullanıldığı için "," ile replace ediyoruz
        string tutar = Pay_Amount.Replace(',', '.');
        StringBuilder Url = new StringBuilder();
        //HttpUtility.UrlEncode(AccountEmail)
        Url.Append(Pay_PayPalBaseUrl + "cmd=_xclick&undefined_quantity=0&no_shipping=1&no_note=1&currency_code=USD&add=0");
        Url.AppendFormat("&business={0}", HttpUtility.UrlEncode(Pay_AccountEmail));
        //ItemName = KarekterDegistir(ItemName);
        Url.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(Pay_ItemName));
        Url.AppendFormat("&item_number={0}", HttpUtility.UrlEncode(Pay_ItemNumber));
        Url.AppendFormat("&image_url={0}", HttpUtility.UrlEncode(Pay_ImageUrl));
        Url.AppendFormat("&amount={0:f2}", tutar);
        Url.AppendFormat("&return={0}", HttpUtility.UrlEncode(Pay_SuccessUrl));
        Url.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(Pay_CancelUrl));
        return Url.ToString();
    }
    // Paypal'dan Dönen Değer ile Veritabanı Kayıt
    public void PayPayal_Odeme_Onay(string Pay_GelenID, string Pay_SiparisNo, string Pay_OdemeTutari, string Pay_ODeme_SepetFiyatLbl, string Pay_Odeme_SepetKDVLbl, string Pay_Odeme_KargoBedeliLbl, string Pay_Odeme_GenelToplamLbl)
    {

        string AdiSoyadi = CSip.Gonder_AdSoyad(Pay_GelenID);
        AdiSoyadi = Ortak.Decrypt(AdiSoyadi);
        SiparisNo_Paypal_Odeme_Lbl.Text = Pay_SiparisNo;
        string SiparisTarihi = DateTime.Now.ToString();
        SiparisTarihi = SiparisTarihi.Substring(0, SiparisTarihi.Length - 3);
        double Paypal_Odeme = Convert.ToDouble(Pay_OdemeTutari);
        Odeme_Paypal_TutarLbl.Text = Pay_OdemeTutari + " TL";
        string SiparisNoFiyat = Pay_SiparisNo + "-" + Odeme_Paypal_TutarLbl.Text;
        // Teslimat Adresi
        string[] Gele_Teslimat = cH.Gonder_Teslimat_Adresi(Pay_GelenID);
        string Pay_Teslim_Cep = Gele_Teslimat[2].ToString();
        string Pay_Teslim_Adres = Gele_Teslimat[6].ToString();
        string Pay_Teslim_Sehir = Gele_Teslimat[7].ToString();
        string Pay_Teslim_Ilce = Gele_Teslimat[8].ToString();
        string Pay_Gelen_TeslimID = Gele_Teslimat[9].ToString();
        // Fatura Adresi
        string[] Fatura_Gel = cH.Gonder_Fatura_Adresi(Pay_GelenID);
        string Pay_Ft_YetkiliAdi = Fatura_Gel[0].ToString();
        string Pay_Ft_Adres = Fatura_Gel[1].ToString();
        string Pay_Ft_Sehir = Fatura_Gel[8].ToString();
        string Pay_Ft_Ilce = Fatura_Gel[9].ToString();
        string Pay_Gelen_FtID = Gele_Teslimat[9].ToString();
        //Kayıt ve Ödeme İşlemleri
        int Geliyor_Havale_ID = CSip.Siparis_Kaydet(Pay_SiparisNo, SiparisTarihi, "Paypal ile Ödeme", SiparisNoFiyat, Paypal_Odeme, "15", Pay_GelenID, Pay_Gelen_FtID, Pay_Gelen_TeslimID,Paypal_NotuBox.Text);
        if (Geliyor_Havale_ID > 0)
        {
            DataTable dt_sepet = new DataTable();
            dt_sepet = (DataTable)Session["sepet"];
            for (int i = 0; i < dt_sepet.Rows.Count; i++)
            {
                cS.Siparis_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Geliyor_Havale_ID.ToString(), GelenID);
            }
            if (cS.Uyenin_Sepetini_Temizle(GelenID) == true)
            {
                OdemeBildirim_MailGonder(AdiSoyadi, Pay_SiparisNo, Pay_ODeme_SepetFiyatLbl, Pay_Odeme_SepetKDVLbl, Pay_Odeme_KargoBedeliLbl, Pay_Odeme_GenelToplamLbl, "0 TL", "0", "0 TL", "0 TL", Pay_Odeme_GenelToplamLbl, AdiSoyadi, Pay_Teslim_Adres, Pay_Teslim_Ilce, Pay_Teslim_Sehir, Pay_Teslim_Cep, Pay_Ft_YetkiliAdi, Pay_Ft_Adres, Pay_Ft_Sehir, Pay_Ft_Sehir);
                Session["sepet"] = null;
                MultiView1.ActiveViewIndex = 7;
            }
        }

    }
    //Paypal Gönderme
    protected void Paypal_GeriDonBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    public double DovizKuru_Dolar()
    {
        XmlDocument xmlVerisi = new XmlDocument();
        xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
        double dolar = Convert.ToDouble(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
        double Euro = Convert.ToDouble(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
        return dolar;
    }
    protected void Paypal_TamamBtn_Click(object sender, EventArgs e)
    {
        try
        {
            double Ucret_ = Convert.ToDouble(Odeme_GenelToplamLbl.Text.Substring(0, Odeme_GenelToplamLbl.Text.Length - 3));
            double Gidecek_USD = Ucret_ / DovizKuru_Dolar();
            Gidecek_USD = Math.Round(Gidecek_USD, 2);
            string Siparis_NO = KodUret().ToUpper() + GelenID;
            string Ucret_TL = Odeme_GenelToplamLbl.Text.Substring(0, Odeme_GenelToplamLbl.Text.Length - 3);
            string AccountEmail = Ortak.PayPay_Icin_Eposta;
            string PayPalBaseUrl = "https://www.paypal.com/cgi-bin/webscr?";
            string ImageUrl = Ortak.SiteAdresi_http + "/Image/logo.jpg";

            StringBuilder Gidicekler = new StringBuilder();
            Gidicekler.Append("Pay_SiparisNo=" + Siparis_NO);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_GelenID=" + GelenID);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_OdemeTutari=" + Ucret_TL);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_GelenFtID=" + Gelen_FaturaID);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_TeslimatID=" + Gelen_TeslimatID);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_ODeme_SepetFiyat=" + ODeme_SepetFiyatLbl.Text);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_Odeme_SepetKDV=" + Odeme_SepetKDVLbl.Text);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_Odeme_KargoBedeli=" + Odeme_KargoBedeliLbl.Text);
            Gidicekler.Append("&");
            Gidicekler.Append("Pay_Odeme_GenelToplam=" + Odeme_GenelToplamLbl.Text);
            string SuccessUrl = Ortak.SiteAdresi_http + "/Sepet.aspx?" + Gidicekler;
            string CancelUrl = Ortak.SiteAdresi_http + "/Sepet.aspx";
            // URL ile gönder
            Response.Redirect(PayPal_Gidicek_URL(Gidecek_USD.ToString(), PayPalBaseUrl, AccountEmail, "Ceptaki.com Urun Satisi", Siparis_NO, ImageUrl, SuccessUrl, CancelUrl));
        }
        catch (Exception)
        {
            //      Response.Redirect("Hata.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }
    private void OdemeBildirim_MailGonder(string _AdSoyad, string _SiparisNo, string _Toplam, string _KDV, string _KargoUcreti, string _GenelToplam, string _KrediKartiTutar, string _TaksitSayisi, string _HavaleTutari, string _KapidaTutari, string _PaypalTutari, string _Tes_AdSoyad, string _Tes_Adres, string _Tes_Ilce, string _Tes_Sehir, string _Cep_Telefon, string _Ft_AdSoyad, string _Ft_Adres, string _Ft_Ilce, string _Ft_Sehir)
    {
        string Logo = Ortak.SiteAdresi_http + "/Image/logo.jpg";
        string SolBanner = Ortak.SiteAdresi_http + "/EpostaSablon/Image/sol.jpg";
        string SagBanner = Ortak.SiteAdresi_http + "/EpostaSablon/Image/sag.jpg";
        MailDefinition mailTarifi = new MailDefinition();
        mailTarifi.BodyFileName = "~/EpostaSablon/EPosta_MusteriSiparis.html"; //Şablon 
        mailTarifi.From = Ortak.Eposta;
        DataTable dataTable = new DataTable();
        dataTable = (DataTable)Session["sepet"];
        var TabloBilgileri = "";
        foreach (DataRow entry in dataTable.Rows)
        {
            TabloBilgileri += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", entry["isim"].ToString(), entry["fiyat"].ToString() + " TL", entry["adet"].ToString(), entry["toplam"].ToString() + " TL");
        }
        ListDictionary degistirmeListesi = new ListDictionary();
        degistirmeListesi.Add("<%SolBanner%>", SolBanner);
        degistirmeListesi.Add("<%SagBanner%>", SagBanner);
        degistirmeListesi.Add("<%SolBanner_Link%>", Ortak.SiteAdresi_http + "/Kampanya.aspx");
        degistirmeListesi.Add("<%SagBanner_Link%>", Ortak.SiteAdresi_http + "/Kampanya.aspx");
        degistirmeListesi.Add("<%SiteAdi%>", Ortak.E_Ticaret_SiteAdi);
        degistirmeListesi.Add("<%Tarih%>", DateTime.Now.ToShortDateString());
        degistirmeListesi.Add("<%MusteriAdi%>", _AdSoyad);
        degistirmeListesi.Add("<%SiparisNo%>", _SiparisNo);
        degistirmeListesi.Add("<%TabloDetaylari%>", TabloBilgileri);
        degistirmeListesi.Add("<%Toplam%>", _Toplam);
        degistirmeListesi.Add("<%KDV%>", _KDV);
        degistirmeListesi.Add("<%KargoUcreti%>", _KargoUcreti);
        degistirmeListesi.Add("<%GenelToplam%>", _GenelToplam);
        degistirmeListesi.Add("<%KKTutar%>", _KrediKartiTutar);
        degistirmeListesi.Add("<%TS%>", _TaksitSayisi);
        degistirmeListesi.Add("<%HavaleTutari%>", _HavaleTutari);
        degistirmeListesi.Add("<%KapidaTutari%>", _KapidaTutari);
        degistirmeListesi.Add("<%PaypalTutari%>", _PaypalTutari);
        degistirmeListesi.Add("<%KargoAdi%>", Ortak.KargoFirmalari);
        degistirmeListesi.Add("<%TeslimatAdresi_AdSoyad%>", _Tes_AdSoyad);
        degistirmeListesi.Add("<%TeslimatAdresi_Adres%>", _Tes_Adres);
        degistirmeListesi.Add("<%TeslimatAdresi_Ilce%>", _Tes_Ilce);
        degistirmeListesi.Add("<%TeslimatAdresi_Sehir%>", _Tes_Sehir);
        degistirmeListesi.Add("<%TeslimatAdresi_CepTelefon%>", _Cep_Telefon);
        degistirmeListesi.Add("<%FaturaAdresi_AdSoyad%>", _Ft_AdSoyad);
        degistirmeListesi.Add("<%FaturaAdresi_Adres%>", _Ft_Adres);
        degistirmeListesi.Add("<%FaturaAdresi_Ilce%>", _Ft_Ilce);
        degistirmeListesi.Add("<%FaturaAdresi_Sehir%>", _Ft_Sehir);
        degistirmeListesi.Add("<%FaturaAdresi_CepTelefonu%>", _Cep_Telefon);
        string Siparis_Adres = Ortak.SiteAdresi_http + "/SiparisDetay-" + _SiparisNo + ".aspx";
        degistirmeListesi.Add("<%Sipari_Takip_Link%>", Siparis_Adres);
        string Hesabim_Adres = Ortak.SiteAdresi_http + "/Hesabim.aspx";
        degistirmeListesi.Add("<%Hesabim%>", Hesabim_Adres);
        string Iade_Adres = Ortak.SiteAdresi_http + "/IadeDegisimFormu.aspx";
        degistirmeListesi.Add("<%IadeFormu%>", Iade_Adres);
        degistirmeListesi.Add("<%SiteAdresi%>", Ortak.SiteAdresi_http);
        string mailTo = Ortak.EPosta_Gidicek_Adresler[0].ToString();
        MailMessage mailMesaj = mailTarifi.CreateMailMessage(mailTo, degistirmeListesi, this);
        mailMesaj.From = new MailAddress(Ortak.Eposta, Ortak.E_Ticaret_SiteAdi);
        mailMesaj.IsBodyHtml = true;
        mailMesaj.Subject = Ortak.SiteAdresiKısa + " Sipariş No(#" + _SiparisNo + ")";
        for (int i = 1; i < Ortak.Sepet_EPosta_Gidicek_Adresler.Length; i++)
        {
            mailMesaj.Bcc.Add(new MailAddress(Ortak.Sepet_EPosta_Gidicek_Adresler[i].ToString()));
        }
        //buradan sonrasını değiştirmedim, bildiğiniz gibi
        SmtpClient smtp = new SmtpClient(Ortak.MailServer, 587);
        smtp.Credentials = new NetworkCredential(Ortak.Eposta, Ortak.Sifre);
        smtp.Send(mailMesaj);
    }
}
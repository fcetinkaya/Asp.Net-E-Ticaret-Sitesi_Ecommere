using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_YeniSiparisler : System.Web.UI.Page
{
    public static string Aranacak;
    public static string[] Durumlar;
    cls_Hesabim cH = new cls_Hesabim();
    cls_Admin_SiparisIslemleri S = new cls_Admin_SiparisIslemleri();
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select Log_Index from E_Personel where IsActive=1 and Log_Index like '%" + prefixText + "%' group by Log_Index", conn))
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
                        customers.Add(sdr["Log_Index"].ToString());
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
                    label.Text = "Yeni Siparişler";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Yeni Sipariş Listesi";
                    Gel_Bildirimler_Hepsi();
                    Siparis_Durumu();
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
        DataTable dt = S.Liste_Gel();
        if (dt.Rows.Count != 0)
        {
            Urunler_Grid.DataSource = dt;
            Urunler_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
            ToplamAdetLbl.Text = dt.Rows.Count.ToString();
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            Urunler_Grid.DataBind();
        }
    }
    public void Gel_Bildirimler_Arama()
    {
        DataTable dt = S.Liste_Gel_Arama_Kriterine_Gore(Aranacak);
        if (dt.Rows.Count != 0)
        {
            Urunler_Grid.DataSource = dt;
            Urunler_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
            ToplamAdetLbl.Text = dt.Rows.Count.ToString();
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            Urunler_Grid.DataBind();
        }
    }
    private void Siparis_Durumu()
    {
        DataTable dt = S.Siparis_Durumu();
        DataRow dr = dt.NewRow();
        dr["DurumAd"] = "Sipariş Durum Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        SiparisDurumuDrop.DataSource = dt;
        SiparisDurumuDrop.DataValueField = "E_Siparis_DurumuID";
        SiparisDurumuDrop.DataTextField = "DurumAd";
        SiparisDurumuDrop.DataBind();
    }
    private void Guncelle_Siparis_Durumu()
    {
        DataTable dt = S.Siparis_Durumu();
        DataRow dr = dt.NewRow();
        Guncelle_SiparisDurumuDrop.DataSource = dt;
        Guncelle_SiparisDurumuDrop.DataValueField = "E_Siparis_DurumuID";
        Guncelle_SiparisDurumuDrop.DataTextField = "DurumAd";
        Guncelle_SiparisDurumuDrop.DataBind();
    }
    public void Siparis_Urunleri_Getir(string _Siparis_ID)
    {
        DataTable dt = S.Siparis_Sepet_Bilgileri(_Siparis_ID);
        if (dt.Rows.Count != 0)
        {
            Sepet_Datalist.DataSource = dt;
            Sepet_Datalist.DataBind();
        }
        else
        {
            Sepet_Datalist.DataBind();
        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Aranacak = "";
            if (SiparisDurumuDrop.SelectedIndex != 0)
            {
                Aranacak = " and E_SiparisTakip.DurumID=" + SiparisDurumuDrop.SelectedValue;
                Gel_Bildirimler_Arama();
            }
            if (OdemeSekli_Drop.SelectedIndex != 0)
            {
                Aranacak += " and E_SiparisTakip.OdemeTipi='" + OdemeSekli_Drop.SelectedItem.Text + "'";
                Gel_Bildirimler_Arama();
            }
            if (!string.IsNullOrEmpty(MusteriAdiBox.Text))
            {
                Aranacak += " and E_Personel.AdSoyad='" + Ortak.Encrypt(MusteriAdiBox.Text) + "'";
                Gel_Bildirimler_Arama();
            }
            if (!string.IsNullOrEmpty(SiparisNoBox.Text))
            {
                Aranacak += " and E_SiparisTakip.SiparisNoFiyat='" + SiparisNoBox.Text + "'";
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
    protected void Urunler_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Urunler_Grid.PageIndex = e.NewPageIndex;
        if (!string.IsNullOrEmpty(Aranacak))
        {
            Gel_Bildirimler_Arama();
        }
        else
        {
            Gel_Bildirimler_Hepsi();
        }
        Urunler_Grid.DataBind();
    }
    protected void Urunler_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Adi_soyadi = e.Row.FindControl("AdSoyadLbl") as Label;
            Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            ImageButton Kargo_Btn = (ImageButton)e.Row.FindControl("KargoBtn");
            ImageButton Kurye_Btn = (ImageButton)e.Row.FindControl("KuryeBtn");
            string Musteri_ID = dr.Row["UyeID"].ToString();
            string Siparis_ID = dr.Row["E_SiparisID"].ToString();
            Kargo_Btn.PostBackUrl = "KargoIslemleri.aspx?SiparisNoFiyat=" + Siparis_ID + "&AdSoyad=" + Musteri_ID;
            Kurye_Btn.PostBackUrl = "KuryeIslemleri.aspx?SiparisNoFiyat=" + Siparis_ID + "&AdSoyad=" + Musteri_ID;

        }
    }
    protected void DurumuDegistir_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            bool Sonuc = false;
            if (TamamDevamCheck.Checked == true)
            {
                Sonuc = true;
            }
            if (S.Siparisi_Durum_Degisim_ve_Kapat(Durumlar[0].ToString(), Guncelle_SiparisDurumuDrop.SelectedValue, Sonuc) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = "Durum " + Guncelle_SiparisDurumuDrop.SelectedItem.Text + " olarak güncellendi.";
                HataVar.Visible = false;
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
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void UrunlerBtn_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton U = sender as ImageButton;
            string Urunler_SiparisID = U.CommandArgument.ToString();
            Siparis_Urunleri_Getir(Urunler_SiparisID);
            Urunler_Modal.Show();
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void DurumChangeBtn_Click(object sender, EventArgs e)
    {
        try
        {
            TamamDevamCheck.Checked = false;
            Durumlar = new string[2];
            ImageButton G = sender as ImageButton;
            Durumlar[0] = G.CommandArgument.ToString();
            Durumlar[1] = G.AlternateText;
            Guncelle_Siparis_Durumu();
            Guncelle_SiparisDurumuDrop.SelectedItem.Text = Durumlar[1];
            DurumGuncelleme_MPE.Show();
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void SiparisDetay_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton U = sender as ImageButton;
            string Urunler_SiparisID = U.CommandArgument.ToString();
            string Musteri_ID = U.AlternateText.ToString();
            Siparis_Detayı_Urunleri_Getir(Urunler_SiparisID);
            Teslimat_Adres_Bilgileri_Getir(Musteri_ID);
            Fatura_Adres_Bilgileri_Getir(Musteri_ID);
            Siparis_Urunleri_Getir(Urunler_SiparisID);
            Siparis_Detay_Modal.Show();
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    public void Siparis_Detayı_Urunleri_Getir(string _Siparis_ID)
    {
        DataTable dt = S.Siparis_Sepet_Bilgileri(_Siparis_ID);
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
            ODeme_SepetFiyatLbl.Text = toplam.ToString() + " TL";
            Odeme_SepetKDVLbl.Text = KDV.ToString() + " TL";
            Odeme_GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
            if (toplam > Ortak.SepetIcinKargo_Degeri)
            {
                Odeme_KargoBedeliLbl.Text = "0.00 TL";
                Odeme_GenelToplamLbl.Text = (toplam + KDV).ToString() + " TL";
                double Havale_Hesap = (toplam + KDV) / 100 * Ortak.Odenecek_Havale_Indirim;
                double Havale_Toplam = toplam + KDV - Havale_Hesap;
                Odeme_HavaleOdeme.Text = string.Format("{0:0.00}", Havale_Toplam) + " TL";
            }
            else
            {
                Odeme_GenelToplamLbl.Text = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti).ToString() + " TL";
                double Havale_Hesap = (toplam + KDV + Ortak.Odenecek_Kargo_Ucreti) / 100 * Ortak.Odenecek_Havale_Indirim;
                double Havale_Toplam = toplam + KDV + Ortak.Odenecek_Kargo_Ucreti - Havale_Hesap;
                Odeme_HavaleOdeme.Text = string.Format("{0:0.00}", Havale_Toplam) + " TL";
            }
            Siparis_DetayDatalist.DataSource = dt;
            Siparis_DetayDatalist.DataBind();
        }
        else
        {
            Siparis_DetayDatalist.DataBind();
        }
    }
    public void Teslimat_Adres_Bilgileri_Getir(string Aydim_Tes)
    {
        string[] Gele_Teslimat = cH.Gonder_Teslimat_Adresi(Aydim_Tes);
        TckimlikNoLbl.Text = Gele_Teslimat[0].ToString();
        EPostaAdresiLbl.Text = Gele_Teslimat[1].ToString();
        CepTelefonLbl.Text = Gele_Teslimat[2].ToString();
        TelefonLbl.Text = Gele_Teslimat[3].ToString();
        AdresLbl.Text = Gele_Teslimat[6].ToString();
        SehirLbl.Text = Gele_Teslimat[7].ToString();
        IlceLbl.Text = Gele_Teslimat[8].ToString();
    }
    public void Fatura_Adres_Bilgileri_Getir(string Aydim_Fatura)
    {
        string[] Fatura_Gel = cH.Gonder_Fatura_Adresi(Aydim_Fatura);
        YetkiliAdSoyadLbl.Text = Fatura_Gel[0].ToString();
        FirmaAdiLbl.Text = Fatura_Gel[1].ToString();
        VergiDairesiLbl.Text = Fatura_Gel[2].ToString();
        VergiNoLbl.Text = Fatura_Gel[3].ToString();
        FirmaAdresLbl.Text = Fatura_Gel[6].ToString();
        FirmaSehirLbl.Text = Fatura_Gel[8].ToString();
        FirmaIlceLbl.Text = Fatura_Gel[9].ToString();

    }
    protected void Siparis_DetayDatalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink Resimlink = (HyperLink)e.Item.FindControl("Resim");
            Resimlink.NavigateUrl = "../" + Resimlink.NavigateUrl.ToString();
            Image Logo = (Image)e.Item.FindControl("Logo");
            Logo.ImageUrl = "../" + Logo.ImageUrl.ToString();
            HyperLink Urun_Adi = (HyperLink)e.Item.FindControl("UrunAdi");
            Urun_Adi.NavigateUrl = "../" + Urun_Adi.NavigateUrl.ToString();
        }
    }
    protected void Sepet_Datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink Resimlink = (HyperLink)e.Item.FindControl("Resim");
            Resimlink.NavigateUrl = "../" + Resimlink.NavigateUrl.ToString();
            Image Logo = (Image)e.Item.FindControl("Logo");
            Logo.ImageUrl = "../" + Logo.ImageUrl.ToString();
            HyperLink Urun_Adi = (HyperLink)e.Item.FindControl("UrunAdi");
            Urun_Adi.NavigateUrl = "../" + Urun_Adi.NavigateUrl.ToString();
        }
    }
}
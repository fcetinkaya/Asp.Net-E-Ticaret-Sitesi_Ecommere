using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiparisDetay : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    cls_Siparis cS = new cls_Siparis();
    cls_Hesabim cH = new cls_Hesabim();
    private static string Gelen_SiparisNo;
    private static string GelenID, SiparisID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["E_ticaretim"] != null)
            {
                string[] Gelenler = (string[])Session["E_ticaretim"];
                GelenID = Gelenler[0].ToString();
                AdSoyadLbl.Text = Gelenler[1].ToString();
                if (!IsPostBack)
                {
                    if (RouteData.Values["SiparisNo"] != null)
                    {
                        Gelen_SiparisNo = RouteData.Values["SiparisNo"].ToString();
                        SiparisID = cS.Gel_Siparis_ID(Gelen_SiparisNo);
                        SiparisNoLbl.Text = Gelen_SiparisNo;
                        Siparis_Sepet_Getir();
                        Gel_Siparis_Detayi();
                        Fatura_Adres_Bilgileri_Getir(GelenID);
                        Teslimat_Adres_Bilgileri_Getir(GelenID);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
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
    private void Siparis_Sepet_Getir()
    {
        DataTable dt = cS.Siparis_Sepet_Bilgileri(SiparisID, GelenID);
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
            Sepet_Datalist.DataSource = dt;
            Sepet_Datalist.DataBind();
        }
        else
        {
            Sepet_Datalist.DataBind();
        }
    }
    private void Gel_Siparis_Detayi()
    {
        DataTable dt = cS.GelSiparisler_SiparisDetay(Gelen_SiparisNo, GelenID);
        if (dt.Rows.Count != 0)
        {
            SiparisListesi_DataList.DataSource = dt;
            SiparisListesi_DataList.DataBind();
        }
        else
        {
            SiparisListesi_DataList.DataBind();
        }
    }
    protected void SiparisListesi_DataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string Sno = DataBinder.Eval(e.Item.DataItem, "SiparisNo").ToString();
            HyperLink Sdetay = e.Item.FindControl("DetayID") as HyperLink;
            Sdetay.NavigateUrl = "KargoDetay-" + Sno.ToString() + ".aspx";
        }
    }
}
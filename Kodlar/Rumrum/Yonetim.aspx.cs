using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim : System.Web.UI.Page
{
    cls_Admin_Yonetim Y = new cls_Admin_Yonetim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["eticaret"] != null)
        {
            if (!IsPostBack)
            {
                Label label = Master.FindControl("UrlMaplbl") as Label;
                label.Text = "Yönetim Paneli";
                Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                label2.Text = "Yönetim Paneli";
                Uye_Istatistikleri();
                Siparis_Istatistikleri();
                Hasilat_Istatistikleri();
                Yeni_Siparis_Listesi();
                Odeme_Bildirim_Listesi();
                Iade_Degisim_Bildirimleri();
                int Gelen_MesajAdeti = Y.Mesaj_Adeti();
                if (Gelen_MesajAdeti > 0)
                {
                    YeniMesaj_alert.Visible = true;
                    MesajAdetiLbl.Text = Gelen_MesajAdeti.ToString() + " Yeni Mesaj Var";
                }
                int Gelen_Beni_Ara = Y.Beni_Ara_Adeti();
                if (Gelen_Beni_Ara > 0)
                {
                    AramaTalebi_Alert.Visible = true;
                    BeniAraAdetLbl.Text = Gelen_Beni_Ara.ToString() + " Yeni Arama Talebi Var";
                }
                int Gelen_Urun_Talep = Y.Urun_Talep_Adeti();
                if (Gelen_Urun_Talep > 0)
                {
                    UrunTalep_Alet.Visible = true;
                    UrunTalepAdetLbl.Text = Gelen_Urun_Talep.ToString()+" Yeni Ürün Talebi Var";
                }
            }
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    public void Uye_Istatistikleri()
    {
        int[] Uyeler = Y.Uye_Istatistikleri();
        BugunUyeLbl.Text = Uyeler[0].ToString();
        BuAyUyeLbl.Text = Uyeler[1].ToString();
        BuYilUyeLbl.Text = Uyeler[2].ToString();
        ToplamUyeLbl.Text = Uyeler[3].ToString();
    }
    public void Siparis_Istatistikleri()
    {
        int[] Siparis = Y.Siparis_Istatistikleri();
        BugunSiparisLbl.Text = Siparis[0].ToString();
        BuAySiparisLbl.Text = Siparis[1].ToString();
        BuYilSiparisLbl.Text = Siparis[2].ToString();
        ToplamSiparislbl.Text = Siparis[3].ToString();
    }
    public void Hasilat_Istatistikleri()
    {
        double[] Hasilat = Y.Hasilat_Istatistikleri();
        BugunHasilatlbl.Text = Hasilat[0].ToString("#,#.00");
        BuAyHasilatLbl.Text = Hasilat[1].ToString("#,#.00"); ;
        BuYilHasilatlbl.Text = Hasilat[2].ToString("#,#.00");
        ToplamHasilatLbl.Text = Hasilat[3].ToString("#,#.00");
    }
    public void Yeni_Siparis_Listesi()
    {
        DataTable dt = Y.Yeni_Siparisler();
        if (dt.Rows.Count != 0)
        {
            YeniSiparisYok_Div.Visible = false;
            YeniSiparisler.DataSource = dt;
            YeniSiparisler.DataBind();
        }
        else
        {
            YeniSiparisler.DataBind();
            YeniSiparisYok_Div.Visible = true;
        }
    }
    public void Odeme_Bildirim_Listesi()
    {
        DataTable dt = Y.Odeme_Bildirim();
        if (dt.Rows.Count != 0)
        {
            Odeme_Yok_Div.Visible = false;
            OdemeBildirim_Repeater.DataSource = dt;
            OdemeBildirim_Repeater.DataBind();
        }
        else
        {
            OdemeBildirim_Repeater.DataBind();
            Odeme_Yok_Div.Visible = true;
        }
    }
    public void Iade_Degisim_Bildirimleri()
    {
        DataTable dt = Y.Iade_Degisim_Bildirim();
        if (dt.Rows.Count != 0)
        {
            IadeDegisimYok.Visible = false;
            IadeDegisim_Repeater.DataSource = dt;
            IadeDegisim_Repeater.DataBind();
        }
        else
        {
            IadeDegisim_Repeater.DataBind();
            IadeDegisimYok.Visible = true;
        }
    }
    protected void OdemeBildirim_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Button Detay = e.Item.FindControl("Odeme_DetayBtn") as Button;
            Label AdSoyadi = e.Item.FindControl("AdSoyadLbl") as Label;
            AdSoyadi.Text = Ortak.Decrypt(AdSoyadi.Text);
            string Aydi = DataBinder.Eval(e.Item.DataItem, "Odeme_BildirimID").ToString();
            Detay.PostBackUrl = "OdemeBildirimleri.aspx?ID=" + Ortak.Encrypt(Aydi);
        }
    }
    protected void IadeDegisim_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Button Detay = e.Item.FindControl("Iade_DetayBtn") as Button;
            string Aydi = DataBinder.Eval(e.Item.DataItem, "Iade_DegisimID").ToString();
            Detay.PostBackUrl = "IadeDegisimBildirimleri.aspx?ID=" + Ortak.Encrypt(Aydi);
        }
    }
}
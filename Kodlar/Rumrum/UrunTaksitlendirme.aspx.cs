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

public partial class Rumrum_UrunTaksitlendirme : System.Web.UI.Page
{
    public static int GelID;
    cls_Admin_UrunTaksitlendirme T = new cls_Admin_UrunTaksitlendirme();
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
                    label.Text = "Ürün Taksitlendirme";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Ürün Taksitlendirme İşlemleri";
                    BankaGel();
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
    public void Gel_Bilgi_Taksitler(string _Gelen_ID)
    {
        DataTable dt = T.UrunDetay_Taksitlendirme_Getir(_Gelen_ID);
        if (dt.Rows.Count != 0)
        {
            TaksitYok.Visible = false;
            KayitliTaksitler.Visible = true;
            silBtn.Visible = true;
            TaksitRepeater.DataSource = dt;
            TaksitRepeater.DataBind();
        }
        else
        {
            TaksitYok.Visible = true;
            KayitliTaksitler.Visible = false;
            silBtn.Visible = false;
            TaksitRepeater.DataBind();
        }
    }
    private void BankaGel()
    {
        DataTable dt = cls_DataAdaptore.Banka_Getir();
        if (dt != null)
        {
            DataRow dr = dt.NewRow();
            dr["BankaAdi"] = "Lütfen Banka Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            bankalarDrop.DataSource = dt;
            bankalarDrop.DataTextField = "BankaAdi";
            bankalarDrop.DataValueField = "E_BankaID";
            bankalarDrop.DataBind();
        }
    }
    protected void urunBilgileriniGetirBtn_Click(object sender, EventArgs e)
    {
        try
        {
            GelID = T.Urun_Arama_Turn_ID(UrunAdiBox.Text);
            if (GelID > 0)
            {
                Details.Visible = true;
                Urunyok.Visible = false;
                HataVar.Visible = false;
                KayitTamam.Visible = false;
                TaksitEkleme_Article.Visible = true;
                Gel_Bilgi_Taksitler(GelID.ToString());
                string[] Geldi = T.Urun_Link_Fiyat_Turn(GelID.ToString());
                UrunFiyatiLbl.Text = Geldi[0] + " TL";
            }
            else
            {
                Details.Visible = false;
                Urunyok.Visible = true;
                HataVar.Visible = false;
                KayitTamam.Visible = false;
                TaksitEkleme_Article.Visible = false;
            }
        }
        catch (Exception)
        {
            HataVar.Visible = true;
            KayitTamam.Visible = false;

        }
    }
    protected void silBtn_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList dizi = new ArrayList();
            foreach (RepeaterItem item in TaksitRepeater.Items)
            {
                CheckBox c = (CheckBox)item.FindControl("ResimCheck");
                if (c.Checked)
                {
                    HiddenField ID = (HiddenField)item.FindControl("TaksitID");
                    dizi.Add(ID.Value);
                }
            }
            if (dizi.Count != 0)
            {
                for (int i = 0; i < dizi.Count; i++)
                {
                    T.Urun_Taksitleri_Delete(dizi[i].ToString(), GelID.ToString());
                }
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = dizi.Count.ToString() + " adet taksit başarı ile silinmiştir.";
                HataVar.Visible = false;
                Gel_Bilgi_Taksitler(GelID.ToString());

            }
            else
            {
                KayitTamam.Visible = false;
                HataLbl.Text = "Silmek istediğiniz taksit(leri) seçiniz.";
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            HataVar.Visible = true;
        }
    }
    protected void TaksitEkleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (T.Taksit_Kontrol(bankalarDrop.SelectedValue) == false)
            {
                double TaksitSayisi = Convert.ToDouble(TaksitSayisiDrop.SelectedValue);
                int TaksitAdeti = Convert.ToInt32(TaksitSayisiDrop.SelectedValue);
                string[] Geldi = T.Urun_Link_Fiyat_Turn(GelID.ToString());
                double Gelen_fiyat = Convert.ToDouble(Geldi[0]);
                UrunKontrolLink.NavigateUrl = "../" + Geldi[1].ToString();
                //   Gelen_fiyat = Math.Round(Gelen_fiyat, 2);
                for (int i = 2; i <= TaksitAdeti; i++)
                {
                    double Taksit_Ucreti = Gelen_fiyat / i;
                    Taksit_Ucreti = Math.Round(Taksit_Ucreti, 2);
                    T.Urun_Taksitleri_Ekle(GelID.ToString(), bankalarDrop.SelectedValue, i.ToString(), Taksit_Ucreti.ToString(), UrunFiyatiLbl.Text);
                }
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = bankalarDrop.SelectedItem.Text + " / " + TaksitSayisiDrop.SelectedItem.Text + " Taksit  eklenmiştir.";
                Gel_Bilgi_Taksitler(GelID.ToString());
            }
            else
            {
                Ortak.MesajGoster("Banka ile ilgili taksit kaydı vardır. Yeni kayıt için önceki kayıtları siliniz.");
            }
        }
        catch (Exception)
        {
            HataVar.Visible = true;
        }
    }
    protected void bankalarDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (bankalarDrop.SelectedIndex != 0)
        {
            TaksitSayisiDrop.Items.Clear();
            int Gelen_Taksit = cls_DataAdaptore.Banka_Taksit_Getir(bankalarDrop.SelectedValue);
            TaksitSayisiDrop.Items.Add(new ListItem("Lütfen Taksit Seçiniz", "0"));
            for (int i = 1; i <= Gelen_Taksit; i++)
            {
                TaksitSayisiDrop.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
}
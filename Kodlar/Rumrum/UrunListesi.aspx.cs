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

public partial class Rumrum_UrunListesi : System.Web.UI.Page
{
    cls_Admin_KategoriIslemleri K = new cls_Admin_KategoriIslemleri();
    cls_Admin_UrunListesi UL = new cls_Admin_UrunListesi();
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
                    label.Text = "Ürünler Listesi";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Kayıtlı Ürünler Listesi";
                    Gel_Urunler();
                    TelefonMarkaGetir();
                    KategoriGetir_Getir();

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
            //  Ortak.MesajGoster("Hata!! Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    public void Gel_Urunler()
    {
        DataTable dt = UL.Liste_Gel();
        if (dt.Rows.Count != 0)
        {
            Urunler_Grid.DataSource = dt;
            Urunler_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            Urunler_Grid.DataBind();
        }
    }
    public void Gel_Urunler_Arama_Kriterine_Gore(string _Aramaci)
    {
        DataTable dt = UL.Liste_Gel_Arama_Kriterine_Gore(_Aramaci);
        if (dt.Rows.Count != 0)
        {
            Urunler_Grid.DataSource = dt;
            Urunler_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            Urunler_Grid.DataBind();
        }
    }
    protected void Urunler_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Urunler_Grid.PageIndex = e.NewPageIndex;
        Gel_Urunler();
        Urunler_Grid.DataBind();
    }
    protected void Urunler_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        string Link = Ortak.Encrypt(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "Edit":
                ImageButton Duzenle = (ImageButton)gvRow.FindControl("DuzenleBtn");
                Duzenle.PostBackUrl = "UrunDuzenleme.aspx?ID=" + Link.ToString();
                break;
            case "Delete":
                ImageButton Delete = (ImageButton)gvRow.FindControl("DuzenleBtn");
                Delete.PostBackUrl = "UrunSilme.aspx?ID=" + Link.ToString();
                break;

        }
    }
    protected void Urunler_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            string Adi = Ortak.Encrypt(dr["UrunAdi"].ToString());
            string UrunID = Ortak.Encrypt(dr["UrunID"].ToString());
            string Link = dr["Link"].ToString();
            bool Indirimci = Convert.ToBoolean(dr["Indirimli"]);
            bool Tukendi = Convert.ToBoolean(dr["Tukendi"]);
            bool Satis_Iptal = Convert.ToBoolean(dr["SatisIptal"]);
            HyperLink Duzenle = e.Row.FindControl("DuzenleBtn") as HyperLink;
            Duzenle.NavigateUrl = "UrunDuzenleme.aspx?ID=" + UrunID.ToString();
            HyperLink DeleteBtn = e.Row.FindControl("DeleteBtn") as HyperLink;
            DeleteBtn.NavigateUrl = "UrunSilme.aspx?ID=" + UrunID.ToString();
            HyperLink KopyalaBtn = e.Row.FindControl("KopyalaBtn") as HyperLink;
            KopyalaBtn.NavigateUrl = "UrunKopyalama.aspx?ID=" + UrunID.ToString();
            HyperLink ResimlerBtn = e.Row.FindControl("ResimlerBtn") as HyperLink;
            ResimlerBtn.NavigateUrl = "UrunResimleriEkleme.aspx?ID=" + UrunID.ToString();
            HyperLink Onizleme = e.Row.FindControl("WebBtn") as HyperLink;
            Onizleme.NavigateUrl = "../" + Link;
            //Ürün Detay İşlemleri
            Label IndirimVar_mi = e.Row.FindControl("IndirimVarmiLbl") as Label;
            IndirimVar_mi.Text = "Hayır";
            if (Indirimci == true)
            {
                IndirimVar_mi.Text = "Evet";
            }
            Label Tukendi_mi = e.Row.FindControl("TukendimiLbl") as Label;
            Tukendi_mi.Text = "Stokta Var";
            if (Tukendi == true)
            {
                Tukendi_mi.Text = "Stokda Yok";
            }
            Label Satis_Iptal_mi = e.Row.FindControl("SatisDurumuLbl") as Label;
            Satis_Iptal_mi.Text = "Devam Ediyor.";
            if (Satis_Iptal == true)
            {
                Satis_Iptal_mi.Text = "Satışı İptal";
            }
        }
    }
    protected void AnaKategoriDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AnaKategoriDrop.SelectedIndex != 0)
        {
            //   AramaKriter.Show();
            AltKategoriDrop.Items.Clear();
            string Ana_KategoriID = AnaKategoriDrop.SelectedValue;
            AltKategoriDrop.Enabled = true;
            AnaKategori_Gore_AltKategori(Ana_KategoriID);
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "document.getElementById('AramaPopup').style.display = 'block';", true);
            }
        }
    }
    protected void TelefonDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TelefonDrop.SelectedIndex != 0)
        {
            // AramaKriter.Show();
            ModelDrop.Items.Clear();
            string SeciliTelefonID = TelefonDrop.SelectedValue;
            ModelDrop.Enabled = true;
            TelefonaGore_ModelGetir(SeciliTelefonID);
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "document.getElementById('AramaPopup').style.display = 'block';", true);
            }
        }
    }
    private void TelefonMarkaGetir()
    {
        DataTable dt = cls_DataAdaptore.Telefon_Marka();
        DataRow dr = dt.NewRow();
        dr["TelAdi"] = "Telefon Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        TelefonDrop.DataSource = dt;
        TelefonDrop.DataValueField = "TelefonID";
        TelefonDrop.DataTextField = "TelAdi";
        TelefonDrop.DataBind();
    }
    private void TelefonaGore_ModelGetir(string GelenID)
    {
        DataTable dt = cls_DataAdaptore.Telefon_Marka_Model(GelenID);
        DataRow dr = dt.NewRow();
        dr["ModelAdi"] = "Model Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        ModelDrop.DataSource = dt;
        ModelDrop.DataValueField = "TelefonModelID";
        ModelDrop.DataTextField = "ModelAdi";
        ModelDrop.DataBind();
    }
    private void KategoriGetir_Getir()
    {
        DataTable dt = cls_DataAdaptore.Ana_Kategori_Getir();
        DataRow dr = dt.NewRow();
        dr["AnaKategoriAdi"] = "Ana Kategori Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        AnaKategoriDrop.DataSource = dt;
        AnaKategoriDrop.DataValueField = "AnaKategoriID";
        AnaKategoriDrop.DataTextField = "AnaKategoriAdi";
        AnaKategoriDrop.DataBind();
    }
    private void AnaKategori_Gore_AltKategori(string GelenID)
    {
        DataTable dt = K.Alt_Kategori_For_AnaKategoriList(GelenID);
        if (dt.Rows.Count != 0)
        {
            DataRow dr = dt.NewRow();
            dr["KategoriAdi"] = "Alt Kategori Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            AltKategoriDrop.DataSource = dt;
            AltKategoriDrop.DataValueField = "KategoriID";
            AltKategoriDrop.DataTextField = "KategoriAdi";
            AltKategoriDrop.DataBind();
        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        string _Aranacaklar = "";
        if (!string.IsNullOrEmpty(UrunAdiBox.Text))
        {
            _Aranacaklar += "and UrunAdi='" + UrunAdiBox.Text + "'";
        }
        if (AnaKategoriDrop.SelectedIndex != 0 && AltKategoriDrop.SelectedIndex != 0)
        {
            _Aranacaklar += " and KatID=" + AltKategoriDrop.SelectedValue;

        }
        if (TelefonDrop.SelectedIndex != 0)
        {
            _Aranacaklar += " and TelefonID=" + TelefonDrop.SelectedValue;

        }
        if (TelefonDrop.SelectedIndex != 0 && ModelDrop.SelectedIndex != 0)
        {
            _Aranacaklar += " and TelefonModelID=" + ModelDrop.SelectedValue;
        }
        Gel_Urunler_Arama_Kriterine_Gore(_Aranacaklar);
    }
}
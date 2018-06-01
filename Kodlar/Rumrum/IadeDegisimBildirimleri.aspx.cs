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

public partial class Rumrum_IadeDegisimBildirimleri : System.Web.UI.Page
{
    public static string Gelen_Aydi, Aranacak;
    cls_Admin_IadeDegisim IA = new cls_Admin_IadeDegisim();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "İade / Değişim Bildirimleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "İade / Değişim  Bildirimleri";
                    if (Request.QueryString["ID"] != null)
                    {
                        Gelen_Aydi = Request.QueryString["ID"].ToString();
                        Gelen_Aydi = Ortak.Decrypt(Gelen_Aydi);
                        Gel_Bildirimler(Gelen_Aydi);
                    }
                    else
                    {
                        Gel_Bildirimler_Hepsi();
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
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    public void Gel_Bildirimler(string _Bildirim_Aydi)
    {
        DataTable dt = IA.Iade_Degisim(_Bildirim_Aydi);
        if (dt.Rows.Count != 0)
        {
            AltKategori_Grid.DataSource = dt;
            AltKategori_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            AltKategori_Grid.DataBind();
        }
    }
    public void Gel_Bildirimler_Hepsi()
    {
        DataTable dt = IA.Iade_Degisim_Tumu();
        if (dt.Rows.Count != 0)
        {
            AltKategori_Grid.DataSource = dt;
            AltKategori_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            AltKategori_Grid.DataBind();
        }
    }
    private void Odeme_Bildirimleri_Arama()
    {
        DataTable dt = IA.Iade_Degisim_Arama_Kriter(Aranacak);
        if (dt.Rows.Count != 0)
        {
            AltKategori_Grid.DataSource = dt;
            AltKategori_Grid.DataBind();
            Alt_GridKayitYokDiv.Visible = false;
        }
        else
        {
            Alt_GridKayitYokDiv.Visible = true;
            AltKategori_Grid.DataBind();
        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Aranacak = "";
            if (!string.IsNullOrEmpty(MusteriAdi_Box.Text))
            {
                Aranacak = "E_Personel.Log_Index='" + MusteriAdi_Box.Text + "'";
                Odeme_Bildirimleri_Arama();
            }
            else
            {
                Ortak.MesajGoster("Müşteri adını ve soyadını yazınız.");
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void AltKategori_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AltKategori_Grid.PageIndex = e.NewPageIndex;
        if (!string.IsNullOrEmpty(Aranacak))
        {
            Odeme_Bildirimleri_Arama();
        }
        else
        {
            Gel_Bildirimler_Hepsi();
        }
        //  Gel_Urunler();
        AltKategori_Grid.DataBind();
    }
    protected void AltKategori_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Kapat")
        {
            if (IA.Bildirimi_Kapat(e.CommandArgument.ToString()) == true)
            {
                if (!string.IsNullOrEmpty(Aranacak))
                {
                    Odeme_Bildirimleri_Arama();
                }
                else
                {
                    Gel_Bildirimler_Hepsi();
                }
                Ortak.MesajGoster("Bildirim Kapatıldı.");
            }
        }
        else
        {
            if (IA.Bildirimi_Ac(e.CommandArgument.ToString()) == true)
            {
                if (!string.IsNullOrEmpty(Aranacak))
                {
                    Odeme_Bildirimleri_Arama();
                }
                else
                {
                    Gel_Bildirimler_Hepsi();
                }
                Ortak.MesajGoster("Bildirim Açıldı.");
            }
        }
    }
    protected void AltKategori_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Adi_soyadi = e.Row.FindControl("lblMusteriAdi") as Label;
            Label Adi_soyadi_Detay = e.Row.FindControl("lblMusteriAdi_detay") as Label;
            LinkButton Kapat = e.Row.FindControl("KapatBtn") as LinkButton;
            LinkButton Ac = e.Row.FindControl("AcBtn") as LinkButton;
            Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            Adi_soyadi_Detay.Text =Adi_soyadi.Text;
            bool Tukendi = Convert.ToBoolean(dr["IslemTamam"]);
            if (Tukendi == true)
            {
                Ac.Visible = true;
                Kapat.Visible = false;
            }
            else
            {
                Ac.Visible = false;
                Kapat.Visible = true;
            }
        }
    }
}
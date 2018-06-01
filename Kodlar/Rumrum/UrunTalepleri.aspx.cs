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

public partial class Rumrum_UrunTalepleri : System.Web.UI.Page
{
    cls_Admin_UrunTalepleri U = new cls_Admin_UrunTalepleri();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "Ürün Talep Bildirimleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Ürün Talep Bildirimleri";
                    Gel_Bildirimler_Hepsi();
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
        DataTable dt = U.Urun_Talepleri();
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
            if (!string.IsNullOrEmpty(EPostaAdresi_box.Text))
            {
                DataTable dt = U.Urun_Talepleri_Arama_Kriter(EPostaAdresi_box.Text);
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
        Gel_Bildirimler_Hepsi();
        AltKategori_Grid.DataBind();
    }
    protected void AltKategori_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Kapat")
        {
            if (U.Bildirimi_Kapat(e.CommandArgument.ToString()) == true)
            {
                Gel_Bildirimler_Hepsi();
                Ortak.MesajGoster("Bildirim Kapatıldı.");
            }
        }
        else
        {
            if (U.Bildirimi_Ac(e.CommandArgument.ToString()) == true)
            {
                Gel_Bildirimler_Hepsi();
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
            Label EPosta = e.Row.FindControl("lblEpostaAdi") as Label;
            LinkButton Kapat = e.Row.FindControl("KapatBtn") as LinkButton;
            LinkButton Ac = e.Row.FindControl("AcBtn") as LinkButton;
            if (!string.IsNullOrEmpty(Adi_soyadi.Text))
            {
                Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            }
            else
            {
                Adi_soyadi.Text = "İsimsiz Ziyaretçi";
            }
            EPosta.Text = Ortak.Decrypt(EPosta.Text);
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
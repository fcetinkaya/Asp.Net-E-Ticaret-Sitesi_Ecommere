using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_KategoriDuzenleme : System.Web.UI.Page
{
    cls_Admin_KategoriIslemleri K = new cls_Admin_KategoriIslemleri();
    public static string SecilenUst_Kat;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["eticaret"] != null)
        {
            if (!IsPostBack)
            {
                Label label = Master.FindControl("UrlMaplbl") as Label;
                label.Text = "Kategori Düzenleme";
                Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                label2.Text = "Kategori Düzenleme İşlemleri";
                Ana_GelListe();
                Alt_GelListe();
                Alt_Liste_DropDown();
            }
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    public void Ana_GelListe()
    {
        try
        {
            DataTable dt = K.Ana_Kategori_List();
            if (dt.Rows.Count != 0)
            {
                AnaKategori_Grid.DataSource = dt;
                AnaKategori_Grid.DataBind();
                GridKayitYokDiv.Visible = false;
            }
            else
            {
                GridKayitYokDiv.Visible = true;
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void AnaKategori_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AnaKategori_Grid.EditIndex = -1;
        Ana_GelListe();
    }
    protected void AnaKategori_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AnaKategori_Grid.EditIndex = e.NewEditIndex;
        Ana_GelListe();
    }
    public string KarekterDegistir(string HaberAdi)
    {
        //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
        string Temp = HaberAdi.ToLower();
        Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "-");
        Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
        Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
        Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
        Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
        Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
        Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
        Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
        Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
        Temp = Temp.Replace("?", ""); Temp = Temp.Replace(".", "_");
        Temp = Temp.Replace("ı", "i");
        return Temp;
    }
    protected void AnaKategori_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)AnaKategori_Grid.Rows[e.RowIndex];
        TextBox KatAdiBox = row.FindControl("EditKategoriAdiBox") as TextBox;
        ImageButton upd = row.FindControl("GuncelleBtn") as ImageButton;
        int Aydi = (int)AnaKategori_Grid.DataKeys[e.RowIndex].Value;
        if (K.AnaKategori_Update(KatAdiBox.Text, KarekterDegistir(KatAdiBox.Text), Aydi.ToString()) == true)
        {
            AnaKategori_Grid.EditIndex = -1;
            KayitTamam.Visible = true;
            KayitTamamLbl.Text = KatAdiBox.Text + "  kategorisi başara ile güncellendi.";
            HataVar.Visible = false;
            Ana_GelListe();
        }
        else
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
            AnaKategori_Grid.EditIndex = -1;
            Ana_GelListe();
        }
    }
    protected void AnaKategori_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Aydi = (int)AnaKategori_Grid.DataKeys[e.RowIndex].Value;
            GridViewRow row = AnaKategori_Grid.Rows[e.RowIndex];
            Label KategoriLbl = (Label)row.FindControl("lblKategoriAdi");
            string Kategori_Adi = KategoriLbl.Text;
            if (K.AnaKategori_Is_Delete(Aydi.ToString()) == false)
            {
                if (K.AnaKategori_Delete(Aydi.ToString()) == true)
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = Kategori_Adi + " kategori başarı ile silindi.";
                    HataVar.Visible = false;
                    Ana_GelListe();
                }
                else
                {
                    KayitTamam.Visible = false;
                    HataVar.Visible = true;
                }
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
                HataLbl.Text = "Bu kategoriyi Silemezsiniz. Kategori işlem görüyor.";
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
            //  Ortak.MesajGoster("Hata!! Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void AnaKategori_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AnaKategori_Grid.PageIndex = e.NewPageIndex;
        Ana_GelListe();
        AnaKategori_Grid.DataBind();
    }
    //Alt Kategori
    public void Alt_Liste_DropDown()
    {
        try
        {
            DataTable dt = K.Ana_Kategori_List();
            if (dt.Rows.Count != 0)
            {
                anaKategoriDrop.Items.Clear();
                DataRow dr = dt.NewRow();
                dr["AnaKategoriAdi"] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                anaKategoriDrop.DataSource = dt;
                anaKategoriDrop.DataTextField = "AnaKategoriAdi";
                anaKategoriDrop.DataValueField = "AnaKategoriID";
                anaKategoriDrop.DataBind();
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    public void Alt_GelListe()
    {
        try
        {
            DataTable dt = K.Alt_Kategori_AllList();
            if (dt.Rows.Count != 0)
            {
                AltKategori_Grid.DataSource = dt;
                AltKategori_Grid.DataBind();
                Alt_GridKayitYokDiv.Visible = false;
            }
            else
            {
                Alt_GridKayitYokDiv.Visible = true;
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
        Alt_GelListe();
        AltKategori_Grid.DataBind();
    }
    protected void AltKategori_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AltKategori_Grid.EditIndex = -1;
        Alt_GelListe();
    }
    protected void AltKategori_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Aydi = (int)AltKategori_Grid.DataKeys[e.RowIndex].Value;
            GridViewRow row = AltKategori_Grid.Rows[e.RowIndex];
            Label KategoriLbl = (Label)row.FindControl("Alt_lblKategoriAdi");
            string Kategori_Adi = KategoriLbl.Text;
            if (K.Kategori_Delete(Aydi.ToString()) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = Kategori_Adi + " kategori başarı ile silindi.";
                HataVar.Visible = false;
                Alt_GelListe();
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
    protected void AltKategori_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            AltKategori_Grid.EditIndex = e.NewEditIndex;
            if (!string.IsNullOrEmpty(SecilenUst_Kat))
            {
                Gel_AnaKategoriyeGore();
            }
            else
            {
                Alt_GelListe();
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void AltKategori_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)AltKategori_Grid.Rows[e.RowIndex];
        TextBox KatAdiBox = row.FindControl("EditKategoriAdiBox") as TextBox;
        ImageButton upd = row.FindControl("GuncelleBtn") as ImageButton;
        DropDownList ddList = (DropDownList)row.FindControl("anaKategoriDrop");
        string UstKateGoID = ddList.SelectedValue;
        string KatID = upd.CommandArgument.ToString();
        if (K.Kategori_Update(KatAdiBox.Text, KarekterDegistir(KatAdiBox.Text), UstKateGoID, KatID) == true)
        {
            AltKategori_Grid.EditIndex = -1;
            KayitTamam.Visible = true;
            KayitTamamLbl.Text = KatAdiBox.Text + "  kategorisi başara ile güncellendi.";
            HataVar.Visible = false;
            Alt_GelListe();
        }
        else
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
            AltKategori_Grid.EditIndex = -1;
        }
    }
    protected void anaKategoriDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (anaKategoriDrop.SelectedIndex != 0)
        {
            Gel_AnaKategoriyeGore();
        }
    }
    private void Gel_AnaKategoriyeGore()
    {
        SecilenUst_Kat = anaKategoriDrop.SelectedValue;
        DataTable dt = K.Alt_Kategori_For_AnaKategoriList(SecilenUst_Kat);
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
    protected void AltKategori_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("anaKategoriDrop");
                //bind dropdownlist
                DataTable dt = K.Ana_Kategori_List();
                ddList.DataSource = dt;
                ddList.DataTextField = "AnaKategoriAdi";
                ddList.DataValueField = "AnaKategoriID";
                ddList.DataBind();

                DataRowView dr = e.Row.DataItem as DataRowView;
                //ddList.SelectedItem.Text = dr["YourCOLName"].ToString();
                ddList.SelectedValue = dr["AnaKategoriID"].ToString();
            }
        }
    }
}
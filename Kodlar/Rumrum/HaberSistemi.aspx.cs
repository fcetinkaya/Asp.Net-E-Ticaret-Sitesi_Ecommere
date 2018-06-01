using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_HaberSistemi : System.Web.UI.Page
{
    cls_Admin_HaberSlide H = new cls_Admin_HaberSlide();
    public static string Geliyor_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "Haber İşlemleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Anasayfa Haber İşlemleri";
                    GelListe();
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
    public void GelListe()
    {
        DataTable dt = H.Haberler();
        if (dt.Rows.Count != 0)
        {
            HaberSlider_Grid.DataSource = dt;
            HaberSlider_Grid.DataBind();
            GridKayitYokDiv.Visible = false;
        }
        else
        {
            GridKayitYokDiv.Visible = true;
            HaberSlider_Grid.DataBind();
        }
        SiralamaDrop.Items.Clear();
        int Adet = H.Haber_Adeti();
        for (int i = 1; i <= Adet; i++)
        {
            SiralamaDrop.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        }
    }
    protected void SiramaBtn_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton Sirama = sender as ImageButton;
            Geliyor_ID = Sirama.AlternateText;
            this.mpe.Show();
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void HaberekleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileExt = System.IO.Path.GetExtension(UploadImages.FileName);
            if (strFileExt.ToUpper() == ".JPG" || strFileExt.ToUpper() == ".GIF" || strFileExt.ToUpper() == ".PNG")
            {
                string KaydedilecekLogo = Guid.NewGuid().ToString() + UploadImages.FileName;
                UploadImages.SaveAs(Server.MapPath("../HaberResim/" + KaydedilecekLogo));
                string Kayit_ResimAd = "HaberResim/" + KaydedilecekLogo;
                int sira = 1;
                if (HaberSlider_Grid.Rows.Count != 0)
                {
                    sira = HaberSlider_Grid.Rows.Count + 1;
                }
                if (H.Kayit(BaslikBox.Text, Kayit_ResimAd, LinkBox.Text, sira) == true)
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = BaslikBox.Text + " haberi başarı ile kayıt edildi.";
                    HataVar.Visible = false;
                    BaslikBox.Text = "";
                    LinkBox.Text = "";
                    GelListe();
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
                HataLbl.Text = "Uygun formatda  (.jpg, .gif ve .png) resim yükleyiniz.";
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void HaberSlider_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            try
            {
                if (H.Delete(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "Haber başarı ile silindi.";
                    HataVar.Visible = false;
                    GelListe();
                }
            }
            catch (Exception)
            {
                //   BilgilerDiv.Visible = false;
                KayitTamam.Visible = false;
                HataVar.Visible = true;
            }
        }
    }
    protected void HaberSlider_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        HaberSlider_Grid.EditIndex = -1;
        GelListe();
    }
    protected void HaberSlider_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        HaberSlider_Grid.EditIndex = e.NewEditIndex;
        GelListe();
    }
    protected void HaberSlider_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)HaberSlider_Grid.Rows[e.RowIndex];
        TextBox Baslik_box = row.FindControl("EditBaslikBox") as TextBox;
        TextBox Link_box = row.FindControl("EditLinkBox") as TextBox;
        ImageButton upd = row.FindControl("GuncelleBtn") as ImageButton;
        string HaberID = upd.CommandArgument.ToString();
        if (H.Guncelle(Baslik_box.Text, Link_box.Text, HaberID) == true)
        {
            HaberSlider_Grid.EditIndex = -1;
            KayitTamam.Visible = true;
            KayitTamamLbl.Text = Baslik_box.Text + "  haberi başarı ile güncellendi.";
            HataVar.Visible = false;
            GelListe();
        }
        else
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
            HaberSlider_Grid.EditIndex = -1;
        }
    }
    protected void KaydetBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (H.Sirasini_Degistir(Geliyor_ID, SiralamaDrop.SelectedItem.Text) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = BaslikBox.Text + " haberi başarı ile kayıt edildi.";
                HataVar.Visible = false;
                BaslikBox.Text = "";
                LinkBox.Text = "";
                GelListe();
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_E_BultenUyeListesi : System.Web.UI.Page
{
    cls_Admin_Ebulten E = new cls_Admin_Ebulten();
    public static string Gel_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "E-Bülten İşlemleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Bülten İşlemleri";
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
        DataTable dt = E.Listeler();
        if (dt.Rows.Count != 0)
        {
            EPostaListesi_Grid.DataSource = dt;
            EPostaListesi_Grid.DataBind();
            GridKayitYokDiv.Visible = false;
            ToplamAdetLbl.Text = dt.Rows.Count.ToString();
        }
        else
        {
            GridKayitYokDiv.Visible = true;
            EPostaListesi_Grid.DataBind();
        }
    }
    protected void EpostaEkleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (E.Kontrol_Et(EpostaAdresiBox.Text.Trim()) == false)
            {
                if (E.Kayit(EpostaAdresiBox.Text.Trim()) == true)
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = EpostaAdresiBox.Text + " adresi başarı ile kayıt edildi.";
                    HataVar.Visible = false;
                    EpostaAdresiBox.Text = "";
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
                Ortak.MesajGoster("Bu adres sistemde kayıtlıdır.");
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void EPostaListesi_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EPostaListesi_Grid.PageIndex = e.NewPageIndex;
        GelListe();
        EPostaListesi_Grid.DataBind();
    }
    protected void EPostaListesi_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Durum = (Label)e.Row.FindControl("DurumLbl");
            Label Eposta = (Label)e.Row.FindControl("lblEpostaAdresi");
            ImageButton Gitsin = (ImageButton)e.Row.FindControl("EPostaGitsin");
            ImageButton Gitmesin = (ImageButton)e.Row.FindControl("EpostaGitmesin");
            Eposta.Text = Ortak.Decrypt(Eposta.Text.Trim());
            bool gidecek = Convert.ToBoolean(dr["Gidecek"]);
            if (gidecek == true)
            {
                Durum.Text = "E-Bülten Gidiyor";
                Durum.ForeColor = System.Drawing.Color.Black;
                Durum.Font.Bold = true;
                Gitsin.Visible = false;
            }
            else
            {
                Durum.Text = "E-Bülten Gitmiyor";
                Durum.ForeColor = System.Drawing.Color.Red;
                Durum.Font.Bold = true;
                Gitmesin.Visible = false;
            }

        }
    }
    protected void EPostaListesi_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sil")
            {
                if (E.Delete(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta başarı ile silindi.";
                    HataVar.Visible = false;
                    GelListe();
                }
            }
            else if (e.CommandName == "Gitsin")
            {
                if (E.E_PostaGidecek(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta adresine e-bülten gidecektir.";
                    HataVar.Visible = false;
                    GelListe();
                }
            }
            else if (e.CommandName == "Gitmesin")
            {
                if (E.E_PostaGitmeyecek(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta adresine e-bülten gitmeyecektir.";
                    HataVar.Visible = false;
                    GelListe();
                }
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void KaydetBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (E.Guncelle(Guncelle_EpostaAdresiBox.Text.Trim(), Gel_Id) == true)
            {
                EPostaListesi_Grid.EditIndex = -1;
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = Guncelle_EpostaAdresiBox.Text + "  adresi başarı ile güncellendi.";
                HataVar.Visible = false;
                GelListe();
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
                EPostaListesi_Grid.EditIndex = -1;
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void DuzenleBtn_Click(object sender, EventArgs e)
    {
        ImageButton G = sender as ImageButton;
        Gel_Id = G.CommandArgument.ToString();
        Guncelle_EpostaAdresiBox.Text = Ortak.Decrypt(G.AlternateText);
        mpe.Show();
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = E.Listeler_Ara(Eposta_Arabox.Text.Trim());
            if (dt.Rows.Count != 0)
            {
                EPostaListesi_Grid.DataSource = dt;
                EPostaListesi_Grid.DataBind();
                GridKayitYokDiv.Visible = false;
            }
            else
            {
                GridKayitYokDiv.Visible = true;
                EPostaListesi_Grid.DataBind();
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
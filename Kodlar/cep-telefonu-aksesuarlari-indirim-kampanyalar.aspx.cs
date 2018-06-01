using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class cep_telefonu_aksesuarlari_indirim_kampanyalar : System.Web.UI.Page
{

    cls_Urunler_Indirim_Kampanya Cok_Urun = new cls_Urunler_Indirim_Kampanya();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                TelefonMarkaGetir();
                Indirim_SarjAletleri();
                Indirim_Kulakliklar();
                Indirim_KoruyucuFilmler();
                Indirim_Kiliflar();
                Indirim_KabloveDonusturuculer();
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
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
    protected void TelefonDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TelefonDrop.SelectedIndex != 0)
            {
                ModelDrop.Items.Clear();
                string GelenID = TelefonDrop.SelectedValue;
                ModelDrop.Enabled = true;
                TelefonaGore_ModelGetir(GelenID);
                TelefonaGore_Indirim_SarjAletleri(GelenID);
                TelefonaGore_Indirim_Kulakliklar(GelenID);
                TelefonaGore_Indirim_KoruyucuFilmler(GelenID);
                TelefonaGore_Indirim_Kiliflar(GelenID);
                TelefonaGore_Indirim_KabloveDonusturuculer(GelenID);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    protected void ModelDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ModelDrop.SelectedIndex != 0)
            {
                string GelenID = ModelDrop.SelectedValue;
                ModeleGore_Indirim_SarjAletleri(GelenID);
                ModeleGore_Indirim_Kulakliklar(GelenID);
                ModeleGore_Indirim_KoruyucuFilmler(GelenID);
                ModeleGore_Indirim_Kiliflar(GelenID);
                ModeleGore_Indirim_KabloveDonusturuculer(GelenID);
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    /*TelefonGöre Gel*/
    private void TelefonaGore_Indirim_SarjAletleri(string ID_Sarj)
    {
        DataTable dt = Cok_Urun.TelefonaGore_Indirim_SarjAletleri(ID_Sarj);
        SarjAletleri_Repeater.DataSource = dt;
        SarjAletleri_Repeater.DataBind();
    }
    private void TelefonaGore_Indirim_Kulakliklar(string ID_Kulaklik)
    {
        DataTable dt = Cok_Urun.TelefonaGore_Indirim_Kulakliklar(ID_Kulaklik);
        Kulakliklar_Repeater.DataSource = dt;
        Kulakliklar_Repeater.DataBind();
    }
    private void TelefonaGore_Indirim_KoruyucuFilmler(string ID_Fimler)
    {
        DataTable dt = Cok_Urun.TelefonaGore_Indirim_Koruyucu_Filmler(ID_Fimler);
        KorucuFilmler_Repeater.DataSource = dt;
        KorucuFilmler_Repeater.DataBind();
    }
    private void TelefonaGore_Indirim_Kiliflar(string ID_Kilif)
    {
        DataTable dt = Cok_Urun.TelefonaGore_Indirim_Kiliflar(ID_Kilif);
        Kilif_CokSatanlarRepeater.DataSource = dt;
        Kilif_CokSatanlarRepeater.DataBind();
    }
    private void TelefonaGore_Indirim_KabloveDonusturuculer(string ID_Kablo)
    {
        DataTable dt = Cok_Urun.TelefonaGore_Indirim_KabloveDonusturuculer(ID_Kablo);
        KabloveDonusturuculer_Repeater.DataSource = dt;
        KabloveDonusturuculer_Repeater.DataBind();
    }
    /* Bitti*/
    /*ModeleGöre Gel*/
    private void ModeleGore_Indirim_SarjAletleri(string ID_Sarj)
    {
        DataTable dt = Cok_Urun.ModeleGore_Indirim_SarjAletleri(ID_Sarj);
        SarjAletleri_Repeater.DataSource = dt;
        SarjAletleri_Repeater.DataBind();
    }
    private void ModeleGore_Indirim_Kulakliklar(string ID_Kulaklik)
    {
        DataTable dt = Cok_Urun.ModeleGore_Indirim_Kulakliklar(ID_Kulaklik);
        Kulakliklar_Repeater.DataSource = dt;
        Kulakliklar_Repeater.DataBind();
    }
    private void ModeleGore_Indirim_KoruyucuFilmler(string ID_Fimler)
    {
        DataTable dt = Cok_Urun.ModeleGore_Indirim_Koruyucu_Filmler(ID_Fimler);
        KorucuFilmler_Repeater.DataSource = dt;
        KorucuFilmler_Repeater.DataBind();
    }
    private void ModeleGore_Indirim_Kiliflar(string ID_Kilif)
    {
        DataTable dt = Cok_Urun.ModeleGore_Indirim_Kiliflar(ID_Kilif);
        Kilif_CokSatanlarRepeater.DataSource = dt;
        Kilif_CokSatanlarRepeater.DataBind();
    }
    private void ModeleGore_Indirim_KabloveDonusturuculer(string ID_Kablo)
    {
        DataTable dt = Cok_Urun.ModeleGore_Indirim_KabloveDonusturuculer(ID_Kablo);
        KabloveDonusturuculer_Repeater.DataSource = dt;
        KabloveDonusturuculer_Repeater.DataBind();
    }
    /* Bitti*/
    /*Sayfa Yüklenirken Çalıştırılacak Kodlar*/
    private void Indirim_SarjAletleri()
    {
        DataTable dt = Cok_Urun.Indirim_SarjAletleri();
        SarjAletleri_Repeater.DataSource = dt;
        SarjAletleri_Repeater.DataBind();
    }
    private void Indirim_Kulakliklar()
    {
        DataTable dt = Cok_Urun.Indirim_Kulakliklar();
        Kulakliklar_Repeater.DataSource = dt;
        Kulakliklar_Repeater.DataBind();
    }
    private void Indirim_KoruyucuFilmler()
    {
        DataTable dt = Cok_Urun.Indirim_Koruyucu_Filmler();
        KorucuFilmler_Repeater.DataSource = dt;
        KorucuFilmler_Repeater.DataBind();
    }
    private void Indirim_Kiliflar()
    {
        DataTable dt = Cok_Urun.Indirim_Kiliflar();
        Kilif_CokSatanlarRepeater.DataSource = dt;
        Kilif_CokSatanlarRepeater.DataBind();
    }
    private void Indirim_KabloveDonusturuculer()
    {
        DataTable dt = Cok_Urun.Indirim_KabloveDonusturuculer();
        KabloveDonusturuculer_Repeater.DataSource = dt;
        KabloveDonusturuculer_Repeater.DataBind();
    }
    /*Bitti*/
    protected void SarjAletleri_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == false)
            {
                Indirim.Visible = false;
            }
            else
            {
                divIndirim.Visible = true;
                Indirim.Text = "% " + Indirim.Text + " İndirim";
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void Kulakliklar_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == false)
            {
                Indirim.Visible = false;
            }
            else
            {
                divIndirim.Visible = true;
                Indirim.Text = "% " + Indirim.Text + " İndirim";
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KorucuFilmler_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == false)
            {
                Indirim.Visible = false;
            }
            else
            {
                divIndirim.Visible = true;
                Indirim.Text = "% " + Indirim.Text + " İndirim";
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void Kilif_CokSatanlarRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == false)
            {
                Indirim.Visible = false;
            }
            else
            {
                divIndirim.Visible = true;
                Indirim.Text = "% " + Indirim.Text + " İndirim";
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KabloveDonusturuculer_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == false)
            {
                Indirim.Visible = false;
            }
            else
            {
                divIndirim.Visible = true;
                Indirim.Text = "% " + Indirim.Text + " İndirim";
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
}

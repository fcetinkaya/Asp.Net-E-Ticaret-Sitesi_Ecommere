using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class TumModeller : System.Web.UI.Page
{
    cls_Urunler_CokSatanlar Urun_Cls = new cls_Urunler_CokSatanlar();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                TelefonMarkaGetir();
                EnCokSatanlar();
                Urunleri_Getir();
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
    }
    private void EnCokSatanlar()
    {
        DataTable dtD = Urun_Cls.EnCokSatanlar_Anasayfa();
        CokSatanlarRepeater.DataSource = dtD;
        CokSatanlarRepeater.DataBind();
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
    private void Urunleri_Getir()
    {
        DataTable dt = cls_DataAdaptore.Kategori_Getir();
        DataRow dr = dt.NewRow();
        dr["KategoriAdi"] = "Kategori Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        KategoriDrop.DataSource = dt;
        KategoriDrop.DataValueField = "KategoriID";
        KategoriDrop.DataTextField = "KategoriAdi";
        KategoriDrop.DataBind();
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
                string SeciliTelefonID = TelefonDrop.SelectedValue;
                ModelDrop.Enabled = true;
                TelefonaGore_ModelGetir(SeciliTelefonID);
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
    protected void CokSatanlarRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
    public string KarekterDegistir(string HaberAdi)
    {
        //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
        string Temp = HaberAdi.ToLower();
        Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "");
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
    public string KarekterDegistir_II(string HaberAdi)
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
    protected void UrunleriGetirBtn_Click(object sender, EventArgs e)
    {
        if (TelefonDrop.SelectedIndex != 0 && ModelDrop.SelectedIndex != 0 && KategoriDrop.SelectedIndex != 0)
        {
            string Telefon = TelefonDrop.SelectedItem.Text;
            Telefon = KarekterDegistir(Telefon);
            string Model = ModelDrop.SelectedItem.Text;
            Model = KarekterDegistir(Model);
            string Kategori = KategoriDrop.SelectedItem.Text;
            Kategori = KarekterDegistir_II(Kategori);
            string Link = Telefon + "-" + Model + "-cep-telefonu-aksesuari-kategorisi-" + Kategori + ".aspx";
            Response.Redirect(Link);
        }
        else
        {
            Ortak.MesajGoster("Tüm Alanları Seçiniz.");
        }
    }
}
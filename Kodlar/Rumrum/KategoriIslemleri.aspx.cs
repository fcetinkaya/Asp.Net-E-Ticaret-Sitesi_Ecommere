using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_KategoriIslemleri : System.Web.UI.Page
{
    cls_Admin_KategoriIslemleri K = new cls_Admin_KategoriIslemleri();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["eticaret"] != null)
        {
            if (!IsPostBack)
            {
                Label label = Master.FindControl("UrlMaplbl") as Label;
                label.Text = "Kategori İşlemleri";
                Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                label2.Text = "Kategori İşlemleri";
                Gel_AnaKategori_Drop();
            }
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
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
    public void Gel_AnaKategori_Drop()
    {
        DataTable dt = K.Ana_Kategori_List();
        if (dt.Rows.Count != 0)
        {
            DataRow dr = dt.NewRow();
            dr["AnaKategoriAdi"] = "Lütfen Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            anaKategoriDrop.DataSource = dt;
            anaKategoriDrop.DataTextField = "AnaKategoriAdi";
            anaKategoriDrop.DataValueField = "AnaKategoriID";
            anaKategoriDrop.DataBind();
        }
    }
    //Ana Kategori Islemleri
    protected void anakategori_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            if (K.Ana_Kategori_Kayit(ana_kategoriAdiBox.Text, KarekterDegistir(ana_kategoriAdiBox.Text)) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = ana_kategoriAdiBox.Text + " kategorisi başarı ile kayıt edildi.";
                HataVar.Visible = false;
                ana_kategoriAdiBox.Text = "";
                anaKategoriDrop.Items.Clear();
                Gel_AnaKategori_Drop();
                //  string kod = "window.top.location.href = 'YeniUyeIsimveNumara.aspx'";
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "yenile", kod, true);
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
    //Alt Kategori Islemleri
    protected void btnAltKategori_Click(object sender, EventArgs e)
    {
        try
        {
            if (K.Kategori_Kayit(Alt_KategoriAdibox.Text, KarekterDegistir(Alt_KategoriAdibox.Text), anaKategoriDrop.SelectedValue) == true)
            {
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = Alt_KategoriAdibox.Text + " kategorisi başara ile kayıt edildi.";
                HataVar.Visible = false;
                Alt_KategoriAdibox.Text = "";
                anaKategoriDrop.SelectedIndex = 0;

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
}
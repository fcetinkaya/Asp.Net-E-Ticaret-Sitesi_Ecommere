using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Arama : System.Web.UI.Page
{
    cls_Arama Kat_Cls = new cls_Arama();
    SqlConnection con = new SqlConnection();
    public int SayfaNo
    {
        // SAYFANO adında bir property tanımlıyoruz. tanımladığımız property de tıkladığımız sayfa numaralarını ViewState saklamamıza yaracak.
        get
        {
            if (ViewState["SayfaNo"] != null)
            {
                return Convert.ToInt32(ViewState["SayfaNo"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["SayfaNo"] = value; }
    }
    public int SayfaSayisi
    {
        get
        {
            if (ViewState["SayfaSayisi"] != null)
            {
                return Convert.ToInt32(ViewState["SayfaSayisi"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["SayfaSayisi"] = value; }
    }
    PagedDataSource Sayfa;
    public string Kelime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["ct"] != null)
                {
                    string Kelime = Request.QueryString["ct"].ToString();
                    ArananKelimeLbl.Text = "'" + Kelime.ToString() + "'";
                    Aramaya_Gore_Getir_Urunleri(Kelime);
                }
                else
                {
                    Response.Redirect("Default.aspx");
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
    }
    private void ReadSayfa()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        for (int i = 0; i <= Sayfa.PageCount - 1; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        rptPages.DataSource = dt;
        rptPages.DataBind();
    }
    private void Aramaya_Gore_Getir_Urunleri(string Geliyor)
    {
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        Sayfa = new PagedDataSource();
        DataTable dt = Kat_Cls.AramaKelime_GoreGetir_Urunleri(Geliyor);
        if (dt.Rows.Count != 0)
        {
            Sayfa.DataSource = dt.DefaultView;
            Sayfa.AllowPaging = true;
            Sayfa.PageSize = 40;
            SayfaSayisi = Sayfa.PageCount - 1;
            Sayfa.CurrentPageIndex = SayfaNo;
            KategoriRepeater.DataSource = Sayfa;
            KategoriRepeater.DataBind();
            ReadSayfa();
        }
        else
        {
            KategoriRepeater.Visible = false;
            UyariDiv.Visible = true;
            KategoriRepeater.DataBind();
        }
    }
    public void Ekle(string id, string ResimYol, string isim, double adet, double fiyat, double Toplam, string link)
    {
        try
        {
            DataTable dt = new DataTable();
            if (Session["sepet"] != null)
            {
                dt = (DataTable)Session["sepet"];
            }
            else
            {
                dt.Columns.Add("id");
                dt.Columns.Add("resim");
                dt.Columns.Add("isim");
                dt.Columns.Add("fiyat");
                dt.Columns.Add("adet");
                dt.Columns.Add("toplam");
                dt.Columns.Add("link");
            }
            bool varmi = Kontrol(id.ToString());
            if (varmi == false)
            {
                DataRow drow = dt.NewRow();
                drow["id"] = id;
                drow["resim"] = ResimYol;
                drow["isim"] = isim;
                drow["fiyat"] = fiyat;
                drow["adet"] = adet;
                drow["toplam"] = Toplam;
                drow["link"] = link;
                dt.Rows.Add(drow);
            }
            else
            {
                Artir(id, adet, fiyat);
            }
            Session["sepet"] = dt;
        }
        catch
        {
            Response.Redirect("Hata.aspx");
        }
    }
    private bool Kontrol(string id)
    {
        bool r = false;
        DataTable dt = new DataTable();
        if (Session["sepet"] != null)
        {
            dt = (DataTable)Session["sepet"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    r = true;
                    break;
                }
            }
        }
        return r;
    }
    private void Artir(string id, double adet, double fiyat)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    double adet1 = Convert.ToDouble(dt.Rows[i]["adet"].ToString());
                    double toplam1 = Convert.ToDouble(dt.Rows[i]["toplam"].ToString());
                    adet1 += adet;
                    toplam1 += toplam1;
                    dt.Rows[i]["adet"] = adet1.ToString();
                    dt.Rows[i]["toplam"] = toplam1.ToString();
                    Session["sepet"] = dt;
                    break;
                }
            }
        }
        catch
        {
            Response.Redirect("Hata.aspx");
        }
    }
    protected void KategoriRepeater_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Ekle")
        {
            string Aydi = e.CommandArgument.ToString();
            HyperLink Resim = (HyperLink)e.Item.FindControl("UrunlerLogo");
            HyperLink AdiLbl = (HyperLink)e.Item.FindControl("UrunBaslikLbl");
            Label FiyatiLbl = (Label)e.Item.FindControl("UrunYeniFiyatLbl");
            string ResimYol = Resim.ImageUrl.ToString().Remove(0, 2);
            string Adi = AdiLbl.Text;
            string Link = AdiLbl.NavigateUrl.ToString();
            string DFiyaT = FiyatiLbl.Text.Trim(); ;
            DFiyaT = DFiyaT.Substring(0, DFiyaT.Length - 3);
            double fiyati = Convert.ToDouble(DFiyaT);
            double adet = 1;

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati,Link);
            Response.Redirect("Sepet.aspx");
        }
    }
    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SayfaNo = Convert.ToInt32(e.CommandArgument);
        Aramaya_Gore_Getir_Urunleri(Kelime);
    }
    protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        if (lnkbtnPage.CommandArgument.ToString() == SayfaNo.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Font.Bold = true;
            lnkbtnPage.Attributes.Add("style", " background: url('../images/pager-a-hov.gif') repeat-x 0 0 #1d97be !important;");
        }
    }
}
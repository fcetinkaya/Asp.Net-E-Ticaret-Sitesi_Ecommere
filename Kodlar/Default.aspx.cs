using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //   cls_Urunler Urun = new cls_Urunler();
    cls_Urunler_CokSatanlar Cok_Urun = new cls_Urunler_CokSatanlar();
    cls_Urunler_Kiliflar Kilif = new cls_Urunler_Kiliflar();
    cls_Urunler_Kulakliklar Kulak = new cls_Urunler_Kulakliklar();
    cls_Urunler_SarjAletleri Sarj = new cls_Urunler_SarjAletleri();
    cls_Urunler_Indirim_Kampanya Kampan = new cls_Urunler_Indirim_Kampanya();
    cls_Urunler_KoruyucuFilmler Koruyucu = new cls_Urunler_KoruyucuFilmler();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GelHaberler();
                EnCokSatanlar();
                Indirimdekiler();
                Kiliflar();
                KoruyucuFilmler();
                Kulakliklar();
                SarjAletleri();
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
    private void SarjAletleri()
    {
        DataTable dt = Sarj.Anasayfa_SarjAletleri();
        SarjAletleriRepeater.DataSource = dt;
        SarjAletleriRepeater.DataBind();
    }
    private void Kulakliklar()
    {
        DataTable dt = Kulak.Anasayfa_Kulakliklar();
        KulaklikRepeater.DataSource = dt;
        KulaklikRepeater.DataBind();
    }
    private void Kiliflar()
    {
        DataTable dt = Kilif.Anasayfa_Kiliflar();
        KiliflarRepeater.DataSource = dt;
        KiliflarRepeater.DataBind();
    }
    private void KoruyucuFilmler()
    {
        DataTable dt = Koruyucu.Koruyucu_Filmler_Anasayfa();
        KoruyucuFilmler_Repeater.DataSource = dt;
        KoruyucuFilmler_Repeater.DataBind();
    }
    private void Indirimdekiler()
    {
        DataTable dt = Kampan.Anasayfa_Indirimdekiler();
        IndirimdekilerRepeater.DataSource = dt;
        IndirimdekilerRepeater.DataBind();
    }
    private void EnCokSatanlar()
    {
        DataTable dt = Cok_Urun.EnCokSatanlar_Anasayfa();
        CokSatanlarRepeater.DataSource = dt;
        CokSatanlarRepeater.DataBind();
    }
    private void GelHaberler()
    {
        DataTable dt = Haberler.GelHaberler();
        HaberRepeater.DataSource = dt;
        HaberRepeater.DataBind();
    }
    protected void HaberRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hl = e.Item.FindControl("HaberLink") as HyperLink;
            hl.ImageUrl = DataBinder.Eval(e.Item.DataItem, "ResimYol").ToString();
            hl.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "Link").ToString();
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
    protected void IndirimdekilerRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            Label Indirim = e.Item.FindControl("IndirimLbl") as Label;
            Indirim.Text = "% " + Indirim.Text + " İndirim";
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KiliflarRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == true)
            {
                divIndirim.Visible = true;
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KoruyucuFilmler_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == true)
            {
                divIndirim.Visible = true;
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KulaklikRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == true)
            {
                divIndirim.Visible = true;
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void SarjAletleriRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool IndirimVarmi = (bool)DataBinder.Eval(e.Item.DataItem, "Indirimli");
            bool Tukendimi = (bool)DataBinder.Eval(e.Item.DataItem, "Tukendi");
            HtmlGenericControl divIndirim = (HtmlGenericControl)e.Item.FindControl("IndirimDiv");
            HtmlGenericControl divTukendi = (HtmlGenericControl)e.Item.FindControl("TukendiDiv");
            if (IndirimVarmi == true)
            {
                divIndirim.Visible = true;
            }
            if (Tukendimi == true)
            {
                divTukendi.Visible = true;
            }
        }
    }
    protected void KiliflarRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati, Link);
            Response.Redirect("Sepet.aspx");
        }
    }
    protected void KoruyucuFilmler_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati, Link);
            Response.Redirect("Sepet.aspx");
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
                    toplam1 += fiyat;
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
    protected void KampanyaEpostaBtn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(KamapanyaEpostaBox.Text))
        {
            if (Ortak.E_BultenKayit(KamapanyaEpostaBox.Text) == true)
            {
                Response.Write("<script type=\"text/javascript\">alert('E-Bültene Kayıt Olduğunuz İçin Teşekkürler.');</script>");
                KamapanyaEpostaBox.Text = "";
            }
        }
        else
        {
            Response.Write("<script type=\"text/javascript\">alert('E-Posta Adresini Yazınız.');</script>");
        }
    }
    protected void KulaklikRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati, Link);
            Response.Redirect("Sepet.aspx");
        }
    }
    protected void SarjAletleriRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati, Link);
            Response.Redirect("Sepet.aspx");
        }
    }
}
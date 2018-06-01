using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ModelListe : System.Web.UI.Page
{
    cls_ModelListe Kat_Cls = new cls_ModelListe();
    cls_Urunler_CokSatanlar Urun_Cls = new cls_Urunler_CokSatanlar();
    SqlConnection con = new SqlConnection();
    private static string GelenTelefonID, GelenModelID, Secim, SeciliTelefonID, SeciliModelID;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (RouteData.Values["TlfAdi"] != null)
                {
                    TelefonMarkaGetir();
                    string RauteTlf = RouteData.Values["TlfAdi"].ToString();
                    string RauteModel = RouteData.Values["ModelAdi"].ToString();
                    string[] GelKAt = Kat_Cls.Kategori_Telefon_BilgisiGetir(RauteTlf, RauteModel);
                    GelenTelefonID = GelKAt[0].ToString();
                    GelenModelID = GelKAt[2].ToString();
                    CokSatanLbl.Text = GelKAt[1].ToString().Trim() + " / " + GelKAt[3].ToString().Trim();
                    KategoriAdiLbl.Text = GelKAt[1].ToString().Trim() + " / " + GelKAt[3].ToString().Trim();
                    string Description = KategoriAdiLbl.Text + " | Cep Telefonu Takı ve Aksesuarları";
                    HtmlMeta metaDescription = (HtmlMeta)Page.Master.FindControl("metaDescription");
                    metaDescription.Content = Description;
                    Page.Title = KategoriAdiLbl.Text + " | Cep Telefonu Takı ve Aksesuarları";
                    KategoriyeGore_Getir_Urunleri();
                    EnCokSatanlar();
                    if (Session["E_ticaretim"] != null)
                    {
                        HaberdarEtEpostaBox.Visible = false;
                    }
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
    private void KategoriyeGore_Getir_Urunleri()
    {
        Secim = "IlkGelen";
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        Sayfa = new PagedDataSource();
        DataTable dt = Kat_Cls.RouteID_GoreGetir_Urunleri(GelenTelefonID, GelenModelID);
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
    private void EnCokSatanlar()
    {
        DataTable dt = Kat_Cls.EnCokSatanlar(GelenTelefonID, GelenModelID);
        if (dt.Rows.Count != 0)
        {
            CokSatanlarRepeater.DataSource = dt;
            CokSatanlarRepeater.DataBind();
        }
        else
        {
            DataTable dtD = Urun_Cls.EnCokSatanlar_Anasayfa();
            CokSatanlarRepeater.DataSource = dtD;
            CokSatanlarRepeater.DataBind();
            CokSatanLbl.Text = "Diğer Ürünler";
        }
    }
    #region FiyatArtanveAzalanaGoreSirala
    private void FiyatArtana_Gore_Getir_Urunleri()
    {
        Secim = "Fiyat_Artan";
        Sayfa = new PagedDataSource();
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        KategoriRepeater.DataSource = null;
        DataTable dt = Kat_Cls.FiyatArtana_GoreGetir_Urunleri(GelenTelefonID, GelenModelID);
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
    private void FiyatAzalana_Gore_Getir_Urunleri()
    {
        Secim = "Fiyat_Azalan";
        Sayfa = new PagedDataSource();
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        KategoriRepeater.DataSource = null;
        DataTable dt = Kat_Cls.FiyatAzalan_GoreGetir_Urunleri(GelenTelefonID, GelenModelID);
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
    #endregion
    #region AdanZyeGoreSirala
    private void AdanZyeGore_Getir_Urunleri()
    {
        Secim = "AdanZye";
        KategoriRepeater.DataSource = null;
        Sayfa = new PagedDataSource();
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        DataTable dt = Kat_Cls.AdanZye_GoreGetir_Urunleri(GelenTelefonID, GelenModelID);
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
    private void ZdenAyaGore_Getir_Urunleri()
    {
        Secim = "ZdenAya";
        KategoriRepeater.DataSource = null;
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        Sayfa = new PagedDataSource();
        DataTable dt = Kat_Cls.ZdenAya_GoreGetir_Urunleri(GelenTelefonID, GelenModelID);
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
    #endregion
    #region TelefonveModeleGoreFiltreleme
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
                SeciliTelefonID = TelefonDrop.SelectedValue;
                ModelDrop.Enabled = true;
                TelefonaGore_ModelGetir(SeciliTelefonID);
                Telefon_Gore_Getir_Urunleri();
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
                SeciliModelID = ModelDrop.SelectedValue;
                TelefonModele_Gore_Getir_Urunleri();
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
    private void Telefon_Gore_Getir_Urunleri()
    {
        Secim = "Telefon";
        Sayfa = new PagedDataSource();
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        KategoriRepeater.DataSource = null;
        DataTable dt = Kat_Cls.Telefona_GoreGetir_Urunleri(SeciliTelefonID);
        if (dt.Rows.Count != 0)
        {
            KategoriRepeater.Visible = true;
            UyariDiv.Visible = false;
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
            rptPages.DataBind();
        }
    }
    private void TelefonModele_Gore_Getir_Urunleri()
    {
        Secim = "Model";
        KategoriRepeater.DataSource = null;
        KategoriRepeater.Visible = true;
        UyariDiv.Visible = false;
        Sayfa = new PagedDataSource();
        DataTable dt = Kat_Cls.Telefon_Modele_GoreGetir_Urunleri(SeciliTelefonID, SeciliModelID);
        if (dt.Rows.Count != 0)
        {
            KategoriRepeater.Visible = true;
            UyariDiv.Visible = false;
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
    #endregion
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
    protected void AlfabetikDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SayfaNo = 0;
            if (AlfabetikDrop.SelectedValue == "1")
            {
                AdanZyeGore_Getir_Urunleri();
            }
            else if (AlfabetikDrop.SelectedValue == "2")
            {
                ZdenAyaGore_Getir_Urunleri();
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
    protected void FiyatDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SayfaNo = 0;
            if (FiyatDrop.SelectedValue == "1")
            {
                FiyatAzalana_Gore_Getir_Urunleri();
            }
            else if (FiyatDrop.SelectedValue == "2")
            {
                FiyatArtana_Gore_Getir_Urunleri();
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

            Ekle(Aydi, ResimYol, Adi, adet, fiyati, fiyati, Link);
            Response.Redirect("Sepet.aspx");
        }
    }
    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SayfaNo = Convert.ToInt32(e.CommandArgument);
        if (Secim == "IlkGelen")
        {
            KategoriyeGore_Getir_Urunleri();
        }
        else if (Secim == "Fiyat_Artan")
        {
            FiyatArtana_Gore_Getir_Urunleri();
        }
        else if (Secim == "Fiyat_Azalan")
        {
            FiyatAzalana_Gore_Getir_Urunleri();
        }
        else if (Secim == "AdanZye")
        {
            AdanZyeGore_Getir_Urunleri();
        }
        else if (Secim == "ZdenAya")
        {
            ZdenAyaGore_Getir_Urunleri();
        }
        else if (Secim == "Telefon")
        {
            Telefon_Gore_Getir_Urunleri();
        }
        else if (Secim == "Model")
        {
            TelefonModele_Gore_Getir_Urunleri();
        }
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
    protected void KampanyaEpostaBtn_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["E_ticaretim"] != null)
            {
                string Aciklama = RouteData.Values["TlfAdi"].ToString() + "/" + RouteData.Values["ModelAdi"].ToString() + "/" + RouteData.Values["KatAdi"].ToString() + " Kategorisi için Talep Var.";
                string[] Gelenler = (string[])Session["E_ticaretim"];
                string GelenIdicik = Gelenler[0].ToString(); if (Ortak.Urun_Eklenince_HaberdarEt_Uye(GelenIdicik, Aciklama) == true)
                {
                    Ortak.MesajGoster("Talebiniz Başarı ile Kayıt Edildi.");
                    HaberdarEtEpostaBox.Text = "";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(HaberdarEtEpostaBox.Text))
                {
                    string Aciklama = RouteData.Values["TlfAdi"].ToString() + "/" + RouteData.Values["ModelAdi"].ToString() + "/" + RouteData.Values["KatAdi"].ToString() + " Kategorisi için Talep Var."; if (Ortak.Urun_Eklenince_HaberdarEt(HaberdarEtEpostaBox.Text, Aciklama) == true)
                    {
                        Ortak.MesajGoster("Talebiniz Başarı ile Kayıt Edildi.");
                        HaberdarEtEpostaBox.Text = "";
                    }
                    else
                    {
                        Ortak.MesajGoster("E-Posta Adresini Yazınız.");
                    }
                }
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
    protected void KategoriRepeater_ItemDataBound(object sender, DataListItemEventArgs e)
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
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UrunDetay : System.Web.UI.Page
{
    private static string GelenUrunID, Link;
    cls_Urunler Urun = new cls_Urunler();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (RouteData.Values["UrunID"] != null)
                {
                    GelenUrunID = RouteData.Values["UrunID"].ToString();
                    RenkSecenekleriGelsin();
                    Bankalar_Gelsin();
                    Urun.UrunDetay_TiklamaArttir(GelenUrunID);
                    UrunBilgisiGel();
                    Resimler_Gelsin();
                    if (Urun.UrunDetay_Tukendimi(GelenUrunID) == true)
                    {
                        Tukendi_Div.Visible = true;
                        Detay_Div.Visible = false;
                        Taksit_Secenek.Visible = false;
                        UyariDiv.Visible = true;
                    }
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
    private void RenkSecenekleriGelsin()
    {
        DataTable dt = Urun.UrunDetay_RenkSecenekleri(GelenUrunID);
        if (dt.Rows.Count != 0)
        {
            RenkSecenekleriRepeater.DataSource = dt;
            RenkSecenekleriRepeater.DataBind();
        }
        else
        {
            RenkSecenekleriRepeater.DataBind();
        }
    }
    private void UrunBilgisiGel()
    {
        SqlDataReader DRGel = Urun.UrunDetay_UrunBilgileriGel(GelenUrunID);
        if (DRGel.HasRows)
        {
            while (DRGel.Read())
            {
                UrunAdiLbl.Text = DRGel["UrunAdi"].ToString();
                //    AnaResim.ImageUrl = "Urunler/Logo/" + DRGel["Logo"].ToString();
                EskiFiyatLbl.Text = DRGel["EskiFiyat"].ToString();
                YeniFiyatLbl.Text = DRGel["YeniFiyat"].ToString();
                double fiyat = Convert.ToDouble(DRGel["YeniFiyat"]);
                double KDV_Dahil = (fiyat * 1.18);
                KDV_Dahil = Math.Round(KDV_Dahil, 2);
                KDVDahilLBl.Text = KDV_Dahil.ToString();
                double Havale = KDV_Dahil - ((KDV_Dahil / 100) * Ortak.Odenecek_Havale_Indirim);
                Havale = Math.Round(Havale, 2);
                HavaleLbl.Text = string.Format("{0:0.00}", Havale);
                AciklamaLitearal.Text = DRGel["Aciklama"].ToString();
                Link = DRGel["Link"].ToString();
                KategoriLink.Text = DRGel["KategoriAdi"].ToString();
                KategoriLink.NavigateUrl = "cep-telefonu-aksesuarlari-kategorisi-" + DRGel["RouteKatAdi"].ToString() + ".aspx";
                TelefonMarkaLink.Text = DRGel["TelAdi"].ToString();
                TelefonMarkaLink.NavigateUrl = DRGel["RouteTelAdi"].ToString() + "-cep-telefonu-aksesuari-kategorisi-" + DRGel["RouteKatAdi"].ToString() + ".aspx";
                TelefonModelLink.Text = DRGel["ModelAdi"].ToString();
                TelefonModelLink.NavigateUrl = DRGel["RouteTelAdi"].ToString() + "-" + DRGel["RouteModelAdi"].ToString() + "-cep-telefonu-aksesuari-kategorisi-" + DRGel["RouteKatAdi"].ToString() + ".aspx";
                string Description = DRGel["UrunAdi"].ToString() + "," + DRGel["KategoriAdi"].ToString() + "," + DRGel["TelAdi"].ToString() + "," + DRGel["ModelAdi"].ToString() + " | Cep Telefonu Takı ve Aksesuarları";
                HtmlMeta metaDescription = (HtmlMeta)Page.Master.FindControl("metaDescription");
                metaDescription.Content = Description;
                Page.Title = DRGel[0].ToString() + " | Cep Telefonu Takı ve Aksesuarları";
            }
        }
        DRGel.Close();
        con.Close();
        con.Dispose();
        SqlConnection.ClearPool(con);

    }
    private void Bankalar_Gelsin()
    {
        DataTable dt = Urun.UrunDetay_OdemeSecenekleri_Banka(GelenUrunID);
        OdemeSecenekleriRepeater.DataSource = dt;
        OdemeSecenekleriRepeater.DataBind();
    }
    private void Resimler_Gelsin()
    {
        DataTable dt = Urun.UrunDetay_ResimGetir(GelenUrunID);
        if (dt.Rows.Count != 0)
        {
            ResimlerRepeater.DataSource = dt;
            ResimlerRepeater.DataBind();
            AnaResim.ImageUrl = "Urunler/Resimler/" + dt.Rows[0][0].ToString();
        }
        else
        {
            ResimlerRepeater.DataBind();
            AnaResim.ImageUrl = "Urunler/Resimler/resim_yok.png";
        }
    }
    protected void OdemeSecenekleriRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string BankaID = DataBinder.Eval(e.Item.DataItem, "E_BankaID").ToString();
                Repeater rp = (Repeater)e.Item.FindControl("TaksitSayisiRepeater");
                rp.DataSource = Urun.UrunDetay_OdemeSecenekleri_Taksitler(BankaID);
                rp.DataBind();
                con.Close();
                con.Dispose();
                SqlConnection.ClearPool(con);
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
                Artir(id, adet, Toplam);
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
    protected void SepetEkleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            double Adet = Convert.ToDouble(spinner.Value);
            double Fiyat = Convert.ToDouble(YeniFiyatLbl.Text);
            double Toplam = Adet * Fiyat;
            Ekle(GelenUrunID, AnaResim.ImageUrl.ToString(), UrunAdiLbl.Text, Adet, Fiyat, Toplam, Link);
            Response.Redirect("Sepet.aspx", false);
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
    protected void KampanyaEpostaBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["E_ticaretim"] != null)
            {
                string Aciklama = RouteData.Values["UrunAdi"].ToString() + " ürünü için talep var.";
                string[] Gelenler = (string[])Session["E_ticaretim"];
                string GelenIdicik = Gelenler[0].ToString();
                if (Ortak.Urun_Eklenince_HaberdarEt_Uye(GelenIdicik, Aciklama) == true)
                {
                    Ortak.MesajGoster("Talebiniz Başarı ile Kayıt Edildi.");
                    HaberdarEtEpostaBox.Text = "";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(HaberdarEtEpostaBox.Text))
                {
                    string Aciklama = RouteData.Values["UrunAdi"].ToString() + " ürünü için talep var.";
                    if (Ortak.Urun_Eklenince_HaberdarEt(HaberdarEtEpostaBox.Text, Aciklama) == true)
                    {
                        Ortak.MesajGoster("Talebiniz Başarı ile Kayıt Edildi.");
                        HaberdarEtEpostaBox.Text = "";
                    }
                }
                else
                {
                    Ortak.MesajGoster("E-Posta Adresini Yazınız.");
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

}
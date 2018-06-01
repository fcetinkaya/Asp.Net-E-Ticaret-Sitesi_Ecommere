using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.TwitterAPI;
using System.Data;

public partial class TwitterAuthentication : System.Web.UI.Page
{
    cls_Sepet cS = new cls_Sepet();
    public static int Gel_Twitto;
    protected void Page_Load(object sender, EventArgs e)
    {
        TwitterConnect.API_Key = Ortak.Twitter_API_Key.ToString();
        TwitterConnect.API_Secret = Ortak.Twitter_API_Secret.ToString();
        if (!IsPostBack)
        {
            if (!TwitterConnect.IsAuthorized)
            {
                TwitterConnect twitter = new TwitterConnect();
                twitter.Authorize(Request.Url.AbsoluteUri.Split('?')[0]);
            }
            else
            {
                TwitterConnect twitter = new TwitterConnect();
                DataTable dt = twitter.FetchProfile();
                string AdiSoyadi = dt.Rows[0]["name"].ToString();
                AdiSoyadi = Trkarakter(AdiSoyadi);
                Gel_Twitto = cls_Uyeler.KontrolEtUyemi_Twitter(dt.Rows[0]["screen_name"].ToString(), dt.Rows[0]["id"].ToString());
                if (Gel_Twitto > 0)
                {
                    string[] GelBilgi = { Gel_Twitto.ToString(), AdiSoyadi };
                    Veritabani_Uyenin_Sepeti_Gel(Gel_Twitto.ToString());
                    Session.Add("E_ticaretim", GelBilgi);
                    Response.Redirect("Hesabim.aspx");
                }
                else
                {
                    Gel_Twitto = cls_Uyeler.Kullanici_KayitEkle_Twitter(dt.Rows[0]["screen_name"].ToString(), dt.Rows[0]["id"].ToString(), AdiSoyadi);
                    if (Gel_Twitto > 0)
                    {
                        //string AdiSoyadi = dt.Rows[0]["name"].ToString();
                        //AdiSoyadi = Trkarakter(AdiSoyadi);
                        string[] GelBilgi = { Gel_Twitto.ToString(), AdiSoyadi };
                        Veritabani_Uyenin_Sepeti_Gel(Gel_Twitto.ToString());
                        Session.Add("E_ticaretim", GelBilgi);
                        Response.Redirect("Hesabim.aspx");
                    }
                    else
                    {
                        Response.Redirect("Hata.aspx", false);
                    }
                }
            }
            if (TwitterConnect.IsDenied)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "alert('User has denied access.')", true);
            }
        }
    }
    string Trkarakter(string text)
    {
        text = text.Replace("u0131", "ı");
        text = text.Replace("u0399", "I");
        text = text.Replace("u011e", "Ğ");
        text = text.Replace("u011f", "ğ");
        text = text.Replace("u015e", "Ş");
        text = text.Replace("u015f", "ş");
        text = text.Replace("u00F6", "ö");
        text = text.Replace("u00D6", "Ö");
        text = text.Replace("u00fc", "ü");
        text = text.Replace("u00dc", "Ü");
        text = text.Replace("u00e7", "ç");
        text = text.Replace("u00c7", "Ç");
        return text;
    }
    public void Veritabani_Uyenin_Sepeti_Gel(string Ay_di)
    {
        DataTable dt = cS.Uye_Siparis_Sepet_Gel(Ay_di);
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ekle(dt.Rows[i]["id"].ToString(), dt.Rows[i]["resim"].ToString(), dt.Rows[i]["isim"].ToString(), Convert.ToDouble(dt.Rows[i]["adet"]), Convert.ToDouble(dt.Rows[i]["fiyat"]), Convert.ToDouble(dt.Rows[i]["toplam"]), dt.Rows[i]["link"].ToString());
            }
        }
        else
        {
            DataTable dt_sepet = new DataTable();
            if (Session["sepet"] != null)
            {
                dt_sepet = (DataTable)Session["sepet"];
                for (int i = 0; i < dt_sepet.Rows.Count; i++)
                {
                    cS.Uyenin_Sepetini_Ekle(dt_sepet.Rows[i]["id"].ToString(), dt_sepet.Rows[i]["resim"].ToString(), dt_sepet.Rows[i]["isim"].ToString(), Convert.ToInt32(dt_sepet.Rows[i]["adet"]), Convert.ToDouble(dt_sepet.Rows[i]["fiyat"]), Convert.ToDouble(dt_sepet.Rows[i]["toplam"]), dt_sepet.Rows[i]["link"].ToString(), Ay_di);
                }
            }
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
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using System.Data;

public partial class FacebookAuthentication : System.Web.UI.Page
{
    cls_Sepet cS = new cls_Sepet();
    public static int Gel_FaceTo;
    protected void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key = Ortak.Face_API_Key.ToString();
        FaceBookConnect.API_Secret = Ortak.Face_API_Secret.ToString();
        if (!IsPostBack)
        {
            if (Request.QueryString["code"] == null)
            {
                FaceBookConnect.Authorize("user_photos,email,user_location,user_birthday", Request.Url.AbsoluteUri.Split('?')[0]);
            }
            else
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kullanıcı Erişimi Red Edildi.)", true);
                    return;
                }
                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    Gel_FaceTo = cls_Uyeler.KontrolEtUyemi_FaceBook(faceBookUser.UserName, faceBookUser.Id);
                    if (Gel_FaceTo > 0)
                    {
                        string[] GelBilgi = { Gel_FaceTo.ToString(), faceBookUser.Name };
                        Veritabani_Uyenin_Sepeti_Gel(Gel_FaceTo.ToString());
                        Session.Add("E_ticaretim", GelBilgi);
                        Response.Redirect("Hesabim.aspx");
                    }
                    else
                    {
                        Gel_FaceTo = cls_Uyeler.Kullanici_KayitEkle_Facebook(faceBookUser.UserName, faceBookUser.Id, faceBookUser.Name, faceBookUser.Email);
                        if (Gel_FaceTo > 0)
                        {
                            string[] GelBilgi = { Gel_FaceTo.ToString(), faceBookUser.Name };
                            Veritabani_Uyenin_Sepeti_Gel(Gel_FaceTo.ToString());
                            Session.Add("E_ticaretim", GelBilgi);
                            Response.Redirect("Hesabim.aspx");
                        }
                    }
                    //faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    //pnlFaceBookUser.Visible = true;
                    //lblId.Text = faceBookUser.Id;
                    //lblUserName.Text = faceBookUser.UserName;
                    //lblName.Text = faceBookUser.Name;
                    //lblEmail.Text = faceBookUser.Email;
                    //ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                    //lblBirthday.Text = faceBookUser.Birthday;
                    //lblGender.Text = faceBookUser.Gender;
                    //lblLocation.Text = faceBookUser.Location.Name;
                    //btnLogin.Enabled = false;
                }
            }
        }
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
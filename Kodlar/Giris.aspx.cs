using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using ASPSnippets.TwitterAPI;

public partial class Giris : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    cls_Giris g = new cls_Giris();
    cls_Hesabim cH = new cls_Hesabim();
    cls_Sepet cS = new cls_Sepet();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void FacebookBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacebookAuthentication.aspx");
    }
    protected void TwitterBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TwitterAuthentication.aspx");
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
    protected void GirisBtn_Click(object sender, EventArgs e)
    {
        try
        {
            SifreBox.Attributes.Add("value", SifreBox.Text);
            string sifre = SifreBox.Text;
            string[] GelBilgi = g.Giris_Kontrol(KullaniciAdiBox.Text, sifre);
            if (!string.IsNullOrEmpty(GelBilgi[0]))
            {
                Veritabani_Uyenin_Sepeti_Gel(GelBilgi[0].ToString());
                Session.Add("E_ticaretim", GelBilgi);
                Response.Redirect("Hesabim.aspx");
            }
            else
            {
                Ortak.MesajGoster("Kullanıcı adı yada şifre hatalı !!");
            }
        }
        catch (Exception)
        {
            //Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
            SifreBox.Text = "";
            SifreBox.Attributes.Add("value", "");
        }
    }
    protected void SifremiUnuttumBtn_Click(object sender, EventArgs e)
    {
        SifremiUnuttumBtn.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(SifremiUnuttumBtn, "").ToString());
        GelBilgi();
    }
    private void GelBilgi()
    {
        try
        {
            string[] Gelen = g.GidenBilgi(SifremiUnuttumEpostaBox.Text);
            if (!string.IsNullOrEmpty(Gelen[0]))
            {
                string EpostsAdres = SifremiUnuttumEpostaBox.Text;
                string personel = Gelen[0].ToString();
                personel = Ortak.Decrypt(personel);
                string Sifre = Gelen[1].ToString();
                Sifre = Ortak.Decrypt(Sifre);
                string mesaj = "Sayın " + personel + "\n\r" + Ortak.E_Ticaret_SiteAdi + " kayıtlı üyelik bilgileriniz aşağıdaki gibidir.\n\rKullanıcı Adınız :" + EpostsAdres + "\n\rŞifreniz :" + Sifre + "\n\r\n\r" + "*Bu yalnızca gönderim amaçlı bir e-posta adresidir. Bu iletiyi yanıtladığınızda, yanıtınız izlenmez veya cevaplanmaz.\n\rSaygılarımızla...\r" + Ortak.E_Ticaret_SiteAdi + "\r" + Ortak.Eposta + "\r" + Ortak.SiteAdresi_http;
                MailSend.SifreYenileMail(EpostsAdres, "Şifre Hatırlatma | " + Ortak.E_Ticaret_SiteAdi, mesaj);
                SifreBox.Text = "";
                Ortak.MesajGoster("Şifre E-Posta Adresine Gönderilmiştir.");
                SifremiUnuttumDiv.Visible = false;
                KullaniciAdiBox.Text = "";
                SifreBox.Text = "";
                SifremiUnuttumEpostaBox.Text = "";
            }
            else
            {
                Ortak.MesajGoster("E-posta adresi bulanamadı ya da hatalı. Lütfen tekrar deneyiniz.");//!!! Dil
            }
        }
        catch (Exception)
        {
            Ortak.MesajGoster("Hata !!! Lütfen bilgileri kontrol edip tekrar deneyiniz.");//Dil !!!
        }
        finally
        {
            con.Close();
        }
    }
    protected void SifremiUnuttumLink_Click(object sender, EventArgs e)
    {
        SifremiUnuttumDiv.Visible = true;
    }
}
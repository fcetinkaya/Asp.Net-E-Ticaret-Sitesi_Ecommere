using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_SifreDegistirme : System.Web.UI.Page
{
    cls_Admin_Sifre s = new cls_Admin_Sifre();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["eticaret"] != null)
        {
            if (!IsPostBack)
            {
                Label label = Master.FindControl("UrlMaplbl") as Label;
                label.Text = "Şifre İşlemleri";
                Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                label2.Text = "Şifre İşlemleri";
            }
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    protected void SifreDegistir_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            SifreDegistir_Btn.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(SifreDegistir_Btn, "").ToString());
            SifreDegistirBox.Attributes.Add("value", SifreDegistirBox.Text);
            string sifre = SifreDegistirBox.Text;
            if (s.Pass_Update(sifre) == true)
            {
                SifreDegistirBox.Text = "";
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = " Şifre başarılı ile değiştirildi.";
                HataVar.Visible = false;
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
            SifreDegistirBox.Text = "";
            SifreDegistirBox.Attributes.Add("value", "");
        }
        finally
        {
            SifreDegistirBox.Text = "";
            SifreDegistirBox.Attributes.Add("value", "");
        }
    }
}
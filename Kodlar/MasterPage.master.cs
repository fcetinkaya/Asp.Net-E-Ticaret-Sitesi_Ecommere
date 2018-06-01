using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    cls_Sepet cS = new cls_Sepet();
    public static string Gelen_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AramaBox.Attributes.Add("onkeypress", "javascript:return WebForm_FireDefaultButton(event, '" + AramaBtn.ClientID + "')");
            if (Session["E_ticaretim"] != null)
            {
                string[] GelenBilgi = (string[])Session["E_ticaretim"];
                UyeGirisDiv.Visible = false;
                GirisOnayDiv.Visible = true;
                Gelen_ID = GelenBilgi[0].ToString();
                string AdSoyad = GelenBilgi[1].ToString();
                string Yazi = "Merhaba, " + AdSoyad + " (Çıkış)";
                CikisLinkBtn.Text = Yazi;
              //  SepetAdetLbl.Text = SepetToplamAdet_UyeGiris().ToString();
            }
            else
            {
                UyeGirisDiv.Visible = true;
                GirisOnayDiv.Visible = false;
            //    SepetAdetLbl.Text = SepetToplamAdet().ToString();
            }
            SepetAdetLbl.Text = SepetToplamAdet().ToString();
        }
    }
    public int SepetToplamAdet()
    {
        int toplamAdet = 0;
        if (Session["sepet"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            toplamAdet = Convert.ToInt32(dt.Rows.Count);
        }
        return toplamAdet;
    }
    public int SepetToplamAdet_UyeGiris()
    {
        int toplamAdet = cS.Uyenin_Sepet_Adeti(Gelen_ID);
        return toplamAdet;
    }
    protected void AramaBtn_Click(object sender, EventArgs e)
    {
        string KelimeGit = "Arama.aspx?ct=" + AramaBox.Text;
        Response.Redirect(KelimeGit);
    }
    protected void CikisLinkBtn_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        FormsAuthentication.SignOut();
        Response.Cookies["E_ticaretim"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Giris.aspx");
    }
}

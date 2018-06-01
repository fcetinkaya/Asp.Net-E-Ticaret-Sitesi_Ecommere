using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiparisKargoTakibi : System.Web.UI.Page
{
    cls_Kargo K = new cls_Kargo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["E_ticaretim"] != null)
        {
            string[] Gelenler = (string[])Session["E_ticaretim"];
            string GelenID = Gelenler[0].ToString();
            if (!IsPostBack)
            {
                DataTable dt = K.Kargolari_Getir(GelenID);
                if (dt.Rows.Count != 0)
                {
                    KargoBilgiDatalist.DataSource = dt;
                    KargoBilgiDatalist.DataBind();
                    KargoYokDiv.Visible = false;
                }
                else
                {
                    KargoBilgiDatalist.DataBind();
                    KargoYokDiv.Visible = true;
                }
            }
        }
        else
        {
            Response.Redirect("Giris.aspx");
        }
    }
    protected void KargoBilgiDatalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string Sno = DataBinder.Eval(e.Item.DataItem, "SiparisNo").ToString();
            HyperLink Sdetay = e.Item.FindControl("SiparisNoLink") as HyperLink;
            Sdetay.NavigateUrl = "SiparisDetay-" + Sno + ".aspx";
            HyperLink Kdetay = e.Item.FindControl("KargoDetayLink") as HyperLink;
            Kdetay.NavigateUrl = "KargoDetay-" + Sno + ".aspx";
            Label Takip = e.Item.FindControl("TakipNoLbl") as Label;
            Takip.Text = Ortak.Decrypt(Takip.Text);
        }
    }
}
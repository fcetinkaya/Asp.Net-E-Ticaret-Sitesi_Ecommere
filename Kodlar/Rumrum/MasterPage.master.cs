using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            E_TicaretSitesiLink.NavigateUrl = Ortak.SiteAdresi_http;
        }
    }
    protected void Cikis_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
}

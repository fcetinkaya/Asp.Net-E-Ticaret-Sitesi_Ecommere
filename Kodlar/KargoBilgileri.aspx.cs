using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KargoBilgileri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSitesiLbl.Text = Ortak.SiteAdresi;
        WebSitesiLbl2.Text = Ortak.SiteAdresi;
    }
}
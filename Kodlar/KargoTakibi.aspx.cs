using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KargoTakibi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSitesiLbl.Text = Ortak.SiteAdresi;
        KargoLbl.Text = Ortak.KargoFirmalari;
        KargoLbl2.Text = Ortak.KargoFirmalari;
        KargoLbl3.Text = Ortak.KargoFirmalari;
    }
}
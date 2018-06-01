using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsanKaynaklari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSitesiLbl.Text = Ortak.SiteAdresi;
        WebSitesiLbl2.Text = Ortak.WebSitesiBuyukIsim;
        WebSitesiLbl3.Text = Ortak.WebSitesiBuyukIsim;
        WebSitesiLbl4.Text = Ortak.SiteAdresi;
        EpostaLbl.Text = Ortak.Eposta;
    }
}
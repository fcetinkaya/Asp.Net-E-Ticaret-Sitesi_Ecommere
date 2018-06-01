using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SatisSozlesmesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SirketAdiLbl.Text = Ortak.SirketAdi;
        WebSitesiLbl.Text = Ortak.SiteAdresi;
        WebSitesiLbl2.Text = Ortak.SiteAdresi;
        AdresLbl.Text = Ortak.Adresi;
        TelefonLbl.Text = Ortak.Telefon;
        FaksLbl.Text = Ortak.Fax;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayPal_Basarili : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KargoAdi_Paypal_OdemeLbl.Text = Ortak.KargoFirmalari;
            FirmaAdi_Paypal_Odeme_Lbl.Text = Ortak.SiteAdresiKısa;
            FirmaAdi_Tesekkur_Paypal_OdemeLbl.Text = Ortak.SiteAdresiKısa;
            SiparisNo_Paypal_Odeme_Lbl.Text = "";
            Odeme_Paypal_TutarLbl.Text = "";
        }
    }
}
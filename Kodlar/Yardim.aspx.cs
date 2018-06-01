using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yardim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        UcretsizKargoBedeliLbl.Text = Ortak.UcretsizKargoBedeli;
        if (!IsPostBack)
        {
            BankaRepeater.DataSource = cls_Banka.GelBankaBilgiler();
            BankaRepeater.DataBind();
            WebSitesiLbl.Text = Ortak.SiteAdresi;
            WebSitesiLbl.Text = Ortak.SiteAdresi;
            WebSitesiLbl2.Text = Ortak.SiteAdresi;
            WebSitesiLbl3.Text = Ortak.SiteAdresi;
            WebSitesiLbl4.Text = Ortak.SiteAdresi;
            FirmaAdiLbl.Text = Ortak.SirketAdi;
            FirmaAdiLbl2.Text = Ortak.SirketAdi;
            KargoLbl.Text = Ortak.KargoFirmalari;
            KargoLbl2.Text = Ortak.KargoFirmalari;
            KargoLbl3.Text = Ortak.KargoFirmalari;
            KargoLbl4.Text = Ortak.KargoFirmalari;
            KargoLbl5.Text = Ortak.KargoFirmalari;
            KargoLbl6.Text = Ortak.KargoFirmalari;
            KargoLbl7.Text = Ortak.KargoFirmalari;
        }
    }
}
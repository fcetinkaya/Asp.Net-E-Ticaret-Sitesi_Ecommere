using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BankaHesap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BankaRepeater.DataSource = cls_Banka.GelBankaBilgiler();
            BankaRepeater.DataBind();
        }
    }
}
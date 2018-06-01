using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Data;

public partial class KargoDetay : System.Web.UI.Page
{
    cls_Kargo K = new cls_Kargo();
    SqlConnection con = new SqlConnection(Yol.ECon);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["E_ticaretim"] != null)
            {
                if (RouteData.Values["KargoNo"] != null)
                {
                    if (!IsPostBack)
                    {
                        string Siparis_No = RouteData.Values["KargoNo"].ToString();
                        string Gelen_Siparis_ID = K.Gel_Siparis_ID(Siparis_No);
                        SiparisNoLbl.Text = Siparis_No;
                        Gel_Kargo(Gelen_Siparis_ID);
                        if (Kargo_DataList.Items.Count == 0 && Kurye_Datalist.Items.Count == 0)
                        {
                            Kargo_YokDiv.Visible = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx");
        }
        finally
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearPool(con);
        }
    }
    public void Gel_Kurye(string _ID)
    {
        DataTable dt = K.Siparis_Kurye_Getir(_ID);
        if (dt.Rows.Count != 0)
        {
            Kurye_Datalist.DataSource = dt;
            Kurye_Datalist.DataBind();
            Kurye_Panel.Visible = true;
        }
        else
        {
            Kurye_Datalist.DataBind();
            Kurye_Panel.Visible = false;
        }
    }
    public void Gel_Kargo(string _ID)
    {
        DataTable dt = new DataTable();
        if (dt.Rows.Count != 0)
        {
            Kargo_DataList.DataSource = dt;
            Kargo_DataList.DataBind();
            Kargo_Panel.Visible = true;
        }
        else
        {
            Kargo_DataList.DataBind();
            Kargo_Panel.Visible = false;
        }
    }
}
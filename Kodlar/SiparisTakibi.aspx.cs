using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiparisTakibi : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    cls_Siparis cS = new cls_Siparis();
    private static string GelenID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["E_ticaretim"] != null)
            {
                string[] Gelenler = (string[])Session["E_ticaretim"];
                GelenID = Gelenler[0].ToString();
                if (!IsPostBack)
                {
                    GelSiparisler();
                    DurumGel();
                }
            }
            else
            {
                Response.Redirect("Giris.aspx",false);
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
    private void GelSiparisler()
    {
        DataTable dt = cS.GelSiparisler(GelenID);
        if (dt.Rows.Count != 0)
        {
            SiparisListesi_DataList.DataSource = dt;
            SiparisListesi_DataList.DataBind();
            panelsepet.Visible = true;
            SiparisYokDiv.Visible = false;
        }
        else
        {
            panelsepet.Visible = false;
            SiparisYokDiv.Visible = true;
        }
    }
    private void GelSiparisler_Hepsi()
    {
        DataTable dt = cS.GelSiparisler_Hepsi(GelenID);
        if (dt.Rows.Count != 0)
        {
            SiparisListesi_DataList.DataSource = dt;
            SiparisListesi_DataList.DataBind();
            panelsepet.Visible = true;
            SiparisYokDiv.Visible = false;
        }
        else
        {
            panelsepet.Visible = false;
            SiparisYokDiv.Visible = true;
        }
    }
    private void DurumGel()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_SiparisDurumu", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        if (dt != null)
        {
            DataRow dr = dt.NewRow();
            dr["DurumAd"] = "Lütfen Seçiniz";
            dt.Rows.InsertAt(dr, 0);
            SiparisDurumuDrop.DataSource = dt;
            SiparisDurumuDrop.DataTextField = "DurumAd";
            SiparisDurumuDrop.DataValueField = "E_Siparis_DurumuID";
            SiparisDurumuDrop.DataBind();
        }
    }
    private void GelSiparisler_DurumuGore()
    {
        DataTable dt = cS.GelSiparisler_DurumaGore(SiparisDurumuDrop.SelectedValue.ToString(), GelenID);
        if (dt.Rows.Count != 0)
        {
            SiparisListesi_DataList.DataSource = dt;
            SiparisListesi_DataList.DataBind();
            Durum_YokDiv.Visible = false;
        }
        else
        {
            SiparisListesi_DataList.DataBind();
            Durum_YokDiv.Visible = true;
        }
    }
    protected void TumunuButtton_Click(object sender, EventArgs e)
    {
        try
        {

            GelSiparisler_Hepsi();

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
    protected void ListeleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (SiparisDurumuDrop.SelectedIndex != 0)
            {
                GelSiparisler_DurumuGore();
            }
            else
            {
                Ortak.MesajGoster("Lütfen Sipariş Durumunu Seçiniz.");
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
    protected void SiparisListesi_DataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string Sno = DataBinder.Eval(e.Item.DataItem, "SiparisNo").ToString();
            LinkButton Sdetay = e.Item.FindControl("DetayID") as LinkButton;
            RouteValueDictionary parametremiz = new RouteValueDictionary()
            {
               {"SiparisNo",Sno}
            };
            VirtualPathData sanalcik = RouteTable.Routes.GetVirtualPath(null, "SiparisDetay", parametremiz);
            Sdetay.PostBackUrl = sanalcik.VirtualPath;
        }
    }
}
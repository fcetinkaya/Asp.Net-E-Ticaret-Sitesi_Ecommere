using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_IletisimMesajlari : System.Web.UI.Page
{
    cls_Admin_IletisimMesajlari IM = new cls_Admin_IletisimMesajlari();
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select Log_Index from E_Iletisim_Bildirim where Log_Index like '%" + prefixText + "%' group by Log_Index", conn))
            {
                //  cmd.Parameters.AddWithValue("@SearchText", prefixText);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Log_Index"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchCustomers_Ara(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection(Yol.ECon))
        {
            using (SqlCommand cmd = new SqlCommand("select Log_Index from E_AraBeni_Bildirim where Log_Index like '%" + prefixText + "%' group by Log_Index", conn))
            {
                //  cmd.Parameters.AddWithValue("@SearchText", prefixText);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Log_Index"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "İade / Değişim Bildirimleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "İade / Değişim  Bildirimleri";
                    Gel_Iletisim_Mesajlari();
                    Gel_AraBeni_Mesajlari();
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    public void Gel_Iletisim_Mesajlari()
    {
        DataTable dt = IM.Iletisim_Mesajlari_Tumu();
        if (dt.Rows.Count != 0)
        {
            Iletisim_Grid.DataSource = dt;
            Iletisim_Grid.DataBind();
            Iletisim_Grid_KayitYokDiv.Visible = false;
            HataVar.Visible = false;
        }
        else
        {
            Iletisim_Grid_KayitYokDiv.Visible = true;
            Iletisim_Grid.DataBind();
        }
    }
    protected void Iletisim_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Iletisim_Grid.PageIndex = e.NewPageIndex;
        Gel_Iletisim_Mesajlari();
        Iletisim_Grid.DataBind();
    }
    protected void Iletisim_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Kapat")
        {
            if (IM.Iletisim_Bildirimi_Kapat(e.CommandArgument.ToString()) == true)
            {
                Gel_Iletisim_Mesajlari();
                Ortak.MesajGoster("Bildirim Kapatıldı.");
            }
        }
    }
    protected void Iletisim_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Adi_soyadi = e.Row.FindControl("lblMusteriAdi") as Label;
            Label Adi_soyadi_Detay = e.Row.FindControl("lblMusteriAdi_detay") as Label;
            Label E_posta = e.Row.FindControl("lblMusteriEposta") as Label;
            Label E_posta_Detay = e.Row.FindControl("lblMusteriEposta_Detay") as Label;
            Label CepTlf_Detay = e.Row.FindControl("lblCepTlf") as Label;
            LinkButton Kapat = e.Row.FindControl("KapatBtn") as LinkButton;
            Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            Adi_soyadi_Detay.Text = Adi_soyadi.Text;
            E_posta.Text = Ortak.Decrypt(E_posta.Text);
            E_posta_Detay.Text = E_posta.Text;
            CepTlf_Detay.Text = Ortak.Decrypt(CepTlf_Detay.Text);
            bool Tukendi = Convert.ToBoolean(dr["Okundu"]);
            if (Tukendi == true)
            {
                Kapat.Enabled = false;
                Kapat.Text = "Bildirim Kapalı";
                Kapat.ForeColor = System.Drawing.Color.Black;
                Kapat.Font.Bold = true;
            }
        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Iletisim_AdSoyad_Box.Text))
            {
                DataTable dt = IM.Iletisim_Mesajlari_Arama_Kriter(Iletisim_AdSoyad_Box.Text);
                if (dt.Rows.Count != 0)
                {
                    Iletisim_Grid.DataSource = dt;
                    Iletisim_Grid.DataBind();
                    Iletisim_Grid_KayitYokDiv.Visible = false;
                    Iletisim_AdSoyad_Box.Text = "";
                }
                else
                {
                    Iletisim_Grid_KayitYokDiv.Visible = true;
                    Iletisim_Grid.DataBind();
                    Iletisim_AdSoyad_Box.Text = "";
                }
            }
            else
            {
                Ortak.MesajGoster("Adını ve Soyadını yazınız.");
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    //AraBeni
    public void Gel_AraBeni_Mesajlari()
    {
        DataTable dt = IM.AraBeni_Mesajlari_Tumu();
        if (dt.Rows.Count != 0)
        {
            AraBeni_Grid.DataSource = dt;
            AraBeni_Grid.DataBind();
            AraBeni_Grid_KayitYokDiv.Visible = false;
            HataVar.Visible = false;
        }
        else
        {
            AraBeni_Grid_KayitYokDiv.Visible = true;
            AraBeni_Grid.DataBind();
        }
    }
    protected void AraBeni_AramaBaslatBtn_Click_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(AraBeni_AdSoyad_Box.Text))
            {
                DataTable dt = IM.AraBeni_Mesajlari_Arama_Kriter(AraBeni_AdSoyad_Box.Text);
                if (dt.Rows.Count != 0)
                {
                    AraBeni_Grid.DataSource = dt;
                    AraBeni_Grid.DataBind();
                    AraBeni_Grid_KayitYokDiv.Visible = false;
                    AraBeni_AdSoyad_Box.Text = "";
                }
                else
                {
                    AraBeni_Grid_KayitYokDiv.Visible = true;
                    AraBeni_Grid.DataBind();
                    AraBeni_AdSoyad_Box.Text = "";
                }
            }
            else
            {
                Ortak.MesajGoster("Adını ve Soyadını yazınız.");
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void AraBeni_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AraBeni_Grid.PageIndex = e.NewPageIndex;
        Gel_AraBeni_Mesajlari();
        AraBeni_Grid.DataBind();
    }
    protected void AraBeni_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Kapat")
        {
            if (IM.AraBeni_Bildirimi_Kapat(e.CommandArgument.ToString()) == true)
            {
                Gel_AraBeni_Mesajlari();
                Ortak.MesajGoster("Bildirim Kapatıldı.");
            }
        }
    }
    protected void AraBeni_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Adi_soyadi = e.Row.FindControl("lblMusteriAdi") as Label;
            Label CepTlf_Detay = e.Row.FindControl("lblMustericep") as Label;
            LinkButton Kapat = e.Row.FindControl("KapatBtn") as LinkButton;
            Adi_soyadi.Text = Ortak.Decrypt(Adi_soyadi.Text);
            CepTlf_Detay.Text = Ortak.Decrypt(CepTlf_Detay.Text);
            bool Tukendi = Convert.ToBoolean(dr["Okundu"]);
            if (Tukendi == true)
            {
                Kapat.Enabled = false;
                Kapat.Text = "Bildirim Kapalı";
                Kapat.ForeColor = System.Drawing.Color.Black;
                Kapat.Font.Bold = true;
            }
        }
    }
}
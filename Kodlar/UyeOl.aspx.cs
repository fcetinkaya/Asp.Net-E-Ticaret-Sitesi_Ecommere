using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeOl : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    private static string sifre;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SehirGetir();
        }
    }
    protected void FacebookBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacebookAuthentication.aspx");
    }
    protected void TwitterBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TwitterAuthentication.aspx");
    }
    protected void KayitBtn_Click(object sender, EventArgs e)
    {
        KayitBtn.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(KayitBtn, "").ToString());
        SifreTekrarBox.Attributes.Add("value", SifreTekrarBox.Text);
        sifre = SifreTekrarBox.Text;
        if (cls_Uyeler.KontrolEtUyemi(EPostaBox.Text) == false)
        {
            if (Session["SecuriyCode"].ToString() == GuvenlikKodubox.Text.ToUpper())
            {
                if (SozlemeOkudumCheckBox.Checked)
                {
                    KayitEkle();
                    Response.Redirect("Giris.aspx");
                }
                else
                {
                    Ortak.MesajGoster("Üyelik sözleşmesini kabul ediniz !!");
                }
            }
            else
            {
                Ortak.MesajGoster("Güvenlik kodu hatalı !!");
            }
        }
        else
        {
            Ortak.MesajGoster("Bu e-posta adresi sistemde kayıtlıdır. Lütfen farklı bir e-posta adresi kullanın !!");
        }
    }
    public void KayitEkle()
    {
        try
        {
            if (cls_Uyeler.Kullanici_KayitEkle(AdSoyadBox.Text, EvTlfBox.Text, IsTlfBox.Text, CepTlfBox.Text, SehirDrop.SelectedValue, IlceDrop.SelectedValue, EPostaBox.Text, sifre) == true)
            {
                Basarali_Div.Visible = true;
            }
        }
        catch (Exception)
        {
            Response.Redirect("Hata.aspx",false);
        }
        finally
        {
            con.Close();
        }
    }
    private void SehirGetir()
    {
        DataTable dt = cls_DataAdaptore.TumSehirGetir();
        DataRow dr = dt.NewRow();
        dr["il_ad"] = "Lütfen Şehir Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        SehirDrop.DataSource = dt;
        SehirDrop.DataValueField = "il_id";
        SehirDrop.DataTextField = "il_ad";
        SehirDrop.DataBind();
    }
    private void IlceGetirSehirSecimeGore(string GelenSehirID)
    {
        DataTable dt = cls_DataAdaptore.IlceGetirSehirSecimeGore(GelenSehirID);
        DataRow dr = dt.NewRow();
        dr["ilce_ad"] = "Lütfen İlçe Seçiniz";
        dt.Rows.InsertAt(dr, 0);
        IlceDrop.DataSource = dt;
        IlceDrop.DataValueField = "ilce_id";
        IlceDrop.DataTextField = "ilce_ad";
        IlceDrop.DataBind();
    }
    protected void SehirDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SehirDrop.SelectedIndex != 0)
        {
            IlceDrop.Items.Clear();
            string Sehir_GelenID = SehirDrop.SelectedValue;
            IlceDrop.Enabled = true;
            IlceGetirSehirSecimeGore(Sehir_GelenID);
        }
    }
}
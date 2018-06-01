using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rumrum_EBulten_ExcelTopluAktar : System.Web.UI.Page
{
    cls_Admin_Ebulten E = new cls_Admin_Ebulten();
    public static string Gel_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["eticaret"] != null)
            {
                if (!IsPostBack)
                {
                    Label label = Master.FindControl("UrlMaplbl") as Label;
                    label.Text = "Excel E-Posta İşlemleri";
                    Label label2 = Master.FindControl("TepeMesajLbl") as Label;
                    label2.Text = "Excel E-Posta Adresleri Kayıt İşlemleri";
                    GelExcelDosyaBilgiler();
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
    private string ExcelUpload(string _Gelen_Dosya)
    {
        string filefolder = Server.MapPath("../ExcelUpload/");
        string filename = Path.GetFileName(_Gelen_Dosya);
        string filepath = filefolder + filename;
        try
        {
            if (!System.IO.Directory.Exists(filefolder))
            {
                System.IO.Directory.CreateDirectory(filefolder);
            }
            FileUpload1.PostedFile.SaveAs(filepath);
        }
        catch (Exception)
        {
            Ortak.MesajGoster("Hata!! Lütfen bilgileri kontrol edip daha sonra deneyiniz.");
        }
        return filepath;
    }
    public void GelExcelDosyaBilgiler()
    {
        DataTable dt = E.Listeler_Excel();
        if (dt.Rows.Count != 0)
        {
            EPostaListesi_Grid.DataSource = dt;
            EPostaListesi_Grid.DataBind();
            GridKayitYokDiv.Visible = false;
            ToplamAdetLbl.Text = dt.Rows.Count.ToString();
        }
        else
        {
            EPostaListesi_Grid.DataBind();
            GridKayitYokDiv.Visible = true;
        }
    }
    private DataTable ReadFromExcelData(string _File_Name)
    {
        string dosyaYolum = ExcelUpload(_File_Name);
        OleDbDataAdapter da;
        DataTable dTableExcel = new DataTable();
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dosyaYolum + ";Extended Properties=Excel 12.0;";
        try
        {
            da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
            da.Fill(dTableExcel);
        }
        catch (Exception)
        {
            da = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", strConn);
            da.Fill(dTableExcel);
        }
        return dTableExcel;
    }
    protected void ExcelVeriAlBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = Guid.NewGuid().ToString().Remove(6) + "-" + FileUpload1.FileName.ToString();
            int GeliyorAydim = E.Excel_Dosyasi_Kayit(grupadibox.Text);
            if (GeliyorAydim > 0)
            {
                DataTable dtCopy = ReadFromExcelData(filename);
                int Adet = dtCopy.Rows.Count;
                for (int i = 0; i < Adet; i++)
                {
                    E.Kayit_Excel(dtCopy.Rows[i][0].ToString(), GeliyorAydim.ToString());
                }
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = dtCopy.Rows.Count.ToString()+ " adet adres başarı ile kaydedildi.";
                grupadibox.Text = "";
              //  File.Delete(filename);
                HataVar.Visible = false;
                E.Kayit_Temizle_Mukkerer_Olanlari();
            }
            GelExcelDosyaBilgiler();
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void EPostaListesi_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EPostaListesi_Grid.PageIndex = e.NewPageIndex;
        GelExcelDosyaBilgiler();
        EPostaListesi_Grid.DataBind();
    }
    protected void EPostaListesi_Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sil")
            {
                if (E.Delete(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta başarı ile silindi.";
                    HataVar.Visible = false;
                    GelExcelDosyaBilgiler();
                }
            }
            else if (e.CommandName == "Gitsin")
            {
                if (E.E_PostaGidecek(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta adresine e-bülten gidecektir.";
                    HataVar.Visible = false;
                    GelExcelDosyaBilgiler();
                }
            }
            else if (e.CommandName == "Gitmesin")
            {
                if (E.E_PostaGitmeyecek(e.CommandArgument.ToString()))
                {
                    KayitTamam.Visible = true;
                    KayitTamamLbl.Text = "E-Posta adresine e-bülten gitmeyecektir.";
                    HataVar.Visible = false;
                    GelExcelDosyaBilgiler();
                }
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void EPostaListesi_Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            Label Durum = (Label)e.Row.FindControl("DurumLbl");
            Label Eposta = (Label)e.Row.FindControl("lblEpostaAdresi");
            ImageButton Gitsin = (ImageButton)e.Row.FindControl("EPostaGitsin");
            ImageButton Gitmesin = (ImageButton)e.Row.FindControl("EpostaGitmesin");
            Eposta.Text = Ortak.Decrypt(Eposta.Text.Trim());
            bool gidecek = Convert.ToBoolean(dr["Gidecek"]);
            if (gidecek == true)
            {
                Durum.Text = "E-Bülten Gidiyor";
                Durum.ForeColor = System.Drawing.Color.Black;
                Durum.Font.Bold = true;
                Gitsin.Visible = false;
            }
            else
            {
                Durum.Text = "E-Bülten Gitmiyor";
                Durum.ForeColor = System.Drawing.Color.Red;
                Durum.Font.Bold = true;
                Gitmesin.Visible = false;
            }

        }
    }
    protected void AramaBaslatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = E.Listeler_Excel_Ara(Eposta_Arabox.Text.Trim());
            if (dt.Rows.Count != 0)
            {
                EPostaListesi_Grid.DataSource = dt;
                EPostaListesi_Grid.DataBind();
                GridKayitYokDiv.Visible = false;
            }
            else
            {
                GridKayitYokDiv.Visible = true;
                EPostaListesi_Grid.DataBind();
            }
        }
        catch (Exception)
        {
            //   BilgilerDiv.Visible = false;
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
    protected void DuzenleBtn_Click(object sender, EventArgs e)
    {
        ImageButton G = sender as ImageButton;
        Gel_Id = G.CommandArgument.ToString();
        Guncelle_EpostaAdresiBox.Text = Ortak.Decrypt(G.AlternateText);
        mpe.Show();
    }
    protected void KaydetBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (E.Guncelle(Guncelle_EpostaAdresiBox.Text.Trim(), Gel_Id) == true)
            {
                EPostaListesi_Grid.EditIndex = -1;
                KayitTamam.Visible = true;
                KayitTamamLbl.Text = Guncelle_EpostaAdresiBox.Text + "  adresi başarı ile güncellendi.";
                HataVar.Visible = false;
                GelExcelDosyaBilgiler();
            }
            else
            {
                KayitTamam.Visible = false;
                HataVar.Visible = true;
                EPostaListesi_Grid.EditIndex = -1;
            }
        }
        catch (Exception)
        {
            KayitTamam.Visible = false;
            HataVar.Visible = true;
        }
    }
}
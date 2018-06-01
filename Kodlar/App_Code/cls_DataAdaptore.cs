using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_DataAdaptore
/// </summary>
public class cls_DataAdaptore : IDisposable
{
    public static DataTable TumSehirGetir()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select il_id,il_ad from E_tbl_il order by il_ad asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable IlceGetirSehirSecimeGore(string GelenIlD)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter daIlceG = new SqlDataAdapter("select ilce_id,ilce_ad from E_tbl_ilce where il_id=@ID order by ilce_ad", con);
        daIlceG.SelectCommand.Parameters.AddWithValue("@ID", GelenIlD);
        DataTable dt = new DataTable();
        daIlceG.Fill(dt);
        return dt;
    }
    public static DataTable Telefon_Marka()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select TelefonID,TelAdi from E_TelefonMarka where IsActive=1 order by TelAdi asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable Kategori_Getir()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select KategoriID,KategoriAdi from E_UrunKategori where IsActive=1 order by KategoriAdi asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable Ana_Kategori_Getir()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select AnaKategoriID,AnaKategoriAdi from E_UrunAnaKategori where IsActive=1 order by AnaKategoriAdi asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable Siparis_Getir(string Uye_ID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisID,SiparisNoFiyat from E_SiparisTakip where UyeID=@ID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", Uye_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable Banka_Getir()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_BankaID,BankaAdi from E_UrunDetay_Banka where IsActive=1 order by BankaAdi asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public static DataTable Firma_BankaHesabi_Getir()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_BankaID,BankaAdi from E_BankaHesap order by BankaAdi asc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }

    public static int Banka_Taksit_Getir(string Banka_ID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlCommand dap = new SqlCommand("select TaksitSayisi from E_UrunDetay_Banka where IsActive=1 and E_BankaID=@BID order by TaksitSayisi asc", con);
        dap.Parameters.AddWithValue("@BID", Banka_ID);
        if (con.State==ConnectionState.Closed)
        {
            con.Open();
        }
        int GelenSayi = 0;
        SqlDataReader dr = dap.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                GelenSayi = Convert.ToInt32(dr[0]);
            }
        }
        con.Close();
        dap.Dispose();
        return GelenSayi;
    }
    public static DataTable Telefon_Marka_Model(string TelefonID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select TelefonModelID,ModelAdi from E_TelefonModeller where IsActive=1 and TelefonID=@ID order by ModelAdi asc", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TelefonID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
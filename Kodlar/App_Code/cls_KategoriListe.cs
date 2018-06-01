using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_KategoriListe
/// </summary>
public class cls_KategoriListe : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable EnCokSatanlar(string KategoriID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KategoriID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable RouteID_GoreGetir_Urunleri(string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatArtana_GoreGetir_Urunleri(string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler  where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by YeniFiyat desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatAzalan_GoreGetir_Urunleri(string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by YeniFiyat", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AdanZye_GoreGetir_Urunleri(string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler  where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by UrunAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ZdenAya_GoreGetir_Urunleri(string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler  where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@ID) order by UrunAdi desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string[] KategorilerBilgisiGetir(string RouteAdi)
    {
        string[] Git = new string[2];
        SqlCommand comG = new SqlCommand("select KategoriID,KategoriAdi from E_UrunKategori where RouteKatAdi=@Kat", con);
        comG.Parameters.AddWithValue("@Kat", RouteAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comG.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["KategoriID"].ToString();
                Git[1] = dr["KategoriAdi"].ToString();
            }
        }
        else
        {
            Git[0] = "";
        }
        con.Close();
        comG.Dispose();
        return Git;
    }
    public string[] Ana_KategorilerBilgisiGetir(string RouteAdi)
    {
        string[] Git = new string[2];
        SqlCommand comG = new SqlCommand("select AnaKategoriID,AnaKategoriAdi from E_UrunAnaKategori where RouteKatAdi=@Kat", con);
        comG.Parameters.AddWithValue("@Kat", RouteAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comG.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["AnaKategoriID"].ToString();
                Git[1] = dr["AnaKategoriAdi"].ToString();
            }
        }
        else
        {
            Git[0] = "";
        }
        con.Close();
        comG.Dispose();
        return Git;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
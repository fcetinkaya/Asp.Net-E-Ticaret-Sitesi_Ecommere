using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_KategoriTelefonListe
/// </summary>
public class cls_KategoriTelefonListe : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable EnCokSatanlar(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable RouteID_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AnaRouteID_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@KID) and TelefonID=@ID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    //Fiyat Azalan - Artan
    public DataTable AnaFiyatArtana_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@KID) and TelefonID=@ID order by YeniFiyat desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatArtana_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by YeniFiyat desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AnaFiyatAzalan_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@KID) and TelefonID=@ID order by YeniFiyat", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatAzalan_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by YeniFiyat", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    //Adan Zye
    public DataTable AdanZye_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by UrunAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AnaAdanZye_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@KID) and TelefonID=@ID order by UrunAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ZdenAya_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID=@KID and TelefonID=@ID order by UrunAdi desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AnaZdenAya_GoreGetir_Urunleri(string TlfID, string KatID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=@KID) and TelefonID=@ID order by UrunAdi desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@KID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@ID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string[] Kategori_Telefon_BilgisiGetir(string RouteKatAdi, string RouteTelAdi)
    {
        string[] Git = new string[4];
        SqlCommand comG = new SqlCommand("select KategoriID,KategoriAdi,(select TelefonID from E_TelefonMarka where RouteTelAdi=@Tlf) as [TelefonID],(select TelAdi from E_TelefonMarka where RouteTelAdi=@Tlf) as [TelAdi]  from E_UrunKategori where RouteKatAdi=@Kat", con);
        comG.Parameters.AddWithValue("@Kat", RouteKatAdi);
        comG.Parameters.AddWithValue("@Tlf", RouteTelAdi);
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
                Git[2] = dr["TelefonID"].ToString();
                Git[3] = dr["TelAdi"].ToString();
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
    public string[] Ana_Kategori_Telefon_BilgisiGetir(string RouteKatAdi, string RouteTelAdi)
    {
        string[] Git = new string[4];
        SqlCommand comG = new SqlCommand("select AnaKategoriID,AnaKategoriAdi,(select TelefonID from E_TelefonMarka where RouteTelAdi=@Tlf) as [TelefonID],(select TelAdi from E_TelefonMarka where RouteTelAdi=@Tlf) as [TelAdi]  from E_UrunAnaKategori where RouteKatAdi=@Kat", con);
        comG.Parameters.AddWithValue("@Kat", RouteKatAdi);
        comG.Parameters.AddWithValue("@Tlf", RouteTelAdi);
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
                Git[2] = dr["TelefonID"].ToString();
                Git[3] = dr["TelAdi"].ToString();
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
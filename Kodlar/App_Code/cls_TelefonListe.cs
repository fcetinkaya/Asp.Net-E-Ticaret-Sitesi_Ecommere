using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class cls_TelefonListe : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable EnCokSatanlar(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable RouteID_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatArtana_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by YeniFiyat desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatAzalan_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by YeniFiyat", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AdanZye_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by UrunAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ZdenAya_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by UrunAdi desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Telefona_GoreGetir_Urunleri(string TlfID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Telefon_Modele_GoreGetir_Urunleri(string TlfID, string ModID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and TelefonID=@TID and TelefonModelID=@TMID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TlfID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string[] Kategori_Telefon_BilgisiGetir(string RouteTelAdi)
    {
        string[] Git = new string[4];
        SqlCommand comG = new SqlCommand("select TelefonID,TelAdi from E_TelefonMarka where RouteTelAdi=@TelAdi", con);
        comG.Parameters.AddWithValue("@TelAdi", RouteTelAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comG.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["TelefonID"].ToString();
                Git[1] = dr["TelAdi"].ToString();
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
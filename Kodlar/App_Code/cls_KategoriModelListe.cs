using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_KategoriModelListe
/// </summary>
public class cls_KategoriModelListe : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable EnCokSatanlar(string KategoriID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KategoriID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable RouteID_GoreGetir_Urunleri(string KatID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli,Link from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by NEWID()", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatArtana_GoreGetir_Urunleri(string KatID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by YeniFiyat desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable FiyatAzalan_GoreGetir_Urunleri(string KatID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by YeniFiyat", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AdanZye_GoreGetir_Urunleri(string KatID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by UrunAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ZdenAya_GoreGetir_Urunleri(string KatID, string ModelID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID=@ID and TelefonModelID=@TMID order by UrunAdi desc", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", KatID);
        dap.SelectCommand.Parameters.AddWithValue("@TMID", ModelID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string[] KategorilerBilgisiGetir(string KatAdi)
    {
        string[] Git = new string[2];
        SqlCommand comG = new SqlCommand("select KategoriID,KategoriAdi from E_UrunKategori where RouteKatAdi=@Kat", con);
        comG.Parameters.AddWithValue("@Kat", KatAdi);
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
    public string[] TelefonModelBilgisiGetir(string ModelAdi)
    {
        string[] Git = new string[3];
        SqlCommand comG = new SqlCommand("select E_TelefonModeller.ModelAdi,E_TelefonModeller.TelefonModelID, E_TelefonMarka.TelAdi from E_TelefonModeller inner join E_TelefonMarka on E_TelefonModeller.TelefonID=E_TelefonMarka.TelefonID where E_TelefonModeller.RouteModelAdi=@MAdi", con);
        comG.Parameters.AddWithValue("@MAdi", ModelAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comG.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["TelefonModelID"].ToString();
                Git[1] = dr["ModelAdi"].ToString();
                Git[2] = dr["TelAdi"].ToString();
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
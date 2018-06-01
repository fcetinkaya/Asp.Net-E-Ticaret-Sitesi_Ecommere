using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UrunListesi
/// </summary>
public class cls_Admin_UrunListesi : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Liste_Gel()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and SatisIptal=0 and Tukendi=0 order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Liste_Gel_Arama_Kriterine_Gore(string _Arama_Kriter)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and SatisIptal=0 and Tukendi=0 " + _Arama_Kriter + " order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    // Stokta Kalmayan Ürünler
    public DataTable Liste_Gel_Stokta_Olmayan()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and Tukendi=1 order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    // Arama Kriterleri
    public DataTable Liste_Gel_Arama_Kriterine_Gore_Stokta_Olmayan(string _Arama_Kriter)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and Tukendi=1 " + _Arama_Kriter + " order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }

    //Satış İptal Ürünler
    public DataTable Liste_Gel_Satis_Olmayan()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and SatisIptal=1 order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    //Arama Kriterleri
    public DataTable Liste_Gel_Arama_Kriterine_Gore_Satis_Olmayan(string _Arama_Kriter)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=1 and SatisIptal=1 " + _Arama_Kriter + " order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

}
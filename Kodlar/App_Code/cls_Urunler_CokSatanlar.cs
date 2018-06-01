using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Urunler_CokSatanlar
/// </summary>
public class cls_Urunler_CokSatanlar : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable EnCokSatanlar_Anasayfa()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable EnCokSatanlar_Kiliflar()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID  in (select KategoriID from E_UrunKategori where UstKategoriID=1) order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable EnCokSatanlar_Koruyucu_Filmler()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=2) order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable EnCokSatanlar_SarjAletleri()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID  in (select KategoriID from E_UrunKategori where UstKategoriID=3) order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable EnCokSatanlar_Kulakliklar()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=5) order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable EnCokSatanlar_KabloveDonusturuculer()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=4) order by Tiklama", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    #region TelefonaGöreGelsin
    public DataTable TelefonaGore_EnCokSatanlar_Kiliflar(string TelID_Kilif)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=1) and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TelID_Kilif);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable TelefonaGore_EnCokSatanlar_Koruyucu_Filmler(string TelID_Film)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=2) and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TelID_Film);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable TelefonaGore_EnCokSatanlar_SarjAletleri(string TelID_SarjAletleri)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=3) and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TelID_SarjAletleri);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable TelefonaGore_EnCokSatanlar_Kulakliklar(string TelID_Kulakliklar)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=5) and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TelID_Kulakliklar);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable TelefonaGore_EnCokSatanlar_KabloveDonusturuculer(string TelID_Kablo)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=4) and TelefonID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", TelID_Kablo);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    #endregion
    #region ModelGöreGelsin
    public DataTable ModeleGore_EnCokSatanlar_Kiliflar(string ModID_Kilif)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=1) and TelefonModelID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", ModID_Kilif);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ModeleGore_EnCokSatanlar_Koruyucu_Filmler(string ModID_Film)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=2) and TelefonModelID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", ModID_Film);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ModeleGore_EnCokSatanlar_SarjAletleri(string ModID_SarjAletleri)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=3) and TelefonModelID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", ModID_SarjAletleri);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ModeleGore_EnCokSatanlar_Kulakliklar(string ModID_Kulakliklar)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=5) and TelefonModelID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", ModID_Kulakliklar);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable ModeleGore_EnCokSatanlar_KabloveDonusturuculer(string ModID_Kablo)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 30  UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,Link,Tukendi from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=4) and TelefonModelID=@TID order by Tiklama", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", ModID_Kablo);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    #endregion
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
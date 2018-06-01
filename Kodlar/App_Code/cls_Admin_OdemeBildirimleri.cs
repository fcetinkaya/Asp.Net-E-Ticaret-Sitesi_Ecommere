using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_OdemeBildirimleri
/// </summary>
public class cls_Admin_OdemeBildirimleri : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Odeme_Bildirim(string _Gel_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID,E_Odeme_Bildirim_Bilgisi.Tarih,E_Odeme_Bildirim_Bilgisi.IslemTamam,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad,E_UrunDetay_Banka.BankaAdi from E_Odeme_Bildirim_Bilgisi inner join E_SiparisTakip on E_Odeme_Bildirim_Bilgisi.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Odeme_Bildirim_Bilgisi.UyeID=E_Personel.UyeID inner join E_UrunDetay_Banka on E_UrunDetay_Banka.E_BankaID=E_Odeme_Bildirim_Bilgisi.BankaID where E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID=@ID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", _Gel_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Odeme_Bildirim_Tumu()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID,E_Odeme_Bildirim_Bilgisi.Tarih,E_Odeme_Bildirim_Bilgisi.IslemTamam,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad,E_UrunDetay_Banka.BankaAdi from E_Odeme_Bildirim_Bilgisi inner join E_SiparisTakip on E_Odeme_Bildirim_Bilgisi.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Odeme_Bildirim_Bilgisi.UyeID=E_Personel.UyeID inner join E_UrunDetay_Banka on E_UrunDetay_Banka.E_BankaID=E_Odeme_Bildirim_Bilgisi.BankaID order by E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Odeme_Bildirim_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID,E_Odeme_Bildirim_Bilgisi.Tarih,E_Odeme_Bildirim_Bilgisi.IslemTamam,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad,E_UrunDetay_Banka.BankaAdi from E_Odeme_Bildirim_Bilgisi inner join E_SiparisTakip on E_Odeme_Bildirim_Bilgisi.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Odeme_Bildirim_Bilgisi.UyeID=E_Personel.UyeID inner join E_UrunDetay_Banka on E_UrunDetay_Banka.E_BankaID=E_Odeme_Bildirim_Bilgisi.BankaID where " + _Arama_Kriter, con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Bildirimi_Kapat(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Odeme_Bildirim_Bilgisi set IslemTamam=1 where Odeme_BildirimID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Geliyor_Aydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comGuncel.ExecuteNonQuery() > 0)
        {
            con.Close();
            comGuncel.Dispose();
            return true;
        }
        else
        {
            con.Close();
            comGuncel.Dispose();
            return false;
        }
    }
    public bool Bildirimi_Ac(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Odeme_Bildirim_Bilgisi set IslemTamam=0 where Odeme_BildirimID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Geliyor_Aydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comGuncel.ExecuteNonQuery() > 0)
        {
            con.Close();
            comGuncel.Dispose();
            return true;
        }
        else
        {
            con.Close();
            comGuncel.Dispose();
            return false;
        }
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
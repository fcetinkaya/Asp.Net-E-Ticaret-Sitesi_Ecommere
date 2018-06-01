using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_UrunTalepleri
/// </summary>
public class cls_Admin_UrunTalepleri
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Urun_Talepleri()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Urunler_HaberdarEt.HaberdarEtID,E_Urunler_HaberdarEt.Eposta,E_Urunler_HaberdarEt.Aciklama,E_Urunler_HaberdarEt.IslemTamam,E_Personel.AdSoyad from E_Urunler_HaberdarEt left join E_Personel on E_Urunler_HaberdarEt.UyeID=E_Personel.UyeID", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Urun_Talepleri_Arama_Kriter(string _Eposta_Adresi)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Urunler_HaberdarEt.HaberdarEtID,E_Urunler_HaberdarEt.Eposta,E_Urunler_HaberdarEt.Aciklama,E_Urunler_HaberdarEt.IslemTamam,E_Personel.AdSoyad from E_Urunler_HaberdarEt left join E_Personel on E_Urunler_HaberdarEt.UyeID=E_Personel.UyeID where E_Urunler_HaberdarEt.Eposta=@Eposta", con);
        dap.SelectCommand.Parameters.AddWithValue("@Eposta", Ortak.Encrypt(_Eposta_Adresi));
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Bildirimi_Kapat(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler_HaberdarEt set IslemTamam=1 where HaberdarEtID=@ID", con);
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
        SqlCommand comGuncel = new SqlCommand("update E_Urunler_HaberdarEt set IslemTamam=0 where HaberdarEtID=@ID", con);
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
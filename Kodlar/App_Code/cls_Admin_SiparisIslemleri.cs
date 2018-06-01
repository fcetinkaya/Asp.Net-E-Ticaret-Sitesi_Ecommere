using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_SiparisIslemleri
/// </summary>
public class cls_Admin_SiparisIslemleri : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Liste_Gel()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=0 and CAST(E_SiparisTakip.SiparisTarihi AS DATE)=CAST(GETDATE() AS DATE)  order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Liste_Gel_Arama_Kriterine_Gore(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=0 and CAST(E_SiparisTakip.SiparisTarihi AS DATE)=CAST(GETDATE() AS DATE) " + _Arama_Kriter + " order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Siparis_Durumu()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_SiparisDurumu", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Siparisi_Durum_Degisim_ve_Kapat(string _Geliyor_Aydi, string _durum, bool _Sonuc)
    {
        SqlCommand comGuncel = new SqlCommand("update E_SiparisTakip set DurumID=@DID,IslemTamam=@S where E_SiparisID=@ID", con);
        comGuncel.Parameters.AddWithValue("@DID", _durum);
        comGuncel.Parameters.AddWithValue("@S", _Sonuc);
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
    public DataTable Siparis_Sepet_Bilgileri(string Siparis_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select resim,isim,fiyat,adet,toplam,link from E_SiparisSepet where  SiparisID=@SID", con);
        //  dap.SelectCommand.Parameters.AddWithValue("@UID", Uye_ID);
        dap.SelectCommand.Parameters.AddWithValue("@SID", Siparis_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    // Tamamlanan Siparişler Listesi
    public DataTable Liste_Gel_Tamamlanan()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=1 order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Liste_Gel_Tamamlanan_Arama_Kriterine_Gore(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=1 " + _Arama_Kriter + " order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Siparisi_Durum_Getir(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("select IslemTamam from E_SiparisTakip where E_SiparisID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Geliyor_Aydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
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
    // Bekleyen Siparişler Listesi
    public DataTable Liste_Gel_Bekleyen()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=0 order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Liste_Gel_Bekleyen_Arama_Kriterine_Gore(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Personel.AdSoyad,E_Personel.UyeID,E_SiparisTakip.E_SiparisID,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisNoFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_Personel on E_Personel.UyeID=E_SiparisTakip.UyeID inner join E_SiparisDurumu on E_SiparisDurumu.E_Siparis_DurumuID=E_SiparisTakip.DurumID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.IslemTamam=0 " + _Arama_Kriter + " order by E_SiparisTakip.E_SiparisID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
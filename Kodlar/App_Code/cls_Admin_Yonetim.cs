using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_Yonetim
/// </summary>
public class cls_Admin_Yonetim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public int[] Uye_Istatistikleri()
    {
        int[] Gidecek = new int[4];
        SqlCommand com = new SqlCommand("select COUNT(UyeID) as [BugunUyeOlanlar],(Select COUNT(UyeID) from E_Personel where DATEPART(MM, KayitTarihi)=DATEPART(MM, GETDATE()) and IsActive=1) as [BuAyUyeOlanlar],(Select COUNT(UyeID) from E_Personel where DATEPART(yyyy, KayitTarihi)=DATEPART(yyyy, GETDATE()) and IsActive=1) as [BuYilUyeOlanlar],(Select COUNT(UyeID) from E_Personel where IsActive=1) as [ToplamUyeOlanlar] from E_Personel where CAST(KayitTarihi AS DATE)=CAST(GETDATE() AS DATE) and IsActive=1", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Gidecek[0] = Convert.ToInt32(dr[0]);
                Gidecek[1] = Convert.ToInt32(dr[1]);
                Gidecek[2] = Convert.ToInt32(dr[2]);
                Gidecek[3] = Convert.ToInt32(dr[3]);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public int[] Siparis_Istatistikleri()
    {
        int[] Gidecek = new int[4];
        SqlCommand com = new SqlCommand("select COUNT(E_SiparisID) as [BugunSiparisler],(Select COUNT(E_SiparisID) from E_SiparisTakip where DATEPART(MM, SiparisTarihi)=DATEPART(MM, GETDATE()) and IsActive=1) as [BuAySiparisler],(Select COUNT(E_SiparisID) from E_SiparisTakip where DATEPART(yyyy, SiparisTarihi)=DATEPART(yyyy, GETDATE()) and IsActive=1) as [BuYilSiparisler],(Select COUNT(E_SiparisID) from E_SiparisTakip where IsActive=1) as [ToplamSiparisler] from E_SiparisTakip where CAST(SiparisTarihi AS DATE)=CAST(GETDATE() AS DATE) and IsActive=1", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Gidecek[0] = Convert.ToInt32(dr[0]);
                Gidecek[1] = Convert.ToInt32(dr[1]);
                Gidecek[2] = Convert.ToInt32(dr[2]);
                Gidecek[3] = Convert.ToInt32(dr[3]);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public double[] Hasilat_Istatistikleri()
    {
        double[] Gidecek = new double[4];
        SqlCommand com = new SqlCommand("select Sum(CAST(SiparisFiyat as DECIMAL(9,2))) as [BugunSiparisler],(Select Sum(CAST(SiparisFiyat as DECIMAL(9,2))) from E_SiparisTakip where DATEPART(MM, SiparisTarihi)=DATEPART(MM, GETDATE()) and IsActive=1) as [BuAySiparisler],(Select Sum(CAST(SiparisFiyat as DECIMAL(9,2))) from E_SiparisTakip where DATEPART(yyyy, SiparisTarihi)=DATEPART(yyyy, GETDATE()) and IsActive=1) as [BuYilSiparisler],(Select Sum(CAST(SiparisFiyat as DECIMAL(9,2))) from E_SiparisTakip where IsActive=1) as [ToplamSiparisler] from E_SiparisTakip where CAST(SiparisTarihi AS DATE)=CAST(GETDATE() AS DATE) and IsActive=1", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                string BugunHasilat = dr[0].ToString() != "" ? dr[0].ToString() : "0";
                Gidecek[0] = Convert.ToDouble(BugunHasilat);
                string BuAyHasilat = dr[1].ToString() != "" ? dr[1].ToString() : "0";
                Gidecek[1] = Convert.ToDouble(BuAyHasilat);
                string BuYilHasilat = dr[2].ToString() != "" ? dr[2].ToString() : "0";
                Gidecek[2] = Convert.ToDouble(BuYilHasilat);
                string ToplamHasilat = dr[3].ToString() != "" ? dr[3].ToString() : "0";
                Gidecek[3] = Convert.ToDouble(ToplamHasilat);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public int Mesaj_Adeti()
    {
        int Gidecek = 0;
        SqlCommand com = new SqlCommand("select COUNT(E_Iletisim_BildirimID) from E_Iletisim_Bildirim where Okundu=0", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Gidecek = Convert.ToInt32(dr[0]);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public int Beni_Ara_Adeti()
    {
        int Gidecek = 0;
        SqlCommand com = new SqlCommand("select COUNT(E_AraBeni_BildirimID) from E_AraBeni_Bildirim where Okundu=0", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Gidecek = Convert.ToInt32(dr[0]);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public int Urun_Talep_Adeti()
    {
        int Gidecek = 0;
        SqlCommand com = new SqlCommand("select COUNT(HaberdarEtID) from E_Urunler_HaberdarEt where IslemTamam=0", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Gidecek = Convert.ToInt32(dr[0]);
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidecek;
    }
    public DataTable Yeni_Siparisler()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisID,OdemeTipi,SiparisNoFiyat,SiparisTarihi from E_SiparisTakip where IslemTamam=0 order by cast(SiparisTarihi as date) desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Odeme_Bildirim()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID,E_Odeme_Bildirim_Bilgisi.Tarih,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_Odeme_Bildirim_Bilgisi inner join E_SiparisTakip on E_Odeme_Bildirim_Bilgisi.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Odeme_Bildirim_Bilgisi.UyeID=E_Personel.UyeID where E_Odeme_Bildirim_Bilgisi.IslemTamam=0  order by E_Odeme_Bildirim_Bilgisi.Odeme_BildirimID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Iade_Degisim_Bildirim()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Iade_Degisim_Bildirim.Iade_DegisimID,E_Iade_Degisim_Bildirim.IadeNedeni,E_SiparisTakip.SiparisNoFiyat,E_Iade_Degisim_Bildirim.Tarih from E_Iade_Degisim_Bildirim inner join  E_SiparisTakip on E_Iade_Degisim_Bildirim.SiparisID =E_SiparisTakip.E_SiparisID where E_Iade_Degisim_Bildirim.IslemTamam=0 order by E_Iade_Degisim_Bildirim.Iade_DegisimID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
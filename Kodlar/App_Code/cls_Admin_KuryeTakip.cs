using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// <summary>
/// Summary description for cls_Admin_KuryeTakip
/// </summary>
public class cls_Admin_KuryeTakip : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Kurye_Bilgileri()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_KuryeTakibi.E_KuryeTakipID,E_KuryeTakibi.FirmaAdi,E_KuryeTakibi.Aciklama,E_KuryeTakibi.Tarih,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KuryeTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KuryeTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KuryeTakibi.UyeID where E_KuryeTakibi.IsActive=1", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Kurye_Bilgileri_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_KuryeTakibi.E_KuryeTakipID,E_KuryeTakibi.FirmaAdi,E_KuryeTakibi.Aciklama,E_KuryeTakibi.Tarih,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KuryeTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KuryeTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KuryeTakibi.UyeID where E_KuryeTakibi.IsActive=1 " + _Arama_Kriter, con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Kayit(string _FirmaAdi, string _Aciklama, string _SiparisID, string _UyeID)
    {
        SqlCommand comGuncel = new SqlCommand("insert into E_KuryeTakibi values(@FA,@Acik,@Tar,@SID,@UID,@IsA)", con);
        comGuncel.Parameters.AddWithValue("@FA", _FirmaAdi);
        comGuncel.Parameters.AddWithValue("@Acik", _Aciklama);
        comGuncel.Parameters.AddWithValue("@Tar", DateTime.Now.ToShortDateString());
        comGuncel.Parameters.AddWithValue("@SID", _SiparisID);
        comGuncel.Parameters.AddWithValue("@UID", _UyeID);
        comGuncel.Parameters.AddWithValue("@IsA", true);
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
    public bool Guncelle(string _FirmaAdi, string _Aciklama, string _SiparisID, string _UyeID, string _GelenID)
    {
        SqlCommand comGuncel = new SqlCommand("update E_KuryeTakibi set FirmaAdi=@FA,Aciklama=@Acik,SiparisID=@SID,UyeID=@UID where E_KuryeTakipID=@KID", con);
        comGuncel.Parameters.AddWithValue("@FA", _FirmaAdi);
        comGuncel.Parameters.AddWithValue("@Acik", _Aciklama);
        comGuncel.Parameters.AddWithValue("@SID", _SiparisID);
        comGuncel.Parameters.AddWithValue("@UID", _UyeID);
        comGuncel.Parameters.AddWithValue("@KID", _GelenID);
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
    public bool Sil(string _Gelen_ID)
    {
        SqlCommand comGuncel = new SqlCommand("update E_KuryeTakibi set IsActive=0 where E_KuryeTakipID=@KID", con);
        comGuncel.Parameters.AddWithValue("@KID", _Gelen_ID);
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
    public string Siparis_ID_Gonder(string _Siparis_Kodu)
    {
        string No = "";
        SqlCommand comGuncel = new SqlCommand("select E_SiparisID from E_SiparisTakip where SiparisNoFiyat=@S", con);
        comGuncel.Parameters.AddWithValue("@S", _Siparis_Kodu);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                No = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        comGuncel.Dispose();
        return No;
    }
    public string Musteri_ID_Gonder(string _AdSoyad)
    {
        string Git = "";
        SqlCommand comGuncel = new SqlCommand("select UyeID from E_Personel where AdSoyad=@AS", con);
        comGuncel.Parameters.AddWithValue("@AS", Ortak.Encrypt(_AdSoyad));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        comGuncel.Dispose();
        return Git;
    }
    public string Siparis_No_Gonder(string _Siparis_Kodu)
    {
        string No = "";
        SqlCommand comGuncel = new SqlCommand("select SiparisNoFiyat from E_SiparisTakip where E_SiparisID=@S", con);
        comGuncel.Parameters.AddWithValue("@S", _Siparis_Kodu);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                No = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        comGuncel.Dispose();
        return No;
    }
    public string Musteri_AdSoyad_Gonder(string _UyeID)
    {
        string AdSoyad = "";
        SqlCommand comGuncel = new SqlCommand("select AdSoyad,EPostaBox from E_Personel where UyeID=@AS", con);
        comGuncel.Parameters.AddWithValue("@AS", _UyeID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                AdSoyad = Ortak.Decrypt(dr[0].ToString()) + "-" + Ortak.Decrypt(dr[1].ToString());
            }
        }
        dr.Close();
        con.Close();
        comGuncel.Dispose();
        return AdSoyad;
    }
    public string[] Guncelleme_Icin_Bilgiler(string _Gelen_ID)
    {
        string[] Bilgiler = new string[5];
        SqlCommand comGuncel = new SqlCommand("select E_KuryeTakibi.FirmaAdi,E_KuryeTakibi.Aciklama,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KuryeTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KuryeTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KuryeTakibi.UyeID where E_KuryeTakibi.IsActive=1 and E_KuryeTakibi.E_KuryeTakipID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Gelen_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Bilgiler[0] = dr[0].ToString();
                Bilgiler[1] = dr[1].ToString();
                Bilgiler[2] = dr[2].ToString();
                Bilgiler[3] = dr[3].ToString();
            }
        }
        dr.Close();
        con.Close();
        comGuncel.Dispose();
        return Bilgiler;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
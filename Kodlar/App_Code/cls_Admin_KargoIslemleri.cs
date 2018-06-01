using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for cls_Admin_KargoIslemleri
/// </summary>
public class cls_Admin_KargoIslemleri : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Kargo_Bilgileri()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_KargoTakibi.E_KargoTakipID,E_KargoTakibi.KargoFirmasi,E_KargoTakibi.TakipNo,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KargoTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KargoTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KargoTakibi.UyeID where E_KargoTakibi.IsActive=1", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Kargo_Bilgileri_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_KargoTakibi.E_KargoTakipID,E_KargoTakibi.KargoFirmasi,E_KargoTakibi.TakipNo,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KargoTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KargoTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KargoTakibi.UyeID where E_KargoTakibi.IsActive=1 " + _Arama_Kriter, con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Kayit(string _KargoFirmasi, string _TakipNo, string _SiparisID, string _UyeID)
    {
        SqlCommand comGuncel = new SqlCommand("insert into E_KargoTakibi values(@KF,@TN,@SID,@UID,@IsA)", con);
        comGuncel.Parameters.AddWithValue("@KF", _KargoFirmasi);
        comGuncel.Parameters.AddWithValue("@TN", Ortak.Encrypt(_TakipNo));
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
    public bool Guncelle(string _KargoFirmasi, string _TakipNo, string _SiparisID, string _UyeID, string _GelenID)
    {
        SqlCommand comGuncel = new SqlCommand("update E_KargoTakibi set TakipNo=@TN,KargoFirmasi=@KF,SiparisID=@SID,UyeID=@UID where E_KargoTakipID=@KID", con);
        comGuncel.Parameters.AddWithValue("@TN", Ortak.Encrypt(_TakipNo));
        comGuncel.Parameters.AddWithValue("@KF", _KargoFirmasi);
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
        SqlCommand comGuncel = new SqlCommand("update E_KargoTakibi set IsActive=0 where E_KargoTakipID=@KID", con);
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
    public bool Kontrol_Et(string _Gonderi_Kodu)
    {
        SqlCommand comGuncel = new SqlCommand("select E_KargoTakipID from E_KargoTakibi where TakipNo=@Adres and IsActive=1", con);
        comGuncel.Parameters.AddWithValue("@Adres", Ortak.Encrypt(_Gonderi_Kodu));
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
    public string Musteri_bilgi_Gonder(string _AdSoyad)
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
        string[] Bilgiler = new string[4];
        SqlCommand comGuncel = new SqlCommand("select E_KargoTakibi.KargoFirmasi,E_KargoTakibi.TakipNo,E_SiparisTakip.SiparisNoFiyat,E_Personel.AdSoyad from E_KargoTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KargoTakibi.SiparisID inner join E_Personel on E_Personel.UyeID=E_KargoTakibi.UyeID where E_KargoTakibi.IsActive=1 and  E_KargoTakibi.E_KargoTakipID=@ID", con);
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
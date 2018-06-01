using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for cls_Admin_IadeDegisim
/// </summary>
public class cls_Admin_IadeDegisim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Iade_Degisim(string _Gel_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Iade_Degisim_Bildirim.Iade_DegisimID,E_Iade_Degisim_Bildirim.BankaAdi,E_Iade_Degisim_Bildirim.Iban,E_Iade_Degisim_Bildirim.IadeNedeni,E_Iade_Degisim_Bildirim.Aciklama,E_SiparisTakip.SiparisNoFiyat,E_Iade_Degisim_Bildirim.Tarih,E_Personel.AdSoyad,E_Iade_Degisim_Bildirim.IslemTamam from E_Iade_Degisim_Bildirim inner join E_SiparisTakip on E_Iade_Degisim_Bildirim.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Iade_Degisim_Bildirim.UyeID=E_Personel.UyeID where E_Iade_Degisim_Bildirim.Iade_DegisimID=@ID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", _Gel_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Iade_Degisim_Tumu()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Iade_Degisim_Bildirim.Iade_DegisimID,E_Iade_Degisim_Bildirim.BankaAdi,E_Iade_Degisim_Bildirim.Iban,E_Iade_Degisim_Bildirim.IadeNedeni,E_Iade_Degisim_Bildirim.Aciklama,E_SiparisTakip.SiparisNoFiyat,E_Iade_Degisim_Bildirim.Tarih,E_Personel.AdSoyad,E_Iade_Degisim_Bildirim.IslemTamam from E_Iade_Degisim_Bildirim inner join  E_SiparisTakip on E_Iade_Degisim_Bildirim.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Iade_Degisim_Bildirim.UyeID=E_Personel.UyeID order by E_Iade_Degisim_Bildirim.Iade_DegisimID desc", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Iade_Degisim_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_Iade_Degisim_Bildirim.Iade_DegisimID,E_Iade_Degisim_Bildirim.BankaAdi,E_Iade_Degisim_Bildirim.Iban,E_Iade_Degisim_Bildirim.IadeNedeni,E_Iade_Degisim_Bildirim.Aciklama,E_SiparisTakip.SiparisNoFiyat,E_Iade_Degisim_Bildirim.Tarih,E_Personel.AdSoyad,E_Iade_Degisim_Bildirim.IslemTamam from E_Iade_Degisim_Bildirim inner join  E_SiparisTakip on E_Iade_Degisim_Bildirim.SiparisID =E_SiparisTakip.E_SiparisID inner join E_Personel on E_Iade_Degisim_Bildirim.UyeID=E_Personel.UyeID where " + _Arama_Kriter, con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Bildirimi_Kapat(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Iade_Degisim_Bildirim set IslemTamam=1 where Iade_DegisimID=@ID", con);
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
        SqlCommand comGuncel = new SqlCommand("update E_Iade_Degisim_Bildirim set IslemTamam=0 where Iade_DegisimID=@ID", con);
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
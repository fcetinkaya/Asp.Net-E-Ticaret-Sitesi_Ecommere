using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_IletisimMesajlari
/// </summary>
public class cls_Admin_IletisimMesajlari : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Iletisim_Mesajlari_Tumu()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_Iletisim_Bildirim", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Iletisim_Mesajlari_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_Iletisim_Bildirim where Log_Index=@AD", con);
        dap.SelectCommand.Parameters.AddWithValue("@AD", _Arama_Kriter);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Iletisim_Bildirimi_Kapat(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Iletisim_Bildirim set Okundu=1 where E_Iletisim_BildirimID=@ID", con);
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
    // Ara Beni
    public DataTable AraBeni_Mesajlari_Tumu()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_AraBeni_Bildirim", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable AraBeni_Mesajlari_Arama_Kriter(string _Arama_Kriter)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_AraBeni_Bildirim where Log_Index=@AD", con);
        dap.SelectCommand.Parameters.AddWithValue("@AD", _Arama_Kriter);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool AraBeni_Bildirimi_Kapat(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_AraBeni_Bildirim set Okundu=1 where E_AraBeni_BildirimID=@ID", con);
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
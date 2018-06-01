using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_HaberSlide
/// </summary>
public class cls_Admin_HaberSlide : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Haberler()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select HaberID,Baslik,Link,sira from E_HaberSlide", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Sirasini_Degistir(string _Geliyor_Aydi, string _Sirasi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_HaberSlide set sira=@Sira where HaberID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Geliyor_Aydi);
        comGuncel.Parameters.AddWithValue("@Sira", _Sirasi);
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
    public bool Delete(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("delete from E_HaberSlide where HaberID=@ID", con);
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
    public int Haber_Adeti()
    {
        SqlCommand comGuncel = new SqlCommand("select Count(HaberID) from E_HaberSlide", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int Adet = (Int32)comGuncel.ExecuteScalar();
        con.Close();
        comGuncel.Dispose();
        return Adet;
    }
    public bool Kayit(string _Baslik, string _ResimYol, string _Link, int _Sirasi)
    {
        SqlCommand comGuncel = new SqlCommand("insert into E_HaberSlide values(@Baslik,@ResimYol,@Link,@sira)", con);
        comGuncel.Parameters.AddWithValue("@Baslik", _Baslik);
        comGuncel.Parameters.AddWithValue("@ResimYol", _ResimYol);
        comGuncel.Parameters.AddWithValue("@Link", _Link);
        comGuncel.Parameters.AddWithValue("@sira", _Sirasi);
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
    public bool Guncelle(string _Baslik, string _Link, string _GelID)
    {
        SqlCommand comGuncel = new SqlCommand("update E_HaberSlide set Baslik=@Baslik,Link=@Link where HaberID=@ID", con);
        comGuncel.Parameters.AddWithValue("@Baslik", _Baslik);
        comGuncel.Parameters.AddWithValue("@Link", _Link);
        comGuncel.Parameters.AddWithValue("@ID", _GelID);
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
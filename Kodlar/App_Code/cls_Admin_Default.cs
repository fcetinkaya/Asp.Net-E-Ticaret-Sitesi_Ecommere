using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_Default
/// </summary>
public class cls_Admin_Default : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool PasvirdGel(string _Eposta, string _sifre)
    {
        SqlCommand com = new SqlCommand("select Giris_ID from E_A_Giris where Kullanici_Adi=@Yuser and Pass=@Pasvord and  IsActive=1", con);
        com.Parameters.AddWithValue("@Yuser", Ortak.Encrypt(_Eposta));
        com.Parameters.AddWithValue("@Pasvord", Ortak.Encrypt(_sifre));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader drcik = com.ExecuteReader();

        if (drcik.HasRows == true)
        {
            con.Close();
            drcik.Close();
            com.Dispose();
            return true;
        }
        else
        {
            con.Close();
            drcik.Close();
            com.Dispose();
            return false;
        }
    }
    public string EPosta_Hatirlat_Getir(string _Eposta_Hatirlat)
    {
        string sifre = "";
        SqlCommand comgel = new SqlCommand("select Pass from E_A_Giris where IsActive=1 and Kullanici_Adi=@B", con);
        comgel.Parameters.AddWithValue("@B", Ortak.Encrypt(_Eposta_Hatirlat));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comgel.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sifre = dr[0].ToString();
            }
        }
        con.Close();
        comgel.Dispose();
        dr.Close();
        return sifre;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
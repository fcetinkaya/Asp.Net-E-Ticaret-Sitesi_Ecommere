using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_UrunSilme
/// </summary>
public class cls_Admin_UrunSilme : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Urun_Silme(string _UrunID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_Urunler set IsActive=0 where UrunID=@ID", con);

        comKayitEk.Parameters.AddWithValue("@ID", _UrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comKayitEk.ExecuteNonQuery() > 0)
        {
            con.Close();
            comKayitEk.Dispose();
            return true;
        }
        else
        {
            con.Close();
            comKayitEk.Dispose();
            return true;
        }
    }
    public string[] Urun_Arama_Turn_Details(string _Gelen_UrunAdi)
    {
        string[] Git = new string[7];
        SqlCommand com = new SqlCommand("select UrunAdi,Logo,EskiFiyat,YeniFiyat,KategoriAdi,TelefonAdi,ModelAdi from E_Urunler where UrunID=@UID", con);
        com.Parameters.AddWithValue("@UID", _Gelen_UrunAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["UrunAdi"].ToString();
                Git[1] = dr["Logo"].ToString();
                Git[2] = dr["EskiFiyat"].ToString();
                Git[3] = dr["YeniFiyat"].ToString();
                Git[4] = dr["KategoriAdi"].ToString();
                Git[5] = dr["TelefonAdi"].ToString();
                Git[6] = dr["ModelAdi"].ToString();
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Git;
    }
    public int Urun_Arama_Turn_ID(string _Gelen_UrunAdi)
    {
        int Gidecek = 0;
        SqlCommand com = new SqlCommand("select UrunID from E_Urunler where UrunAdi=@UAD", con);
        com.Parameters.AddWithValue("@UAD", _Gelen_UrunAdi);
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
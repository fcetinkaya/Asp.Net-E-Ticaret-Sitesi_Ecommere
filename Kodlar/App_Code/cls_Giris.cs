using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Giris
/// </summary>
public class cls_Giris : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public string[] Giris_Kontrol(string K, string S)
    {
        string[] Git = new string[2];
        string Ku = Ortak.Encrypt(K);
        string Si = Ortak.Encrypt(S);
        SqlCommand com = new SqlCommand("select UyeID,AdSoyad from E_Personel where UyeID=(select UyeID from E_Uyeler where IsActive=1 and KullaniciAdi='" + Ku + "' and Pass='" + Si + "')", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Git[0] = dr["UyeID"].ToString();
                Git[1] = Ortak.Decrypt(dr["AdSoyad"].ToString());
            }
        }
        else
        {
            Git[0] = "";
        }
        dr.Close();
        com.Dispose();
        con.Close();
        return Git;
    }
    public string[] GidenBilgi(string Eposta)
    {
        string[] car = new string[2];
        SqlCommand com = new SqlCommand("select E_Personel.AdSoyad,E_Uyeler.KullaniciAdi,E_Uyeler.Pass from E_Personel inner join E_Uyeler on E_Uyeler.UyeID=E_Personel.UyeID where E_Uyeler.KullaniciAdi=@K", con);
        com.Parameters.AddWithValue("@K", Ortak.Encrypt(Eposta));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                car[0] = dr["AdSoyad"].ToString();
                car[1] = dr["Pass"].ToString();
            }
        }
        else
        {
            car[0] = "";
        }
        dr.Close();
        com.Dispose();
        con.Close();
        return car;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
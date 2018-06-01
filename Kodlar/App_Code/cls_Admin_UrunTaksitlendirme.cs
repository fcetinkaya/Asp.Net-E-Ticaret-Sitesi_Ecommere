using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin_UrunTaksitlendirme
/// </summary>
public class cls_Admin_UrunTaksitlendirme:IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Taksit_Kontrol(string _Gel_UrunID)
    {
        SqlCommand com_Ara = new SqlCommand("select UrunID from E_UrunDetay_Banka_Taksitler where BankaID=@ID", con);
        com_Ara.Parameters.AddWithValue("@ID", _Gel_UrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com_Ara.ExecuteReader();
        if (dr.HasRows)
        {
            con.Close();
            com_Ara.Dispose();
            return true;
        }
        else
        {
            con.Close();
            com_Ara.Dispose();
            return false;
        }
    }
    public DataTable UrunDetay_Taksitlendirme_Getir(string _GelenID)
    {
        SqlDataAdapter dapResim = new SqlDataAdapter("select E_Urunler.UrunAdi,E_UrunDetay_Banka.BankaAdi,E_UrunDetay_Banka_Taksitler.TaksitID,E_UrunDetay_Banka_Taksitler.TaksitSayisi,E_UrunDetay_Banka_Taksitler.TaksitTutari from E_Urunler inner join E_UrunDetay_Banka_Taksitler on E_UrunDetay_Banka_Taksitler.UrunID=E_Urunler.UrunID inner join E_UrunDetay_Banka on E_UrunDetay_Banka.E_BankaID=E_UrunDetay_Banka_Taksitler.BankaID where E_UrunDetay_Banka_Taksitler.UrunID=@ID order by E_UrunDetay_Banka.BankaAdi", con);
        dapResim.SelectCommand.Parameters.AddWithValue("@ID", _GelenID);
        DataTable dt = new DataTable();
        dapResim.Fill(dt);
        return dt;
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
    public string[] Urun_Link_Fiyat_Turn(string _Gelen_ID)
    {
        string[] Gidicek = new string[2];
        SqlCommand com = new SqlCommand("select YeniFiyat,Link from E_Urunler where UrunID=@UID", con);
        com.Parameters.AddWithValue("@UID", _Gelen_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                double fiyat = Convert.ToDouble(dr["YeniFiyat"]);
                double KDV_Dahil = (fiyat * 1.18);
                Gidicek[0] = KDV_Dahil.ToString();
                Gidicek[1] = dr["Link"].ToString();
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Gidicek;
    }
    public bool Urun_Taksitleri_Delete(string _Gelen_TaksitID, string _Urun_ID)
    {
        SqlCommand com = new SqlCommand("delete from E_UrunDetay_Banka_Taksitler where UrunID=@UID and TaksitID=@TID", con);
        com.Parameters.AddWithValue("@TID", _Gelen_TaksitID);
        com.Parameters.AddWithValue("@UID", _Urun_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            com.Dispose();
            con.Close();
            return true;
        }
        else
        {
            com.Dispose();
            con.Close();
            return false;
        }
    }
    public void Urun_Taksitleri_Ekle(string _Urun_ID, string _BankaID, string _TaksitSayisi, string _TaksitTutari, string _ToplamTutar)
    {
        SqlCommand com = new SqlCommand("insert into E_UrunDetay_Banka_Taksitler values(@UID,@BID,@TS,@TT,@TopT,@VF)", con);
        com.Parameters.AddWithValue("@UID", _Urun_ID);
        com.Parameters.AddWithValue("@BID", _BankaID);
        com.Parameters.AddWithValue("@TS", _TaksitSayisi);
        com.Parameters.AddWithValue("@TT", _TaksitTutari);
        com.Parameters.AddWithValue("@TopT", _ToplamTutar);
        com.Parameters.AddWithValue("@VF", DBNull.Value);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        com.ExecuteNonQuery();
        com.Dispose();
        con.Close();
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
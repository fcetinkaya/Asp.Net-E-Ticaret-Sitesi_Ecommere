using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class cls_Sepet : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public void Siparis_Sepetini_Ekle(string id,string Resim, string Isim, int Adet, double Fiyat, double Toplam, string Link, string SiparisID, string Gelen_Uye_ID)
    {
        SqlCommand com = new SqlCommand("insert into E_SiparisSepet values(@id,@resim,@isim,@fiyat,@adet,@toplam,@link,@SiparisID,@UyeID)", con);
        com.Parameters.AddWithValue("@id", id);
        com.Parameters.AddWithValue("@resim", Resim);
        com.Parameters.AddWithValue("@isim", Isim);
        com.Parameters.AddWithValue("@fiyat", Fiyat);
        com.Parameters.AddWithValue("@adet", Adet);
        com.Parameters.AddWithValue("@toplam", Toplam);
        com.Parameters.AddWithValue("@link", Link);
        com.Parameters.AddWithValue("@SiparisID", SiparisID);
        com.Parameters.AddWithValue("@UyeID", Gelen_Uye_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        com.ExecuteNonQuery();
        com.Dispose();
        con.Close();
    }
    public void Uyenin_Sepetini_Ekle(string ID, string Resim, string Isim, int Adet, double Fiyat, double Toplam, string Link, string Gelen_Uye_ID)
    {
        SqlCommand com = new SqlCommand("insert into E_Sepet_Uye values(@id,@resim,@isim,@fiyat,@adet,@toplam,@link,@UyeID)", con);
        com.Parameters.AddWithValue("@id", ID);
        com.Parameters.AddWithValue("@resim", Resim);
        com.Parameters.AddWithValue("@isim", Isim);
        com.Parameters.AddWithValue("@fiyat", Fiyat);
        com.Parameters.AddWithValue("@adet", Adet);
        com.Parameters.AddWithValue("@toplam", Toplam);
        com.Parameters.AddWithValue("@link", Link);
        com.Parameters.AddWithValue("@UyeID", Gelen_Uye_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        com.ExecuteNonQuery();
        com.Dispose();
        con.Close();
    }
    public void Uyenin_Sepeti_Adet_Fiyat_Guncelle(string id, int adet, double toplamFiyat, string Uye_ID)
    {
        SqlCommand comG = new SqlCommand("update E_Sepet_Uye set adet=@adet,toplam=@toplam where id=@id and UyeID=@UyeID", con);
        comG.Parameters.AddWithValue("@adet", adet);
        comG.Parameters.AddWithValue("@toplam", toplamFiyat);
        comG.Parameters.AddWithValue("@id", id);
        comG.Parameters.AddWithValue("@UyeID", Uye_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        comG.ExecuteNonQuery();
        comG.Dispose();
        con.Close();
    }
    public int Uyenin_Sepet_Adeti(string GelenID)
    {
        int Gidecek = 0;
        SqlCommand com = new SqlCommand("select COUNT(E_Sepet_UyeID) from E_Sepet_Uye where UyeID=@ID", con);
        com.Parameters.AddWithValue("@ID", GelenID);
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
    public DataTable Uye_Siparis_Sepet_Gel(string UyeID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select id,resim,isim,fiyat,adet,toplam,link from E_Sepet_Uye where UyeID=@ID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", UyeID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    //public bool Uyenin_Siparis_Sonrasi_Sepetini_Temizle(string Temizle_UyeID)
    //{
    //    SqlCommand comT = new SqlCommand("delete from E_SiparisSepet where UyeID=@ID", con);
    //    comT.Parameters.AddWithValue("@ID", Temizle_UyeID);
    //    if (con.State == ConnectionState.Closed)
    //    {
    //        con.Open();
    //    }
    //    if (comT.ExecuteNonQuery() > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    public bool Uyenin_Sepetini_Temizle(string Temizle_UyeID)
    {
        SqlCommand comT = new SqlCommand("delete from E_Sepet_Uye where UyeID=@ID", con);
        comT.Parameters.AddWithValue("@ID", Temizle_UyeID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comT.ExecuteNonQuery() > 0)
        {
            comT.Dispose();
            con.Close();
            return true;
        }
        else
        {
            comT.Dispose();
            con.Close();
            return false;
        }
    }
    public bool Uyenin_Sepeti_Urun_Sil(string Temizle_UyeID, string Sepet_ID)
    {
        SqlCommand comT = new SqlCommand("delete from E_Sepet_Uye where UyeID=@ID and id=@SID", con);
        comT.Parameters.AddWithValue("@ID", Temizle_UyeID);
        comT.Parameters.AddWithValue("@SID", Sepet_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comT.ExecuteNonQuery() > 0)
        {
            comT.Dispose();
            con.Close();
            return true;
        }
        else
        {
            comT.Dispose();
            con.Close();
            return false;
        }
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
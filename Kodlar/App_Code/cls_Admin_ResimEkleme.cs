using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_ResimEkleme
/// </summary>
public class cls_Admin_ResimEkleme : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable UrunDetay_ResimGetir(string GelenID)
    {
        SqlDataAdapter dapResim = new SqlDataAdapter("select E_Resimler.ResimAd,E_Resimler.E_ResimID from E_Resimler inner join E_UrunResimler on E_Resimler.E_ResimID=E_UrunResimler.E_ResimID inner join E_Urunler on E_Urunler.UrunID=E_UrunResimler.E_UrunID where E_Urunler.UrunID=@ID", con);
        dapResim.SelectCommand.Parameters.AddWithValue("@ID", GelenID);
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
    public void Urun_Resimleri_Delete(string _Gelen_ResimID, string _Urun_ID)
    {
        SqlCommand com = new SqlCommand("delete from E_UrunResimler where E_ResimID=@RID and E_UrunID=@UID delete from E_Resimler where E_ResimID=@REID", con);
        com.Parameters.AddWithValue("@RID", _Gelen_ResimID);
        com.Parameters.AddWithValue("@UID", _Urun_ID);
        com.Parameters.AddWithValue("@REID", _Gelen_ResimID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        com.ExecuteNonQuery();
        com.Dispose();
        con.Close();
    }
    public void Urun_Resimleri_Ekle(string _Gelen_ResimAdi, string _Urun_ID)
    {
        SqlCommand com = new SqlCommand("insert into E_Resimler values(@RA); select scope_identity()", con);
        com.Parameters.AddWithValue("@RA", _Gelen_ResimAdi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int GelenResimID = Convert.ToInt32(com.ExecuteScalar());
        if (GelenResimID > 0)
        {
            SqlCommand comAra = new SqlCommand("insert into E_UrunResimler values(@RID,@EID)", con);
            comAra.Parameters.AddWithValue("@RID", GelenResimID);
            comAra.Parameters.AddWithValue("@EID", _Urun_ID);
            comAra.ExecuteNonQuery();
            comAra.Dispose();
        }
        com.Dispose();
        con.Close();
    }
    public string[] UrunDetay_UrunAdi_Dondur(string _GelUrunID)
    {
        string[] Adi = new string[2];
        SqlCommand com = new SqlCommand("select UrunAdi,Link from E_Urunler where UrunID=@ID", con);
        com.Parameters.AddWithValue("@ID", _GelUrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Adi[0] = dr[0].ToString();
                Adi[1] = dr[1].ToString();
            }
        }
        dr.Close();
        com.Dispose();
        con.Close();
        return Adi;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
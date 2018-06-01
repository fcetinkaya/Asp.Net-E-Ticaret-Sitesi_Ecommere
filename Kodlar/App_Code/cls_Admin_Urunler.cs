using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_Urunler
/// </summary>
public class cls_Admin_Urunler : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public int Urun_Ekleme(string _UrunAdi, string _Logo, decimal _EskiFiyat, decimal _YeniFiyat, int _IndirimOrani, bool _IndirimVarmi, string _Aciklama, string _KategoriAdi, string _KatID, string _TelefonAdi, string _TelefonID, string _ModelAdi, string _ModelID)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_Urunler values(@UrunAdi,@Logo,@EskiFiyat,@YeniFiyat,@Indirim,@Indirimli,@Aciklama,@KategoriAdi,@KatID,@TelefonAdi,@TelefonID,@ModelAdi,@TelefonModelID,@Tiklama,@Link,@Tukendi,@SatisIptal,@IsActive); select scope_identity();", con);
        comKayitEk.Parameters.AddWithValue("@UrunAdi", _UrunAdi);
        comKayitEk.Parameters.AddWithValue("@Logo", _Logo);
        comKayitEk.Parameters.AddWithValue("@EskiFiyat", _EskiFiyat);
        comKayitEk.Parameters.AddWithValue("@YeniFiyat", _YeniFiyat);
        comKayitEk.Parameters.AddWithValue("@Indirim", _IndirimOrani);
        comKayitEk.Parameters.AddWithValue("@Indirimli", _IndirimVarmi);
        comKayitEk.Parameters.AddWithValue("@Aciklama", _Aciklama);
        comKayitEk.Parameters.AddWithValue("@KategoriAdi", _KategoriAdi);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
        comKayitEk.Parameters.AddWithValue("@TelefonAdi", _TelefonAdi);
        comKayitEk.Parameters.AddWithValue("@TelefonID", _TelefonID);
        comKayitEk.Parameters.AddWithValue("@ModelAdi", _ModelAdi);
        comKayitEk.Parameters.AddWithValue("@TelefonModelID", _ModelID);
        comKayitEk.Parameters.AddWithValue("@Tiklama", 1);
        comKayitEk.Parameters.AddWithValue("@Link", DBNull.Value);
        comKayitEk.Parameters.AddWithValue("@Tukendi", false);
        comKayitEk.Parameters.AddWithValue("@SatisIptal", false);
        comKayitEk.Parameters.AddWithValue("@IsActive", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int Geliyor = Convert.ToInt32(comKayitEk.ExecuteScalar());
        con.Close();
        comKayitEk.Dispose();
        return Geliyor;
    }
    public bool UrunLink_Update(string _Geliyor_Aydi, string _Linki)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set Link='" + _Linki + "' where UrunID=@ID", con);
        //   comGuncel.Parameters.AddWithValue("@Link", _Linki);
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
    public DataTable Alt_Kategori_AllList()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_UrunKategori.KategoriID,E_UrunKategori.KategoriAdi from E_UrunKategori left join E_UrunAnaKategori on E_UrunKategori.UstKategoriID=E_UrunAnaKategori.AnaKategoriID where E_UrunKategori.IsActive=1 order by E_UrunKategori.KategoriAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Telefon_AllList()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select TelAdi,TelefonID from E_TelefonMarka where IsActive=1 order by TelAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable TelefonModel_AllList(string _TelefonID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select ModelAdi,TelefonModelID from E_TelefonModeller where TelefonID=@TID and IsActive=1 order by ModelAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@TID", _TelefonID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
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
    public bool Stokta_KalmayanUrun_Onay(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set Tukendi=1 where UrunID=@ID", con);
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
    public bool Satis_Iptal_Onay(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set SatisIptal=1 where UrunID=@ID", con);
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
    public bool Stokta_KalmayanUrun_GeriAl(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set Tukendi=0 where UrunID=@ID", con);
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
    public bool Satis_Iptal_GeriAl(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set SatisIptal=0 where UrunID=@ID", con);
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
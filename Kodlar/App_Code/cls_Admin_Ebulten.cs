using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_Ebulten
/// </summary>
public class cls_Admin_Ebulten : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Listeler() // Sadece manuel ve web sitesi üzerinden eklenenler gelsin.
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_bultenID,EPostaAdresi,Gidecek from E_EBulten where IsActive=1 and ExcelID is null", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Listeler_Ara(string _Adres)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_bultenID,EPostaAdresi,Gidecek from E_EBulten where IsActive=1 and ExcelID is null and EpostaAdresi=@Adres", con);
        dap.SelectCommand.Parameters.AddWithValue("@Adres", Ortak.Encrypt(_Adres));
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Kontrol_Et(string _E_PostaAdresi)
    {
        SqlCommand comGuncel = new SqlCommand("select E_bultenID from E_EBulten where EPostaAdresi=@Adres and IsActive=1", con);
        comGuncel.Parameters.AddWithValue("@Adres", Ortak.Encrypt(_E_PostaAdresi));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comGuncel.ExecuteReader();
        if (dr.HasRows)
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
    public bool E_PostaGitmeyecek(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_EBulten set Gidecek=0 where E_bultenID=@ID", con);
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
    public bool E_PostaGidecek(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_EBulten set Gidecek=1 where E_bultenID=@ID", con);
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
    public bool Delete(string _Geliyor_Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_EBulten set IsActive=0 where E_bultenID=@ID", con);
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
    public bool Kayit(string _Adres)
    {
        SqlCommand comGuncel = new SqlCommand("insert into E_EBulten values(@Eposta,@Excel,@Gidecek,@IsA)", con);
        comGuncel.Parameters.AddWithValue("@Eposta", Ortak.Encrypt(_Adres));
        comGuncel.Parameters.AddWithValue("@Excel", DBNull.Value);
        comGuncel.Parameters.AddWithValue("@Gidecek", true);
        comGuncel.Parameters.AddWithValue("@IsA", true);
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
    public bool Guncelle(string _Adres, string _Aydi)
    {
        SqlCommand comGuncel = new SqlCommand("update E_EBulten set EPostaAdresi=@Adres where E_bultenID=@ID", con);
        comGuncel.Parameters.AddWithValue("@Adres", Ortak.Encrypt(_Adres));
        comGuncel.Parameters.AddWithValue("@ID", _Aydi);
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
    //Excel için
    public DataTable Listeler_Excel() // Sadece manuel ve web sitesi üzerinden eklenenler gelsin.
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_EBulten.E_bultenID,E_EBulten.EPostaAdresi,E_EBulten.Gidecek,E_EBulten_ExcelListesi.ListeAdi from E_EBulten inner join E_EBulten_ExcelListesi on E_EBulten.ExceLID=E_EBulten_ExcelListesi.E_ExceLID where E_EBulten.IsActive=1", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Listeler_Excel_Ara(string _Adres) // Sadece manuel ve web sitesi üzerinden eklenenler gelsin.
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_EBulten.E_bultenID,E_EBulten.EPostaAdresi,E_EBulten.Gidecek,E_EBulten_ExcelListesi.ListeAdi from E_EBulten inner join E_EBulten_ExcelListesi on E_EBulten.ExceLID=E_EBulten_ExcelListesi.E_ExceLID where E_EBulten.IsActive=1 and E_EBulten.EpostaAdresi=@Adres", con);
        dap.SelectCommand.Parameters.AddWithValue("@Adres",Ortak.Encrypt(_Adres));
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Kayit_Excel(string _Adres, string _Excel_ID)
    {
        SqlCommand comGuncel = new SqlCommand("insert into E_EBulten values(@Eposta,@Excel,@Gidecek,@IsA)", con);
        comGuncel.Parameters.AddWithValue("@Eposta", Ortak.Encrypt(_Adres));
        comGuncel.Parameters.AddWithValue("@Excel", _Excel_ID);
        comGuncel.Parameters.AddWithValue("@Gidecek", true);
        comGuncel.Parameters.AddWithValue("@IsA", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        comGuncel.ExecuteNonQuery();
        con.Close();
        comGuncel.Dispose();
    }
    public void Kayit_Temizle_Mukkerer_Olanlari()
    {
        SqlCommand Com_Temizle = new SqlCommand("ALTER TABLE E_EBulten DISABLE TRIGGER E_EBulten_Silme DELETE FROM E_EBulten WHERE NOT E_bultenID IN (SELECT MIN(E_bultenID) FROM E_EBulten GROUP BY EPostaAdresi) ALTER TABLE E_EBulten ENABLE TRIGGER E_EBulten_Silme", con);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        Com_Temizle.ExecuteNonQuery();
        con.Close();
        Com_Temizle.Dispose();
    }
    public int Excel_Dosyasi_Kayit(string _ListeAdi)
    {
        int Adet = 0;
        SqlCommand comGuncel = new SqlCommand("insert into E_EBulten_ExcelListesi values(@Excel,@Tarih,@IsA) select scope_identity();", con);
        comGuncel.Parameters.AddWithValue("@Excel", _ListeAdi);
        comGuncel.Parameters.AddWithValue("@Tarih", DateTime.Now);
        comGuncel.Parameters.AddWithValue("@IsA", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        Adet =Convert.ToInt32(comGuncel.ExecuteScalar());
        con.Close();
        comGuncel.Dispose();
        return Adet;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
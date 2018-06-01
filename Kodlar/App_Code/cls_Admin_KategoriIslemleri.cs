using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_KategoriIslemleri
/// </summary>
public class cls_Admin_KategoriIslemleri : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Ana_Kategori_List()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select AnaKategoriID,AnaKategoriAdi from E_UrunAnaKategori where IsActive=1 order by AnaKategoriAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Alt_Kategori_AllList()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_UrunKategori.KategoriID,E_UrunKategori.KategoriAdi,E_UrunAnaKategori.AnaKategoriAdi,E_UrunAnaKategori.AnaKategoriID from E_UrunKategori left join E_UrunAnaKategori on E_UrunKategori.UstKategoriID=E_UrunAnaKategori.AnaKategoriID where E_UrunKategori.IsActive=1 order by E_UrunAnaKategori.AnaKategoriAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Alt_Kategori_For_AnaKategoriList(string _anaKategoriID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select E_UrunKategori.KategoriID,E_UrunKategori.KategoriAdi,E_UrunAnaKategori.AnaKategoriAdi from E_UrunKategori left join E_UrunAnaKategori on E_UrunKategori.UstKategoriID=E_UrunAnaKategori.AnaKategoriID where E_UrunKategori.IsActive=1 and E_UrunAnaKategori.AnaKategoriID=@K order by E_UrunAnaKategori.AnaKategoriAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@K", _anaKategoriID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Kategori_Kayit(string _KatAdi, string _RouteAdi, string _UstKatID)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_UrunKategori values(@KategoriAdi,@RouteKatAdi,@UstKategoriID,@Isa)", con);
        comKayitEk.Parameters.AddWithValue("@KategoriAdi", _KatAdi);
        comKayitEk.Parameters.AddWithValue("@RouteKatAdi", _RouteAdi);
        comKayitEk.Parameters.AddWithValue("@UstKategoriID", _UstKatID);
        comKayitEk.Parameters.AddWithValue("@Isa", true);
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
            return false;
        }
    }
    public bool Ana_Kategori_Kayit(string _KatAdi, string _RouteAdi)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_UrunAnaKategori values(@KategoriAdi,@RouteKatAdi,@Isa)", con);
        comKayitEk.Parameters.AddWithValue("@KategoriAdi", _KatAdi);
        comKayitEk.Parameters.AddWithValue("@RouteKatAdi", _RouteAdi);
        comKayitEk.Parameters.AddWithValue("@Isa", true);
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
            return false;
        }
    }
    public bool Kategori_Update(string _KatAdi, string _RouKatAdi, string _UstKatID, string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunKategori set KategoriAdi=@KA,RouteKatAdi=@RKA,UstKategoriID=@UKID where KategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KA", _KatAdi);
        comKayitEk.Parameters.AddWithValue("@RKA", _RouKatAdi);
        comKayitEk.Parameters.AddWithValue("@UKID", _UstKatID);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool AnaKategori_Update(string _KatAdi, string _RouKatAdi, string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunAnaKategori set AnaKategoriAdi=@KA,RouteKatAdi=@RKA where AnaKategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KA", _KatAdi);
        comKayitEk.Parameters.AddWithValue("@RKA", _RouKatAdi);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool Kategori_UnVisible(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunKategori set IsActive=1 where KategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool AnaKategori_UnVisible(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunAnaKategori set IsActive=1 where AnaKategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool Kategori_Visible(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunKategori set IsActive=0 where KategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool AnaKategori_Visible(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunAnaKategori set IsActive=0 where AnaKategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool Kategori_Delete(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunKategori set IsActive=0 where KategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool AnaKategori_Delete(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_UrunAnaKategori set IsActive=0 where AnaKategoriID=@KatID", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
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
            return false;
        }
    }
    public bool AnaKategori_Is_Delete(string _KatID)
    {
        SqlCommand comKayitEk = new SqlCommand("select KategoriID from E_UrunKategori where UstKategoriID=@KatID and IsActive=1", con);
        comKayitEk.Parameters.AddWithValue("@KatID", _KatID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comKayitEk.ExecuteReader();
        if (dr.HasRows)
        {
            con.Close();
            comKayitEk.Dispose();
            return true;
        }
        else
        {
            con.Close();
            comKayitEk.Dispose();
            return false;
        }
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_Sifre
/// </summary>
public class cls_Admin_Sifre : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Pass_Update(string _Pass)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_A_Giris set Pass=@P where Giris_ID=1", con);
        comKayitEk.Parameters.AddWithValue("@P", Ortak.Encrypt(_Pass));
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
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
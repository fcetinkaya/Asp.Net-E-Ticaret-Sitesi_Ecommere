using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_OdemeBildirim
/// </summary>
public class cls_OdemeBildirim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Odeme_Bildirim_Kayit(string Tarih, string Banka_ID, string Siparis_ID, string Gelen_Aydi)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_Odeme_Bildirim_Bilgisi values(@Tarih,@BankaID,@Sip,@ID,@IT)", con);
        comKayitEk.Parameters.AddWithValue("@Tarih", Tarih);
        comKayitEk.Parameters.AddWithValue("@BankaID", Banka_ID);
        comKayitEk.Parameters.AddWithValue("@Sip", Siparis_ID);
        comKayitEk.Parameters.AddWithValue("@ID", Gelen_Aydi);
        comKayitEk.Parameters.AddWithValue("@IT", false);
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
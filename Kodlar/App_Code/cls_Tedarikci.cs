using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Tedarikci
/// </summary>
public class cls_Tedarikci : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Tedarikci_Kayit(string _adSoyad, string _FirmaAdi, string _IsTlf, string _Ceptlf, string _EPosta, string _WebAdres)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_Tedarikci values(@AdSoyad,@FA,@Is,@Cep,@Eposta,@Web,@T)", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", _adSoyad);
        comKayitEk.Parameters.AddWithValue("@FA", _FirmaAdi);
        comKayitEk.Parameters.AddWithValue("@Is", _IsTlf);
        comKayitEk.Parameters.AddWithValue("@Cep", _Ceptlf);
        comKayitEk.Parameters.AddWithValue("@Eposta", _EPosta);
        comKayitEk.Parameters.AddWithValue("@Web", _WebAdres);
        comKayitEk.Parameters.AddWithValue("@T", DateTime.Now);
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
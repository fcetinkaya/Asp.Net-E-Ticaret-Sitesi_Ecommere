using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_IadeDegisim
/// </summary>
public class cls_IadeDegisim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Iade_Degisim_Kayit(string BankaAdi, string Iban, string IadeNedeni, string Aciklama, string Siparis_ID, string Gelen_Aydi)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_Iade_Degisim_Bildirim values(@Banka,@Iban,@Iade,@Aciklama,@Sip,@ID,@Tarih,@IT)", con);
        comKayitEk.Parameters.AddWithValue("@Banka", BankaAdi);
        comKayitEk.Parameters.AddWithValue("@Iban", Iban);
        comKayitEk.Parameters.AddWithValue("@Iade", IadeNedeni);
        comKayitEk.Parameters.AddWithValue("@Aciklama", Aciklama);
        comKayitEk.Parameters.AddWithValue("@Sip", Siparis_ID);
        comKayitEk.Parameters.AddWithValue("@ID", Gelen_Aydi);
        comKayitEk.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
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
        throw new NotImplementedException();
    }
}
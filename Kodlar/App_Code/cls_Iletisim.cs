using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Iletisim
/// </summary>
public class cls_Iletisim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Ara_Beni_Kayit(string AdSoyad, string CepTlf)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_AraBeni_Bildirim values(@AdSoyad,@Cep,@Tarih,@Log,@Ok)", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad",Ortak.Encrypt(AdSoyad));
        comKayitEk.Parameters.AddWithValue("@Cep",Ortak.Encrypt(CepTlf));
        comKayitEk.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
        comKayitEk.Parameters.AddWithValue("@Log", AdSoyad);
        comKayitEk.Parameters.AddWithValue("@Ok", false);
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
    public bool Iletisim_Kayit(string AdSoyad,string Eposta,string CepTlf,string Konu,string Aciklama)
    {
        SqlCommand comKayitEk = new SqlCommand("insert into E_Iletisim_Bildirim values(@AdSoyad,@EPosta,@Cep,@Konu,@Aciklama,@Tarih,@Log,@Ok)", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", Ortak.Encrypt(AdSoyad));
        comKayitEk.Parameters.AddWithValue("@EPosta", Ortak.Encrypt(Eposta));
        comKayitEk.Parameters.AddWithValue("@Cep", Ortak.Encrypt(CepTlf));
        comKayitEk.Parameters.AddWithValue("@Konu", Konu);
        comKayitEk.Parameters.AddWithValue("@Aciklama", Aciklama);
        comKayitEk.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
        comKayitEk.Parameters.AddWithValue("@Log", AdSoyad);
        comKayitEk.Parameters.AddWithValue("@Ok", false);
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
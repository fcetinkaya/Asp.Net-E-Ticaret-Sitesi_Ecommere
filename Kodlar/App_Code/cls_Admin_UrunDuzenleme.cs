using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_UrunDuzenleme
/// </summary>
public class cls_Admin_UrunDuzenleme : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public bool Urun_Guncelleme(string _UrunAdi, decimal _EskiFiyat, decimal _YeniFiyat, int _IndirimOrani, bool _IndirimVarmi, string _Aciklama, string _KategoriAdi, string _KatID, string _TelefonAdi, string _TelefonID, string _ModelAdi, string _ModelID, string _Link, string _UrunID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_Urunler set UrunAdi=@UrunAdi,EskiFiyat=@EskiFiyat,YeniFiyat=@YeniFiyat,Indirim=@Indirim,Indirimli=@Indirimli,Aciklama=@Aciklama,KategoriAdi=@KategoriAdi,KatID=@KatID,TelefonAdi=@TelefonAdi,TelefonID=@TelefonID,ModelAdi=@ModelAdi,TelefonModelID=@TelefonModelID,Link=@Link where UrunID=@ID", con);
        comKayitEk.Parameters.AddWithValue("@UrunAdi", _UrunAdi);
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
        comKayitEk.Parameters.AddWithValue("@Link", _Link);
        comKayitEk.Parameters.AddWithValue("@ID", _UrunID);
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
            return true;
        }
    }
    public bool Urun_Guncelleme_With_Image(string _UrunAdi, string _Logo, decimal _EskiFiyat, decimal _YeniFiyat, int _IndirimOrani, bool _IndirimVarmi, string _Aciklama, string _KategoriAdi, string _KatID, string _TelefonAdi, string _TelefonID, string _ModelAdi, string _ModelID, string _Link, string _UrunID)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_Urunler set UrunAdi=@UrunAdi,Logo=@Logo,EskiFiyat=@EskiFiyat,YeniFiyat=@YeniFiyat,Indirim=@Indirim,Indirimli=@Indirimli,Aciklama=@Aciklama,KategoriAdi=@KategoriAdi,KatID=@KatID,TelefonAdi=@TelefonAdi,TelefonID=@TelefonID,ModelAdi=@ModelAdi,TelefonModelID=@TelefonModelID,Link=@Link where UrunID=@ID", con);
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
        comKayitEk.Parameters.AddWithValue("@Link", _Link);
        comKayitEk.Parameters.AddWithValue("@ID", _UrunID);
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
            return true;
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
    public string[] Urun_Guncelleme_Turn_Details(string _Gelen_UrunAdi)
    {
        string[] Git = new string[8];
        SqlCommand com = new SqlCommand("select UrunAdi,Logo,EskiFiyat,Indirim,Aciklama,KatID,TelefonID,TelefonModelID from E_Urunler where UrunID=@UID", con);
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
                Git[3] = dr["Indirim"].ToString();
                Git[4] = dr["Aciklama"].ToString();
                Git[5] = dr["KatID"].ToString();
                Git[6] = dr["TelefonID"].ToString();
                Git[7] = dr["TelefonModelID"].ToString();
            }
        }
        com.Dispose();
        dr.Close();
        con.Close();
        return Git;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
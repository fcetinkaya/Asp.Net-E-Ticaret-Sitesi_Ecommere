using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Admin_SilinenUrunler
/// </summary>
public class cls_Admin_SilinenUrunler : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Liste_Gel()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=0 order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Liste_Gel_Arama_Kriterine_Gore(string _Arama_Kriter)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID, UrunAdi,Logo,EskiFiyat,YeniFiyat,Indirim,Indirimli,KategoriAdi,TelefonAdi,ModelAdi,Tiklama,Link,Tukendi,SatisIptal from E_Urunler where IsActive=0 " + _Arama_Kriter + " order by UrunAdi", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public bool Urunu_Geri_Al(string _Gelen_ID)
    {
        SqlCommand comGuncel = new SqlCommand("update E_Urunler set IsActive=1,SatisIptal=0,Tukendi=0 where UrunID=@ID", con);
        comGuncel.Parameters.AddWithValue("@ID", _Gelen_ID);
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
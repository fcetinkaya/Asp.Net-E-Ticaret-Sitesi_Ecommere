using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Urunler
/// </summary>
public class cls_Urunler : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    #region UrunDetay_Sayfasi
    public DataTable UrunDetay_RenkSecenekleri(string GelenID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter dap = new SqlDataAdapter("select E_Urunler.UrunID,E_Urunler.UrunAdi,E_Urunler.Logo,E_Urunler.Link from E_Urunler inner join E_Urunler_Renkler on E_Urunler.UrunID=E_Urunler_Renkler.IliskiliUrunID Where E_Urunler.SatisIptal=0 and E_Urunler.IsActive=1 and E_Urunler.UrunID<>@ID and E_Urunler_Renkler.UrunID in (select UrunID from E_Urunler_Renkler where IliskiliUrunID=@ID) group by E_Urunler.UrunID,E_Urunler.UrunAdi,E_Urunler.Logo,E_Urunler.Link UNION ALL select E_Urunler.UrunID,E_Urunler.UrunAdi,E_Urunler.Logo,E_Urunler.Link from E_Urunler inner join E_Urunler_Renkler on E_Urunler.UrunID=E_Urunler_Renkler.IliskiliUrunID  Where E_Urunler.SatisIptal=0 and E_Urunler.IsActive=1 and E_Urunler.UrunID<>@ID and E_Urunler_Renkler.IliskiliUrunID in (select IliskiliUrunID from E_Urunler_Renkler where UrunID=@ID) group by E_Urunler.UrunID,E_Urunler.UrunAdi,E_Urunler.Logo,E_Urunler.Link", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", GelenID);
        dap.Fill(dt);
        return dt;
    }
    public DataTable UrunDetay_OdemeSecenekleri_Banka(string GelenID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_UrunDetay_Banka.E_BankaID,E_UrunDetay_Banka.BankaAdi,E_UrunDetay_Banka.BankaLogo from E_UrunDetay_Banka inner join E_UrunDetay_Banka_Taksitler on E_UrunDetay_Banka_Taksitler.BankaID=E_UrunDetay_Banka.E_BankaID inner join E_Urunler on E_UrunDetay_Banka_Taksitler.UrunID=E_Urunler.UrunID where E_UrunDetay_Banka_Taksitler.UrunID=1 group by E_UrunDetay_Banka.E_BankaID,E_UrunDetay_Banka.BankaAdi,E_UrunDetay_Banka.BankaLogo order by E_UrunDetay_Banka.BankaAdi", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", GelenID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable UrunDetay_OdemeSecenekleri_Taksitler(string GelenID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_UrunDetay_Banka_Taksitler.TaksitSayisi,E_UrunDetay_Banka_Taksitler.TaksitTutari,E_UrunDetay_Banka_Taksitler.ToplamTutar from E_UrunDetay_Banka_Taksitler inner join E_Urunler on E_UrunDetay_Banka_Taksitler.UrunID=E_Urunler.UrunID inner join E_UrunDetay_Banka on E_UrunDetay_Banka.E_BankaID=E_UrunDetay_Banka.E_BankaID where E_UrunDetay_Banka_Taksitler.BankaID=@ID group by E_UrunDetay_Banka_Taksitler.TaksitSayisi,E_UrunDetay_Banka_Taksitler.TaksitTutari,E_UrunDetay_Banka_Taksitler.ToplamTutar order by E_UrunDetay_Banka_Taksitler.TaksitSayisi", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", GelenID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public SqlDataReader UrunDetay_UrunBilgileriGel(string GelUrunID)
    {
        SqlCommand com = new SqlCommand("select E_Urunler.UrunAdi,E_Urunler.Logo,E_Urunler.EskiFiyat,E_Urunler.YeniFiyat,E_Urunler.Aciklama,E_Urunler.Link,E_UrunKategori.KategoriAdi,E_UrunKategori.KategoriID,E_UrunKategori.RouteKatAdi,E_TelefonMarka.TelAdi,E_TelefonMarka.TelefonID,E_TelefonMarka.RouteTelAdi,E_TelefonModeller.ModelAdi,E_TelefonModeller.TelefonModelID,E_TelefonModeller.RouteModelAdi from E_Urunler inner join E_UrunKategori on E_Urunler.KatID=E_UrunKategori.KategoriID inner join E_TelefonMarka on E_TelefonMarka.TelefonID=E_Urunler.TelefonID inner join E_TelefonModeller on E_TelefonModeller.TelefonModelID=E_Urunler.TelefonModelID where E_Urunler.UrunID=@ID", con);
        com.Parameters.AddWithValue("@ID", GelUrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        return dr;
    }
    public void UrunDetay_TiklamaArttir(string GelUrunID)
    {
        SqlCommand com = new SqlCommand("update E_Urunler set Tiklama=Tiklama+1 where UrunID=@ID", con);
        com.Parameters.AddWithValue("@ID", GelUrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        com.ExecuteNonQuery();
        com.Dispose();
        con.Close();
    }
    public DataTable UrunDetay_ResimGetir(string GelenID)
    {

        SqlDataAdapter dapResim = new SqlDataAdapter("select E_Resimler.ResimAd from E_Resimler inner join E_UrunResimler on E_Resimler.E_ResimID=E_UrunResimler.E_ResimID inner join E_Urunler on E_Urunler.UrunID=E_UrunResimler.E_UrunID where E_Urunler.UrunID=@ID", con);
        dapResim.SelectCommand.Parameters.AddWithValue("@ID", GelenID);
        DataTable dt = new DataTable();
        dapResim.Fill(dt);
        return dt;
    }
    public bool UrunDetay_Tukendimi(string GelUrunID)
    {
        bool durum = false;
        SqlCommand com = new SqlCommand("select Tukendi from E_Urunler where UrunID=@ID", con);
        com.Parameters.AddWithValue("@ID", GelUrunID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                durum = Convert.ToBoolean(dr[0]);
            }
        }
        dr.Close();
        com.Dispose();
        con.Close();
        return durum;
    }
    #endregion
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
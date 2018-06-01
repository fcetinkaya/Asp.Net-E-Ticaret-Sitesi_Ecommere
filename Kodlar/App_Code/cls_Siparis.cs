using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Siparis
/// </summary>
public class cls_Siparis : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable GelSiparisler(string Geliyor_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.E_SiparisID, E_SiparisTakip.SiparisNo,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_SiparisDurumu on E_SiparisTakip.DurumID=E_SiparisDurumu.E_Siparis_DurumuID where E_SiparisTakip.IsActive=1 and E_SiparisTakip.UyeID=@ID order by E_SiparisTakip.E_SiparisID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", Geliyor_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable GelSiparisler_Hepsi(string Geliyor_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.E_SiparisID, E_SiparisTakip.SiparisNo,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_SiparisDurumu on E_SiparisTakip.DurumID=E_SiparisDurumu.E_Siparis_DurumuID order by E_SiparisTakip.E_SiparisID where E_SiparisTakip.IsActive=1", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", Geliyor_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable GelSiparisler_DurumaGore(string Gelen_DurumID, string Gelen_UyeID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.E_SiparisID, E_SiparisTakip.SiparisNo,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_SiparisDurumu on E_SiparisTakip.DurumID=E_SiparisDurumu.E_Siparis_DurumuID where  E_SiparisTakip.IsActive=1 and E_SiparisTakip.UyeID=@UID and E_SiparisTakip.DurumID=@ID order by E_SiparisTakip.E_SiparisID", con);
        dap.SelectCommand.Parameters.AddWithValue("@ID", Gelen_DurumID);
        dap.SelectCommand.Parameters.AddWithValue("@UID", Gelen_UyeID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable GelSiparisler_SiparisDetay(string Siparis_No_Gel, string Gelen_UyemID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.E_SiparisID, E_SiparisTakip.SiparisNo,E_SiparisTakip.SiparisTarihi,E_SiparisTakip.OdemeTipi,E_SiparisTakip.SiparisFiyat,E_SiparisDurumu.DurumAd from E_SiparisTakip inner join E_SiparisDurumu on E_SiparisTakip.DurumID=E_SiparisDurumu.E_Siparis_DurumuID where  E_SiparisTakip.IsActive=1 and E_SiparisTakip.UyeID=@UID and E_SiparisTakip.SiparisNo=@SNO", con);
        dap.SelectCommand.Parameters.AddWithValue("@UID", Gelen_UyemID);
        dap.SelectCommand.Parameters.AddWithValue("@SNO", Siparis_No_Gel);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Siparis_Sepet_Bilgileri(string Siparis_ID, string Uye_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select resim,isim,fiyat,adet,toplam,link from E_SiparisSepet where UyeID=@UID and SiparisID=@SID", con);
        dap.SelectCommand.Parameters.AddWithValue("@UID", Uye_ID);
        dap.SelectCommand.Parameters.AddWithValue("@SID", Siparis_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string Gel_Siparis_ID(string Siparis_No)
    {
        string SID = "";
        SqlCommand ComC = new SqlCommand("select E_SiparisID from E_SiparisTakip where SiparisNo=@SNO", con);
        ComC.Parameters.AddWithValue("@SNO", Siparis_No);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = ComC.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                SID = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        ComC.Dispose();
        return SID;
    }
    //
    public int Siparis_Kaydet(string _Siparis_No, string _Siparis_Tarihi, string _Odeme_Tipi, string _Siparis_NoFiyat, double _Siparis_Fiyat, string _DurumID, string _UyeID, string _E_SiparisFaturaID, string _E_Teslimat_AdresiID, string _Notu)
    {

        SqlCommand comSepet = new SqlCommand("insert into E_SiparisTakip values(@SiparisNo,@SiparisTarihi,@OdemeTipi,@SiparisNoFiyat,@SiparisFiyat,@DurumID,@UyeID,@E_SiparisFaturaID,@E_TeslimatAdresiID,@Not,@IsA,@IT); select scope_identity()", con);
        comSepet.Parameters.AddWithValue("@SiparisNo", _Siparis_No);
        comSepet.Parameters.AddWithValue("@SiparisTarihi", _Siparis_Tarihi);
        comSepet.Parameters.AddWithValue("@OdemeTipi", _Odeme_Tipi);
        comSepet.Parameters.AddWithValue("@SiparisNoFiyat", _Siparis_NoFiyat);
        comSepet.Parameters.AddWithValue("@SiparisFiyat", _Siparis_Fiyat);
        comSepet.Parameters.AddWithValue("@DurumID", _DurumID);
        comSepet.Parameters.AddWithValue("@UyeID", _UyeID);
        comSepet.Parameters.AddWithValue("@E_SiparisFaturaID", _E_SiparisFaturaID);
        comSepet.Parameters.AddWithValue("@E_TeslimatAdresiID", _E_Teslimat_AdresiID);
        comSepet.Parameters.AddWithValue("@Not", _Notu);
        comSepet.Parameters.AddWithValue("@IsA", true);
        comSepet.Parameters.AddWithValue("@IT", false);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int Gel = Convert.ToInt32(comSepet.ExecuteScalar());
        comSepet.Dispose();
        con.Close();
        return Gel;
    }
    public string Gonder_AdSoyad(string GelenID)
    {
        string G_AdSoyad = "";
        SqlCommand ComC = new SqlCommand("select AdSoyad from E_Personel where UyeID=@SNO", con);
        ComC.Parameters.AddWithValue("@SNO", GelenID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = ComC.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                G_AdSoyad = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        ComC.Dispose();
        return G_AdSoyad;
    }
    //
    public bool Siparis_Kart_Cekim_Kayit(string _Uye_ID, string _Siparis_ID, string _Banka, string _TaksitSay, string _RefNo, string _GropID, string _TransID, string _Code, string _KartNo)
    {
        SqlCommand comG = new SqlCommand("insert into E_Siparis_Kart_Cekim values(@UyeID,@SiparisID,@Banka,@TakSay,@RefNo,@GropID,@TransID,@Code,@KNO)", con);
        comG.Parameters.AddWithValue("@UyeID", _Uye_ID);
        comG.Parameters.AddWithValue("@SiparisID", _Siparis_ID);
        comG.Parameters.AddWithValue("@Banka", _Banka);
        comG.Parameters.AddWithValue("@TakSay", _TaksitSay);
        comG.Parameters.AddWithValue("@RefNo", _RefNo);
        comG.Parameters.AddWithValue("@GropID", _GropID);
        comG.Parameters.AddWithValue("@TransID", _TransID);
        comG.Parameters.AddWithValue("@Code", _Code);
        comG.Parameters.AddWithValue("@KNO", _KartNo);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (comG.ExecuteNonQuery() > 0)
        {
            comG.Dispose();
            con.Close();
            return true;
        }
        else
        {
            comG.Dispose();
            con.Close();
            return false;
        }
       
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
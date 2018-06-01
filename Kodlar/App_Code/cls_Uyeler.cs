using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Uyeler
/// </summary>
public class cls_Uyeler : IDisposable
{
    public static bool KontrolEtUyemi(string Eposta)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        bool bakem = false;
        SqlCommand Kontrol = new SqlCommand("select UyeID from E_Uyeler where KullaniciAdi=@Y", con);
        Kontrol.Parameters.AddWithValue("@Y", Ortak.Encrypt(Eposta));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = Kontrol.ExecuteReader();
        if (dr.HasRows)
        {
            bakem = true;
        }
        else
        {
            bakem = false;
        }
        con.Close();
        Kontrol.Dispose();
        return bakem;
    }
    public static int KontrolEtUyemi_Twitter(string Twitter_User, string TwitterID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        int bakem = 0;
        SqlCommand Kontrol = new SqlCommand("select UyeID from E_Uyeler where TwitUsername=@T and TwitterID=@TID", con);
        Kontrol.Parameters.AddWithValue("@T", Ortak.Encrypt(Twitter_User));
        Kontrol.Parameters.AddWithValue("@TID", Ortak.Encrypt(TwitterID));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = Kontrol.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                bakem = Convert.ToInt32(dr[0]);
            }
        }
        con.Close();
        Kontrol.Dispose();
        return bakem;
    }
    public static int KontrolEtUyemi_FaceBook(string Facebook_User, string FaceID)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        int bakem = 0;
        SqlCommand Kontrol = new SqlCommand("select UyeID from E_Uyeler where FaceUsername=@F", con);
        Kontrol.Parameters.AddWithValue("@F", Ortak.Encrypt(Facebook_User));
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = Kontrol.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                bakem = Convert.ToInt32(dr[0]);
            }
        }
        con.Close();
        Kontrol.Dispose();
        return bakem;
    }
    public static bool Kullanici_KayitEkle(string AdSoyadBox, string SabitTelefonbox, string ISTelefonbox, string CepBox, string SehirAdim, string IlceAydi, string Epostabox, string sifre)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        bool durum = false;
        SqlCommand comKayitEk = new SqlCommand("insert into E_Personel values(@AdSoyad,@TlfBox,@IsTlfBox,@CepBox,@SehirID,@IlceID,@EPostaBox,@KayitTarihi,@Log,@IsA); select scope_identity()", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", Ortak.Encrypt(AdSoyadBox));
        comKayitEk.Parameters.AddWithValue("@TlfBox", Ortak.Encrypt(SabitTelefonbox));
        comKayitEk.Parameters.AddWithValue("@IsTlfBox", Ortak.Encrypt(ISTelefonbox));
        comKayitEk.Parameters.AddWithValue("@CepBox", Ortak.Encrypt(CepBox));
        comKayitEk.Parameters.AddWithValue("@SehirID", SehirAdim);
        comKayitEk.Parameters.AddWithValue("@IlceID", IlceAydi);
        comKayitEk.Parameters.AddWithValue("@EPostaBox", Ortak.Encrypt(Epostabox));
        comKayitEk.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
        comKayitEk.Parameters.AddWithValue("@Log", AdSoyadBox);
        comKayitEk.Parameters.AddWithValue("@IsA", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int UyeID = Convert.ToInt32(comKayitEk.ExecuteScalar());
        if (UyeID > 0)
        {
            SqlCommand comKayitKullanici = new SqlCommand("insert into E_Uyeler values(@Yuser,@Pwd,@FID,@FUN,@TUN,@TID,@UyeID,@IsA)", con);
            comKayitKullanici.Parameters.AddWithValue("@Yuser", Ortak.Encrypt(Epostabox));
            comKayitKullanici.Parameters.AddWithValue("@Pwd", Ortak.Encrypt(sifre));
            comKayitKullanici.Parameters.AddWithValue("@FID", DBNull.Value);
            comKayitKullanici.Parameters.AddWithValue("@FUN", DBNull.Value);
            comKayitKullanici.Parameters.AddWithValue("@TUN", DBNull.Value);
            comKayitKullanici.Parameters.AddWithValue("@TID", DBNull.Value);
            comKayitKullanici.Parameters.AddWithValue("@UyeID", UyeID);
            comKayitKullanici.Parameters.AddWithValue("@IsA", true);
            if (comKayitKullanici.ExecuteNonQuery() > 0)
            {
                SqlCommand com = new SqlCommand("insert into E_SiparisFaturaAdresi(SehirID,IlceID,UyeID,TeslimatAdres) values(@SehirID,@IlceID,@UyeID,@Teslimat)", con);
                com.Parameters.AddWithValue("@SehirID", SehirAdim);
                com.Parameters.AddWithValue("@IlceID", IlceAydi);
                com.Parameters.AddWithValue("@UyeID", UyeID);
                com.Parameters.AddWithValue("@Teslimat", false);
                if (com.ExecuteNonQuery() > 0)
                {
                    SqlCommand com_Tes = new SqlCommand("insert into E_SiparisTeslimatAdresi(SehirID,IlceID,UyeID) values(@SehirID,@IlceID,@UyeID)", con);
                    com_Tes.Parameters.AddWithValue("@SehirID", SehirAdim);
                    com_Tes.Parameters.AddWithValue("@IlceID", IlceAydi);
                    com_Tes.Parameters.AddWithValue("@UyeID", UyeID);
                    if (com_Tes.ExecuteNonQuery() > 0)
                    {
                        con.Close();
                        com.Dispose();
                        com_Tes.Dispose();
                        durum = true;
                    }
                    else
                    {
                        con.Close();
                        com.Dispose();
                        com_Tes.Dispose();
                        durum = false;
                    }
                }
                else
                {
                    comKayitKullanici.Dispose();
                    durum = false;
                }
            }
            else
            {
                con.Close();
                comKayitEk.Dispose();
                durum = false;
            }
        }
        return durum;
    }
    public static int Kullanici_KayitEkle_Twitter(string Twitter_UserName, string TwitterID, string AdiSoyadi)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        int Gidecek_ID = 0;
        SqlCommand comKayitEk = new SqlCommand("insert into E_Personel(AdSoyad,EPostaBox,KayitTarihi,Log_Index,IsActive) values(@AdSoyad,@EPosta,@KayitTarihi,@Log,@IsA); select scope_identity()", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", Ortak.Encrypt(AdiSoyadi));
        comKayitEk.Parameters.AddWithValue("@EPosta", Ortak.Encrypt("twitterkullanicisi@eposta.com"));
        comKayitEk.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
        comKayitEk.Parameters.AddWithValue("@Log", AdiSoyadi);
        comKayitEk.Parameters.AddWithValue("@IsA", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int UyeID = Convert.ToInt32(comKayitEk.ExecuteScalar());
        if (UyeID > 0)
        {
            SqlCommand comKayitKullanici = new SqlCommand("insert into E_Uyeler(TwitUsername,TwitterID,UyeID,IsActive) values(@TUN,@TID,@UyeID,@IsA)", con);
            comKayitKullanici.Parameters.AddWithValue("@TUN", Ortak.Encrypt(Twitter_UserName));
            comKayitKullanici.Parameters.AddWithValue("@TID", Ortak.Encrypt(TwitterID));
            comKayitKullanici.Parameters.AddWithValue("@UyeID", UyeID);
            comKayitKullanici.Parameters.AddWithValue("@IsA", true);
            if (comKayitKullanici.ExecuteNonQuery() > 0)
            {
                SqlCommand com = new SqlCommand("insert into E_SiparisFaturaAdresi(SehirID,IlceID,UyeID,TeslimatAdres) values(@SehirID,@IlceID,@UyeID,@Teslimat)", con);
                com.Parameters.AddWithValue("@SehirID", 0);
                com.Parameters.AddWithValue("@IlceID", 0);
                com.Parameters.AddWithValue("@UyeID", UyeID);
                com.Parameters.AddWithValue("@Teslimat", false);
                if (com.ExecuteNonQuery() > 0)
                {
                    SqlCommand com_Tes = new SqlCommand("insert into E_SiparisTeslimatAdresi(SehirID,IlceID,UyeID) values(@SehirID,@IlceID,@UyeID)", con);
                    com_Tes.Parameters.AddWithValue("@SehirID", 0);
                    com_Tes.Parameters.AddWithValue("@IlceID", 0);
                    com_Tes.Parameters.AddWithValue("@UyeID", UyeID);
                    if (com_Tes.ExecuteNonQuery() > 0)
                    {
                        Gidecek_ID = UyeID;
                    }
                    com_Tes.Dispose();
                }
                com.Dispose();
            }
            comKayitKullanici.Dispose();
        }
        comKayitEk.Dispose();
        con.Close();
        return Gidecek_ID;
    }
    public static int Kullanici_KayitEkle_Facebook(string FaceBook_UserName, string FaceID, string AdiSoyadi, string EPosta)
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        int Gidecek_ID = 0;
        SqlCommand comKayitEk = new SqlCommand("insert into E_Personel(AdSoyad,EPostaBox,KayitTarihi,Log_Index,IsActive) values(@AdSoyad,@EPosta,@KayitTarihi,@Log,@IsA); select scope_identity()", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", Ortak.Encrypt(AdiSoyadi));
        comKayitEk.Parameters.AddWithValue("@EPosta", Ortak.Encrypt(EPosta));
        comKayitEk.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
        comKayitEk.Parameters.AddWithValue("@Log", AdiSoyadi);
        comKayitEk.Parameters.AddWithValue("@IsA", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        int UyeID = Convert.ToInt32(comKayitEk.ExecuteScalar());
        if (UyeID > 0)
        {
            SqlCommand comKayitKullanici = new SqlCommand("insert into E_Uyeler(FaceID,FaceUsername,UyeID,IsActive) values(@FID,@FUN,@UyeID,@IsA)", con);
            comKayitKullanici.Parameters.AddWithValue("@FID", Ortak.Encrypt(FaceID));
            comKayitKullanici.Parameters.AddWithValue("@FUN", Ortak.Encrypt(FaceBook_UserName));
            comKayitKullanici.Parameters.AddWithValue("@UyeID", UyeID);
            comKayitKullanici.Parameters.AddWithValue("@IsA", true);
            if (comKayitKullanici.ExecuteNonQuery() > 0)
            {
                SqlCommand com = new SqlCommand("insert into E_SiparisFaturaAdresi(SehirID,IlceID,UyeID,TeslimatAdres) values(@SehirID,@IlceID,@UyeID,@Teslimat)", con);
                com.Parameters.AddWithValue("@SehirID", 0);
                com.Parameters.AddWithValue("@IlceID", 0);
                com.Parameters.AddWithValue("@UyeID", UyeID);
                com.Parameters.AddWithValue("@Teslimat", false);
                if (com.ExecuteNonQuery() > 0)
                {
                    SqlCommand com_Tes = new SqlCommand("insert into E_SiparisTeslimatAdresi(SehirID,IlceID,UyeID) values(@SehirID,@IlceID,@UyeID)", con);
                    com_Tes.Parameters.AddWithValue("@SehirID", 0);
                    com_Tes.Parameters.AddWithValue("@IlceID", 0);
                    com_Tes.Parameters.AddWithValue("@UyeID", UyeID);
                    if (com_Tes.ExecuteNonQuery() > 0)
                    {
                        Gidecek_ID = UyeID;
                    }
                    com_Tes.Dispose();
                }
                com.Dispose();
            }
            comKayitKullanici.Dispose();
        }
        comKayitEk.Dispose();
        con.Close();
        return Gidecek_ID;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

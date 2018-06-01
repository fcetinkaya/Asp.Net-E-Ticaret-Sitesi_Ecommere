using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for Ortak
/// </summary>
public class Ortak : IDisposable
{
    // Şifreleme için kullanılacak Key tanımladır. Kendinize göre değiştirebilirsiniz...
    static readonly string PasswordHash = "P@@Sw0rdi";
    static readonly string SaltKey = "S@LT&KEYi";
    static readonly string VIKey = "@1B2c3D4e5F6g7H89x";

    // Twitter ve Facebook için yeni API kayıt gerekebilir.
    public static string Twitter_API_Key = "";
    public static string Twitter_API_Secret = "";
    public static string Twitter_Access_Token = "";
    public static string Twitter_Access_Token_Secret = "";
    public static string Face_API_Key = "";
    public static string Face_API_Secret = "";
    //
    // Değişecek Bilgiler
    //
    public static string UrlWriteYolu = "cep-telefonu-taki-aksesuari"; // Değiştir
    public static string Eposta = "info@gelisimsoft.com"; // Değiştir
    public static string E_Ticaret_SiteAdi = "Cep Telefonu Takı ve Aksesuarı"; // Değiştir
    public static string SiteAdresi_http = "http://www.gelisimsoft.com"; // Değiştir
    public static string SiteAdresi = "www.gelisimsoft.com"; // Değiştir
    public static string SiteAdresiKısa = "gelisimsoft.com"; //Değiştir
    public static string MailServer = "mail.gelisimsoft.com"; // Değiştir
    public static string Sifre = "ŞİFRE Yazılacak";
    public static string[] EPosta_Gidicek_Adresler = { "info@gelisimsoft.com", "bilgi@gelisimsoft.com" };
    public static string[] Sepet_EPosta_Gidicek_Adresler = { "info@gelisimsoft.com", "bilgi@gelisimsoft.com"};
    public static string SirketAdi = "Gelişimsoft Yazılım Hizmetleri"; //Değiştir
    public static string Adresi = " Adres Yazılacak"; // Değiştir
    public static string TicaretSicil = "1231654"; //Değiştir
    public static string Telefon = "0212 - 111 2233"; //Değiştir
    public static string Fax = "0212 - 111 2244"; //Değiştir
    public static string KargoFirmalari = "MNG Kargo"; //Değiştir
    public static string UcretsizKargoBedeli = "40 TL"; // Değiştir
    public static double SepetIcinKargo_Degeri = 40;
    public static double Odenecek_Kargo_Ucreti = 5;
    public static double Odenecek_Havale_Indirim = 3;
    public static double Odenecek_Kapida_Odeme = 5;
    public static string PayPay_Icin_Eposta = "Paypal kayıt olunun adres";
    // Buraya yazılacak tanımla web sitesinin genelinde gösterilir.
    public static string WebSitesiBuyukIsim = "GELİŞİMSOFT"; // Değiştir
    public static string WebSitesiKucukIsim = "Gelişimsoft Yazılım"; // Değiştir
    public static void MesajGoster(string mesaj)//Çalışıyor
    {
        Page page = HttpContext.Current.Handler as Page;

        if (page != null)
        {
            mesaj = mesaj.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + mesaj + "');", true);
        }
    }
    public static string Encrypt(string plainText)
    {
      
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        byte[] cipherTextBytes;

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                cryptoStream.Close();
            }
            memoryStream.Close();
        }
        return Convert.ToBase64String(cipherTextBytes);
    }
    public static string Decrypt(string encryptedText)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
    }
    public static bool E_BultenKayit(string EPosta_Adres)
    {
        bool durum = false;
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlCommand com = new SqlCommand("insert into E_EBulten values(@Eposta,@Excel,@G,@Isa)", con);
        com.Parameters.AddWithValue("@Eposta", Encrypt(EPosta_Adres));
        com.Parameters.AddWithValue("@Excel", DBNull.Value);
        com.Parameters.AddWithValue("@G", true);
        com.Parameters.AddWithValue("@Isa", true);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            durum = true;
        }
        else
        {
            durum = false;
        }
        con.Close();
        com.Dispose();
        return durum;
    }
    public static string E_PostaAdresi_Donder(string _UyeID)
    {
        string Adres = "";
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlCommand com = new SqlCommand("select KullaniciAdi from E_Uyeler where UyeID=@ID", con);
        com.Parameters.AddWithValue("@ID", _UyeID);

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Adres = dr[0].ToString();
            }
        }
        con.Close();
        com.Dispose();
        return Adres;
    }
    public static bool Urun_Eklenince_HaberdarEt_Uye(string UyeID, string Aciklama)
    {
        string E_Posta_Gelen = E_PostaAdresi_Donder(UyeID);
        bool durum = false;
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlCommand com = new SqlCommand("insert into E_Urunler_HaberdarEt values(@Eposta,@UID,@Aciklama,@IT)", con);
        com.Parameters.AddWithValue("@Eposta", E_Posta_Gelen);
        com.Parameters.AddWithValue("@UID", UyeID);
        com.Parameters.AddWithValue("@Aciklama", Aciklama);
        com.Parameters.AddWithValue("@IT", false);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            durum = true;
        }
        else
        {
            durum = false;
        }
        con.Close();
        com.Dispose();
        return durum;
    }
    public static bool Urun_Eklenince_HaberdarEt(string EPosta_Adres, string Aciklama)
    {
        bool durum = false;
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlCommand com = new SqlCommand("insert into E_Urunler_HaberdarEt values(@Eposta,@UID,@Aciklama,@IT)", con);
        com.Parameters.AddWithValue("@Eposta", Encrypt(EPosta_Adres));
        com.Parameters.AddWithValue("@UID", DBNull.Value);
        com.Parameters.AddWithValue("@Aciklama", Aciklama);
        com.Parameters.AddWithValue("@IT", false);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            durum = true;
        }
        else
        {
            durum = false;
        }
        con.Close();
        com.Dispose();
        return durum;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
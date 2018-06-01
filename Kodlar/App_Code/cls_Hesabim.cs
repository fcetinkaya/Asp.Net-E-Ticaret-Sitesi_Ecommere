using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class cls_Hesabim : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public string[] Gonder_Personel_Bilgileri(string GelenID)
    {
        string[] Personel = new string[7];
        SqlCommand comg = new SqlCommand("select AdSoyad,TlfBox,IsTlfBox,CepBox,SehirID,IlceID,EpostaBox from E_Personel where UyeID=@ID", con);
        comg.Parameters.AddWithValue("@ID", GelenID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comg.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Personel[0] = Ortak.Decrypt(dr["AdSoyad"].ToString());
                Personel[1] = Ortak.Decrypt(dr["TlfBox"].ToString());
                Personel[2] = Ortak.Decrypt(dr["IsTlfBox"].ToString());
                Personel[3] = Ortak.Decrypt(dr["CepBox"].ToString());
                Personel[4] = dr["SehirID"].ToString();
                Personel[5] = dr["IlceID"].ToString();
                Personel[6] = Ortak.Decrypt(dr["EpostaBox"].ToString());
            }
        }
        else
        {
            Personel[0] = "";
        }
        dr.Close();
        comg.Dispose();
        return Personel;
    }
    public string[] Gonder_Fatura_Adresi(string GelenID)
    {
        string[] Personel = new string[11];
        SqlCommand comg = new SqlCommand("select E_SiparisFaturaID,YetkiliAdSoyad,FirmaAdi,VergiDairesi,VergiNo,SehirID,SehirAdi,IlceID,IlceAdi,FaturaAdresi,TeslimatAdres from E_SiparisFaturaAdresi where UyeID=@ID", con);
        comg.Parameters.AddWithValue("@ID", GelenID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comg.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Personel[0] = Ortak.Decrypt(dr["YetkiliAdSoyad"].ToString());
                Personel[1] = Ortak.Decrypt(dr["FirmaAdi"].ToString());
                Personel[2] = Ortak.Decrypt(dr["VergiDairesi"].ToString());
                Personel[3] = Ortak.Decrypt(dr["VergiNo"].ToString());
                Personel[4] = dr["SehirID"].ToString();
                Personel[5] = dr["IlceID"].ToString();
                Personel[6] = Ortak.Decrypt(dr["FaturaAdresi"].ToString());
                Personel[7] = dr["TeslimatAdres"].ToString();
                Personel[8] = dr["SehirAdi"].ToString();
                Personel[9] = dr["IlceAdi"].ToString();
                Personel[10] = dr["E_SiparisFaturaID"].ToString();
            }
        }
        else
        {
            Personel[0] = "";
        }
        dr.Close();
        comg.Dispose();
        return Personel;
    }
    public string[] Gonder_Teslimat_Adresi(string GelenID)
    {
        string[] Personel = new string[10];
        SqlCommand comg = new SqlCommand("select E_TeslimatAdresiID,TckimlikNo,EPostaAdresi,CepTelefonu,Telefon,SehirID,SehirAdi,IlceID,IlceAdi,Adres from E_SiparisTeslimatAdresi where UyeID=@ID", con);
        comg.Parameters.AddWithValue("@ID", GelenID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = comg.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Personel[0] = Ortak.Decrypt(dr["TckimlikNo"].ToString());
                Personel[1] = Ortak.Decrypt(dr["EPostaAdresi"].ToString());
                Personel[2] = Ortak.Decrypt(dr["CepTelefonu"].ToString());
                Personel[3] = Ortak.Decrypt(dr["Telefon"].ToString());
                Personel[4] = dr["SehirID"].ToString();
                Personel[5] = dr["IlceID"].ToString();
                Personel[6] = Ortak.Decrypt(dr["Adres"].ToString());
                Personel[7] = dr["SehirAdi"].ToString();
                Personel[8] = dr["IlceAdi"].ToString();
                Personel[9] = dr["E_TeslimatAdresiID"].ToString();
            }
        }
        else
        {
            Personel[0] = "";
        }
        dr.Close();
        comg.Dispose();
        return Personel;
    }
    public bool SifreYenileme(string GelenAydi, string Sifre)
    {
        SqlCommand com = new SqlCommand("update E_Uyeler set Pass=@S where IsActive=1 and UyeID=@ID", con);
        com.Parameters.AddWithValue("@S", Ortak.Encrypt(Sifre));
        com.Parameters.AddWithValue("@ID", GelenAydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            con.Close();
            com.Dispose();
            return true;
        }
        else
        {
            con.Close();
            com.Dispose();
            return false;
        }
    }
    public bool Kullanici_Guncelle(string AdSoyadBox, string SabitTelefonbox, string ISTelefonbox, string CepBox, string SehirAdim, string IlceAydi, string Gelen_Aydi)
    {
        SqlCommand comKayitEk = new SqlCommand("update E_Personel set AdSoyad=@AdSoyad,TlfBox=@TlfBox,IsTlfBox=@IsTlfBox,CepBox=@CepBox,SehirID=@SehirID,IlceID=@IlceID where UyeID=@ID", con);
        comKayitEk.Parameters.AddWithValue("@AdSoyad", Ortak.Encrypt(AdSoyadBox));
        comKayitEk.Parameters.AddWithValue("@TlfBox", Ortak.Encrypt(SabitTelefonbox));
        comKayitEk.Parameters.AddWithValue("@IsTlfBox", Ortak.Encrypt(ISTelefonbox));
        comKayitEk.Parameters.AddWithValue("@CepBox", Ortak.Encrypt(CepBox));
        comKayitEk.Parameters.AddWithValue("@SehirID", SehirAdim);
        comKayitEk.Parameters.AddWithValue("@IlceID", IlceAydi);
        comKayitEk.Parameters.AddWithValue("@ID", Gelen_Aydi);
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
    public bool Siparis_Fatura_Adresi_Guncelle(string YetkiliAdSoyad, string FirmaAdi, string VergiAdresi, string VergiNo, string SehirAdim, string SehirAdi, string IlceAydi, string IlceAdi, string FaturaAdresi, bool Teslimat, string UyeAydi)
    {
        SqlCommand com = new SqlCommand("update E_SiparisFaturaAdresi set YetkiliAdSoyad=@YetkiliAdSoyad,FirmaAdi=@FirmaAdi,VergiDairesi=@VergiDairesi,VergiNo=@VergiNo,SehirID=@SehirID,SehirAdi=@SA,IlceID=@IlceID,IlceAdi=@IA,FaturaAdresi=@FaturaAdresi,TeslimatAdres=@TeslimatAdres where UyeID=@UyeID", con);
        com.Parameters.AddWithValue("@YetkiliAdSoyad", Ortak.Encrypt(YetkiliAdSoyad));
        com.Parameters.AddWithValue("@FirmaAdi", Ortak.Encrypt(FirmaAdi));
        com.Parameters.AddWithValue("@VergiDairesi", Ortak.Encrypt(VergiAdresi));
        com.Parameters.AddWithValue("@VergiNo", Ortak.Encrypt(VergiNo));
        com.Parameters.AddWithValue("@SehirID", SehirAdim);
        com.Parameters.AddWithValue("@SA", SehirAdi);
        com.Parameters.AddWithValue("@IlceID", IlceAydi);
        com.Parameters.AddWithValue("@IA", IlceAdi);
        com.Parameters.AddWithValue("@FaturaAdresi", Ortak.Encrypt(FaturaAdresi));
        com.Parameters.AddWithValue("@TeslimatAdres", Teslimat);
        com.Parameters.AddWithValue("@UyeID", UyeAydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            com.Dispose();
            con.Close();
            return true;
        }
        else
        {
            com.Dispose();
            con.Close();
            return false;
        }
    }
    public bool Siparis_Teslimat_Adresi_Guncelle(string Tckimlik, string EPosta, string CepTlf, string Telefon, string SehirAydi, string SehirAdi, string IlceAydi, string IlceAdi, string Adresi, string UyeAydi)
    {
        SqlCommand com = new SqlCommand("update E_SiparisTeslimatAdresi set TckimlikNo=@TckimlikNo,EPostaAdresi=@EPostaAdresi,CepTelefonu=@CepTelefonu,Telefon=@Telefon,SehirID=@SehirID,SehirAdi=@SA,IlceID=@IlceID,IlceAdi=@IA,Adres=@Adres where UyeID=@UyeID", con);
        com.Parameters.AddWithValue("@TckimlikNo", Ortak.Encrypt(Tckimlik));
        com.Parameters.AddWithValue("@EPostaAdresi", Ortak.Encrypt(EPosta));
        com.Parameters.AddWithValue("@CepTelefonu", Ortak.Encrypt(CepTlf));
        com.Parameters.AddWithValue("@Telefon", Ortak.Encrypt(Telefon));
        com.Parameters.AddWithValue("@SehirID", SehirAydi);
        com.Parameters.AddWithValue("@SA", SehirAdi);
        com.Parameters.AddWithValue("@IlceID", IlceAydi);
        com.Parameters.AddWithValue("@IA", IlceAdi);
        com.Parameters.AddWithValue("@Adres", Ortak.Encrypt(Adresi));
        com.Parameters.AddWithValue("@UyeID", UyeAydi);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (com.ExecuteNonQuery() > 0)
        {
            com.Dispose();
            con.Close();
            return true;
        }
        else
        {
            com.Dispose();
            con.Close();
            return false;
        }
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
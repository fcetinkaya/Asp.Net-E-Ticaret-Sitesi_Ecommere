using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Kargo
/// </summary>
public class cls_Kargo : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Kargolari_Getir(string Uye_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.SiparisNo,E_KargoTakibi.KargoFirmasi,E_KargoTakibi.TakipNo from E_SiparisTakip inner join E_KargoTakibi on E_KargoTakibi.SiparisID=E_SiparisTakip.E_SiparisID where E_KargoTakibi.IsActive=1 and E_SiparisTakip.UyeID=@UID", con);
        dap.SelectCommand.Parameters.AddWithValue("@UID", Uye_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public DataTable Kuryeleri_Getir(string Uye_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_SiparisTakip.SiparisNo,E_KuryeTakibi.FirmaAdi,E_KuryeTakibi.Aciklama,E_KuryeTakibi.Tarih from E_SiparisTakip inner join E_KuryeTakibi on E_KuryeTakibi.SiparisID=E_SiparisTakip.E_SiparisID where E_KuryeTakibi.IsActive=1 and  E_SiparisTakip.UyeID=@UID", con);
        dap.SelectCommand.Parameters.AddWithValue("@UID", Uye_ID);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public string Siparis_Kargolari_TakipNoDonder(string _Siparis_ID)
    {
        string Takip = "";
        SqlCommand dap = new SqlCommand("Select TakipNo from E_KargoTakibi where SiparisID=@SID", con);
        dap.Parameters.AddWithValue("@SID", _Siparis_ID);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlDataReader dr = dap.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Takip = dr[0].ToString();
            }
        }
        dr.Close();
        con.Close();
        dap.Dispose();
        return Takip;
    }
    public DataTable Siparis_Kurye_Getir(string _Siparis_ID)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select E_KuryeTakibi.FirmaAdi,E_KuryeTakibi.Aciklama,E_KuryeTakibi.Tarih from E_KuryeTakibi inner join E_SiparisTakip on E_SiparisTakip.E_SiparisID=E_KuryeTakibi.SiparisID where E_KuryeTakibi.IsActive=1 and E_SiparisTakip.E_SiparisID=@SID", con);
        dap.SelectCommand.Parameters.AddWithValue("@SID", _Siparis_ID);
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
    //public int[] Gel_Kargo_Kurye_Adet(string _Siparis_ID)
    //{
    //    int[] Sayilar = new int[2];
    //    SqlCommand ComC = new SqlCommand("select COUNT(E_KargoTakipID) as [Kargo],(select COUNT(E_KuryeTakipID) as [Kuryem] from E_KuryeTakibi where SiparisID=@SID) from E_KargoTakibi where SiparisID=@SID", con);
    //    ComC.Parameters.AddWithValue("@SID", _Siparis_ID);
    //    if (con.State == ConnectionState.Closed)
    //    {
    //        con.Open();
    //    }
    //    SqlDataReader dr = ComC.ExecuteReader();
    //    if (dr.HasRows)
    //    {
    //        while (dr.Read())
    //        {
    //            Sayilar[0] = Convert.ToInt32(dr[0]);
    //            Sayilar[1] = Convert.ToInt32(dr[1]);
    //        }
    //    }
    //    dr.Close();
    //    con.Close();
    //    ComC.Dispose();
    //    return Sayilar;
    //}
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Arama
/// </summary>
public class cls_Arama : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable AramaKelime_GoreGetir_Urunleri(string Kelime)
    {
        SqlDataAdapter dap = new SqlDataAdapter("select UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirim,Indirimli from E_Urunler where SatisIptal=0 and IsActive=1 and (UrunAdi Like '%" + Kelime + "%' or KategoriAdi Like '%" + Kelime + "%' or TelefonAdi Like '%" + Kelime + "%' or ModelAdi Like '%" + Kelime + "%') order by NEWID()", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Urunler_SarjAletleri
/// </summary>
public class cls_Urunler_SarjAletleri : IDisposable
{
    SqlConnection con = new SqlConnection(Yol.ECon);
    public DataTable Anasayfa_SarjAletleri()
    {
        SqlDataAdapter dap = new SqlDataAdapter("select top 4 UrunID,UrunAdi,Logo,EskiFiyat,YeniFiyat,Link,Tukendi,Indirimli from E_Urunler Where SatisIptal=0 and IsActive=1 and KatID in (select KategoriID from E_UrunKategori where UstKategoriID=3) order by NEWID()", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
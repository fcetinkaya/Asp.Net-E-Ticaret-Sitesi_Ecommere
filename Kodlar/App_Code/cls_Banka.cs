using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Banka
/// </summary>
public class cls_Banka : IDisposable
{
    public static DataTable GelBankaBilgiler()
    {
        SqlConnection con = new SqlConnection(Yol.ECon);
        SqlDataAdapter dap = new SqlDataAdapter("select * from E_BankaHesap", con);
        DataTable dt = new DataTable();
        dap.Fill(dt);
        return dt;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
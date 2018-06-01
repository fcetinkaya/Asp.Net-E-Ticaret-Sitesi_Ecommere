using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Kresyolu
/// </summary>
public class Yol:IDisposable
{
    public static string ECon = "Data Source=.;Initial Catalog=GelisimSoft_ETicaretGumus;User ID=Gelisimsoft-E;Password=GelisimSoft_Etic@ret";

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
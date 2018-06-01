using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using ASPSnippets.FaceBookAPI;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Services;
public partial class Rumrum_K : System.Web.UI.Page
{
    cls_Admin_KategoriIslemleri K = new cls_Admin_KategoriIslemleri();
    SqlConnection con = new SqlConnection(Yol.ECon);
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string A = "<script>alert('Kayıt Tamam')</script>";
        Response.Write(A);

        //string K = "'" + Ortak.Encrypt(KullaniciAdi_Box.Text) + "'";
        //string S = "'" + Ortak.Encrypt(Sifre_Box.Text) + "'";
        //SqlCommand com = new SqlCommand("insert into E_A_Giris values(1," + K + "," + S + ",1)", con);
        //if (con.State == ConnectionState.Closed)
        //{
        //    con.Open();
        //}
        //if (com.ExecuteNonQuery() > 0)
        //{
        //    string A = "<script>alert('Kayıt Tamam')</script>";
        //    Response.Write(A);
        //}
        //else
        //{
        //    string A = "<script>alert('Hata')</script>";
        //    Response.Write(A);
        //}
        //com.Dispose();
        //con.Close();
        //con.Dispose();
        //SqlConnection.ClearPool(con);

    }
}
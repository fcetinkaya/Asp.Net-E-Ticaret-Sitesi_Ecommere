using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class SecurityCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DİKKAT : TURKCE KARAKTERLER YOK
            string karakterler = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            string cod = "";
            //Rasgele 5 karakter seçtiriyorum
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                cod += karakterler[rnd.Next(0, karakterler.Length)].ToString();

            //oluşturulan bu kod’u sessiona aktaracagım.Cunku bunu  Default sayfasında taşımam gerekıyor.
            Session["SecuriyCode"] = cod;
            //Yukaridaki secili 5 karakteri images olarak oluşturmalıyız.

            //boş bir resim dosyası oluştur
            Bitmap bmp = new Bitmap(100, 21);
            //Graphics sınıfı ile Resmin kontrolu eline al.
            Graphics g = Graphics.FromImage(bmp);
            //DrawString ile 0 ‘a 0 kordinatına cod ‘u yazdır.
            g.DrawString(cod, new Font("Georgia", 12), new SolidBrush(Color.Black), 0, 0);

            //Resmi binary olarak alıp sayfaya yazdırmak ıcın MemoryStream kullandık.
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
            ms.Close();
            ms.Dispose();
            Context.Response.BinaryWrite(ms.GetBuffer());
    }
}
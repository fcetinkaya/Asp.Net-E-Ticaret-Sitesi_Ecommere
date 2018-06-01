<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GuvenliETicaret.aspx.cs" Inherits="GuvenliETicaret" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Güvenli Elektronik Ticaret
    </div>
    <div class="Hakkimizda_Baslik">
        Kredi Kartı Güvenliği
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>'da, kredi kartıyla yapacağınız ödemelerin güvenliği için, en son teknolojiler ve en iyi servis sağlayıcılar kullanır.<br />

        Kişisel bilgilerinizi yazdığınız alanlarda web tarayıcınızın adres çubuğunda bir kilit resmi vardır. Bu kilit resmi, tarayıcınızla gönderdiğiniz hiçbir bilginin üçüncü şahıslarca görünemeyeceğini belirtir.
        <br />
        <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label>, kredi kartı numarası ve şifrelerinizi kayıt etmez, saklamaz. Sitemizden vereceğiniz her sipariş için, oluşturma aşamasında kart bilgilerini yeniden girmenizin nedeni budur.<br />
        Güvenlik anlaşmamızla ilgili ayrıntılı bilgi için, www.geotrust.com adresinden bilgi alabilirsiniz.<br />
    </div>
    <div class="Hakkimizda_Baslik">
        SSL Güvenlik Sertifikası
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl3" runat="server"></asp:Label>, SSL güvenlik sertifikalarının en yüksek standardı olan RapidSSL sertifikasına sahiptir. Bu sertifikaya sahip olmak isteyen tüm firmalar gibi, <asp:Label ID="WebSitesiLbl4" runat="server"></asp:Label> da çok sıkı bir güvenlik denetiminden geçmiştir.<br />
    </div>
    <div class="Hakkimizda_Baslik">
        3D Secure/3 Boyutlu Güvenlik
    </div>
    <div class="Hakkimizda_Icerik">
        3D Secure, özellikle internet alışverişlerinin güvenliğini sağlamak amacıyla kredi kartı kuruluşları tarafından geliştirilmiş bir kimlik doğrulama sistemidir. İnternetten yapılan alışverişlerde şifreyle kredi kartı onaylama işlemi olarak da bilinir. Visa Kredi Kartı için kullanılan uygulamasına "Verified by Visa", MasterCard için olanına ise "SecureCode" adı verilir. 
    </div>
</asp:Content>


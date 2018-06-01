<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KargoBilgileri.aspx.cs" Inherits="KargoBilgileri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Kargo Bilgileri
    </div>
    <div class="Hakkimizda_Baslik">
        Ücretsiz Kargo Hakkında
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>
        'da vereceğiniz 40 TL altındaki bütün siparişlerde kargo bedeli sabit 4,90 TL'dır. MNG Kargo bizim adımıza ilgili siparişinizi adresinize kadar teslim eder. Kargo bedeli sipariş aşamasında otomatik olarak alındığından, teslimat aşamasında extra hiçbir bedel ödemezsiniz.
    </div>
    <div class="Hakkimizda_Baslik">
        Satın Aldığım Ürün Ne Zaman Kargoya Verilecek ?
    </div>
    <div class="Hakkimizda_Icerik">
        Satışını yaptığımız ürünlerin kargoya veriliş tarihlerini Alışveriş esnasında belirtilen "1-3 iş günü" gibi ibareler kargo firmasının ürünü teslim etme süreleri olup,  bizim kargoya verdiğimiz günden itibaren geçerli olan tahmini ortalama teslim sürelerdir.  Eğer ürünlerin tedarik veya sevkiyat aşamasında herhangi bir problem yaşanırsa, gerekli olan bilgilendirme sistemimizde kayıtlı olan e-mail adresinize gönderilecektir.
    </div>
    <div class="Hakkimizda_Baslik">
        Kapıda Ödeme
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label>’dan yeni bir hizmet; kapıda ödeme!
Dilerseniz siparişlerinizde kapıda nakit ödemeyi tercih edebilir; Türkiye’nin neresinde olursanız olun sadece 5 TL'ye, evinizin rahatlığında alışveriş yapabilirsiniz.
    </div>
</asp:Content>


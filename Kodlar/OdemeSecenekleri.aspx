<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OdemeSecenekleri.aspx.cs" Inherits="OdemeSecenekleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Ödeme Seçenekleri
    </div>
    <div class="Hakkimizda_Baslik">
        Kapıda Ödeme
    </div>
    <div class="Hakkimizda_Icerik">
        Dilerseniz vereceğiniz siparişlerde, sipariş bedelini kapıda nakit ödemeyi tercih edebilirsiniz. Türkiye’nin her yerinde, evinizin rahatlığında alışverişinizi tamamlayabilirsiniz.
    </div>
    <div class="Hakkimizda_Baslik">
        Kredi Kartıyla Ödeme
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>
        'dan verdiğiniz siparişlerin ödemesini kredi kartıyla yapabilirsiniz.
Sitemizden yapacağınız peşin alışverişlerde tüm bankaların kredi kartlarını kullanabilirsiniz. 
    </div>
    <div class="Hakkimizda_Baslik">
        Paypal ile Ödeme
    </div>
    <div class="Hakkimizda_Icerik">
        Paypal üyesi iseniz, kredi kartı bilgilerinizi sisteme girmeden, hızlı bir şekilde ödemelerinizi gerçekleştirebilirsiniz.
    </div>
    <div class="Hakkimizda_Baslik">
        Havale/EFT ile Ödeme
    </div>
    <div class="Hakkimizda_Icerik">
        Dilerseniz, havale/EFT ile ödeme seçeneğini kullanarak ürün sayfalarımızda belirtilen havale 
indiriminden de yararlanabilirsiniz. Bunun için, havale/EFT yapmak istediğiniz bankayı seçin ve "Havale Devam" tuşuna basın.<br />
        EFT işlemlerinde alıcı olarak "<asp:Label ID="FirmaAdiLbl" runat="server"></asp:Label>" görünecektir. Sipariş onayından sonra oluşacak sipariş numaranızı havale/EFT'nin açıklama bölümüne mutlaka eklemelisiniz. "
    </div>
    <div class="Hakkimizda_Satir">
        <asp:Repeater ID="BankaRepeater" runat="server">
            <ItemTemplate>
                <div class="Hakkimizda_Sol_Satir">
                    <div class="Hakkimizda_Logo">
                        <img src='<%# Eval("Logo","img/Banka_Hesap/{0}") %>' alt='<%# Eval("BankaAdi")%>' />
                    </div>
                    <div class="Hakkimizda_Yazi">
                        <div class="Hakkimizda_Baslik">
                            <asp:Label ID="BankaAdiLbl" runat="server" Text='<%# Eval("BankaAdi") %>'></asp:Label>
                        </div>
                        <div class="Hakkimizda_Icerik">
                            <asp:Label ID="FirmaAdiLbl" runat="server" Text='<%# Eval("FirmaAdi") %>'></asp:Label>

                            <br />
                            <asp:Label ID="SubeAdiLbl" runat="server" Text='<%# Eval("SubeAdi") %>'></asp:Label>
                            <br />
                            <asp:Label ID="HesapNoLbl" runat="server" Text='<%# Eval("HesapNo") %>'></asp:Label>
                            <br />
                            <asp:Label ID="IBANLbl" runat="server" Text='<%# Eval("IBAN") %>'></asp:Label>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


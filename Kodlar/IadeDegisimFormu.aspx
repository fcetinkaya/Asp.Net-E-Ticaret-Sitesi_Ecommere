<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IadeDegisimFormu.aspx.cs" Inherits="IadeDegisimFormu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        İade / Değişim Formu
    </div>
    <div class="Footer_Linkler_Baslik">
        Satın alacağınız herhangi bir ürünü, 7 iş günü içerisinde iade etmeniz mümkündür. İadeniz, alışveriş yaptığınız karta gerçekleştirilecektir. Kredi kartı dışında alışveriş yaptıysanız kendi adınıza kayıtlı IBAN numaranıza iade yapılır.
    </div>
    <div class="Hakkimizda_Buyuk_Baslik">
        İade İçin Şartlar !
    </div>
    <div class="Hakkimizda_Icerik">
        <ul style="list-style-type: circle; padding: 5px;">
            <li>İade edilecek ürün, varsa hediyesi ve ürünün bütün standart parçaları, ambalajları hasarsız ve tam olarak orijinal paketleri ile birlikte gönderilmelidir.</li>
            <li>Kargo paketinden kırık/hasarlı çıkan ürünlerin iadesi için kargo elemanına tutanak yazdırmalısınız.</li>
            <li>Tutanak olmadığı durumlarda paket içerisinden kırık çıkan ürünlerin zararı karşılanmaz.</li>
            <li>Ürün iadelerini yalnızca MNG Kargo ile yapabilirsiniz. Bunun dışında gönderilen ürün iadeleri işleme alınmaz.</li>
        </ul>
    </div>
    <div class="Hakkimizda_Buyuk_Baslik">
        İade Formu
    </div>
    <div id="panelsepet" style="float: left; width: 1000px; height: auto; margin: 20px 0px;" runat="server">
        <div class="form_Elementleri">
            <asp:DropDownList ID="SiparisNoDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Sipariş Seçiniz."
                Display="None" ControlToValidate="SiparisNoDrop" ValidationGroup="iade"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="BankaAdiBox" runat="server" placeholder="Banka Adı" CssClass="TextBox_F" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Banka Adını Yazınız."
                Display="None" ControlToValidate="BankaAdiBox" ValidationGroup="iade"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="IBANBox" runat="server" placeholder="IBAN Numarası" CssClass="TextBox_F" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="IBAN Numarasını Yazınız."
                Display="None" ControlToValidate="IBANBox" ValidationGroup="iade"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="IadeNedeniDrop" runat="server" CssClass="DropDown_F">
                <asp:ListItem Value="0">İade Nedenini Seçiniz</asp:ListItem>
                <asp:ListItem>Beğenmedim</asp:ListItem>
                <asp:ListItem>Cihaz ile Uyumsuz</asp:ListItem>
                <asp:ListItem>Hatalı Ürün</asp:ListItem>
                <asp:ListItem>Kırık/Bozuk/Defolu Ürün</asp:ListItem>
                <asp:ListItem>Diğer</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="İade Nedenini Seçiniz."
                Display="None" ControlToValidate="IadeNedeniDrop" InitialValue="0" ValidationGroup="iade"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="AciklamaBox" runat="server" placeholder="Açıklama" CssClass="TextBox_F" TextMode="MultiLine" Height="150px" MaxLength="250" /><br />
            <asp:Button ID="GonderBtn" runat="server" CssClass="btn-orange" Text="Gönder" OnClick="GonderBtn_Click" ValidationGroup="iade" />
            <asp:ValidationSummary ID="ValidationSummary_Teslimat" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="iade" />
        </div>
    </div>
    <div id="HataDiv" class="uyari" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">İade işlemleri için siparişiniz bulunmamaktadır.</span>
        <br />
        <a href="Default.aspx" class="Footer_Link">Sipariş vermek için dilediğiniz ürünü/ürünleri sepetinize ekleyin.<br />
            Sepete eklediğiniz ürünler, sipariş vermediğiniz veya silmediğiniz sürece sepetinizde kalır. </a>
    </div>
    <div id="Islem_Tamam" class="Basarili" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">İade işlem talebiniz kayıt edilmiştir.<br />
            En yakın sürede müşteri hizmetleri yetkilisi sizi arayıp bilgi vericektir.</span>
        <br />
    </div>
</asp:Content>


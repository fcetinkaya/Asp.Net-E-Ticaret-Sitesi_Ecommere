<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OdemeBildirimFormu.aspx.cs" Inherits="OdemeBildirimFormu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Ödeme Bildirimi
    </div>
    <div class="Footer_Linkler_Baslik">
        Yaptığınız sipariş sonucu seçtiğiniz ödeme seçeneği "EFT / HAVALE" ise lütfen aşağıdaki formu doldurarak bize bildirimde bulununuz. Siparişiniz için ödeme kontrol sistemi daha hızlı işleyecektir. Para transferi yaptığınız banka ve sipariş numarasını seçiniz.
    </div>
    <div id="panelsepet" style="float: left; width: 1000px; height: auto; margin: 20px 0px;" runat="server">
        <div class="form_Elementleri">
            <asp:DropDownList ID="SiparisNoDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Sipariş Seçiniz."
                Display="None" ControlToValidate="SiparisNoDrop" ValidationGroup="siparis"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="BankaDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bankayı Seçiniz."
                Display="None" ControlToValidate="BankaDrop" ValidationGroup="siparis"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TarihBox" runat="server" placeholder="EFT / HAVALE Tarihi" CssClass="TextBox_F" />
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="TarihBox"
                Format="dd.MM.yyyy" FirstDayOfWeek="Monday">
            </asp:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Tarihi Seçiniz."
                Display="None" ControlToValidate="TarihBox" ValidationGroup="siparis"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="GonderBtn" runat="server" CssClass="btn-orange" Text="Gönder" OnClick="GonderBtn_Click" ValidationGroup="siparis" />
            <asp:ValidationSummary ID="ValidationSummary_Teslimat" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="siparis" />
        </div>
    </div>
    <div id="HataDiv" class="uyari" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">Ödeme bildirim işlemleri için siparişiniz bulunmamaktadır.</span>
        <br />
        <a href="Default.aspx" class="Footer_Link">Sipariş vermek için dilediğiniz ürünü/ürünleri sepetinize ekleyin.<br />
            Sepete eklediğiniz ürünler, sipariş vermediğiniz veya silmediğiniz sürece sepetinizde kalır. </a>
    </div>
    <div id="Islem_Tamam" class="Basarili" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">Ödeme bildirimi talebiniz kayıt edilmiştir.<br />
            En yakın sürede müşteri hizmetleri yetkilisi sizi arayıp bilgi vericektir.</span>
        <br />
    </div>

</asp:Content>


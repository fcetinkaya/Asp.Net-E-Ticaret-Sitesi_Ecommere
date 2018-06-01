<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TedarikciBasvurusu.aspx.cs" Inherits="TedarikciBasvurusu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Tedarikçi Başvurusu
    </div>
    <div class="Hakkimizda_Icerik">
        Türkiye'nin lider cep telefonu aksesuar marketi
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>'da ürünleriniz satılmasını ister misiniz ?'<br />
        Lütfen aşağıdaki formu eksiksiz doldurunuz. Bilgileriniz tarafımıza ulaştıktan en geç 24 saat içerisinde pazarlama birimi sizinle irtibata geçicektir.<br />
        <br />
    </div>
    <div class="form_Elementleri">
        <asp:TextBox ID="AdSoyadBox" runat="server" placeholder="Adınız Soyadınız" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Adınızı ve Soyadınızı Yazınız."
            Display="None" ControlToValidate="AdSoyadBox" ValidationGroup="Ted"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="FirmaAdiBox" runat="server" placeholder="Firma Adı" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Firma Adını Yazınız."
            Display="None" ControlToValidate="FirmaAdiBox" ValidationGroup="Ted"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="IsTlfBox" runat="server" placeholder="İş Telefonu" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="İş Telefonu Yazınız."
            Display="None" ControlToValidate="IsTlfBox" ValidationGroup="Ted"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="CepTlfBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cep Telefonu Yazınız."
            Display="None" ControlToValidate="CepTlfBox" ValidationGroup="Ted"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="EPostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" />
        <br />
        <asp:TextBox ID="WebAdresiBox" runat="server" placeholder="Web Sitesi" CssClass="TextBox_F" /><br />
        <asp:Button ID="GonderBtn" runat="server" CssClass="btn-orange" Text="Gönder" ValidationGroup="Ted" OnClick="GonderBtn_Click" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Ted" />
    </div>
</asp:Content>


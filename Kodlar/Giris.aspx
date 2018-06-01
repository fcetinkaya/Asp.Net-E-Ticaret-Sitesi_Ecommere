<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form">
        <div id="GirisDiv">GİRİŞ</div>
        <div class="line"></div>
        <!-- If you don't want a social buttons, delete all of these code -->
        <asp:Button ID="FacebookBtn" runat="server" CssClass="btn-facebook" Text="Facebook ile bağlan" OnClick="FacebookBtn_Click" />
        <asp:Button ID="TwitterBtn" runat="server" CssClass="btn-twitter" Text="Twitter ile bağlan" OnClick="TwitterBtn_Click" />
        <!-- Till here -->
        <!-- Span class ie-placeholder is there for IE browser. IE doesn't support placeholder attribute -->
        <div class="form_Elementleri">
            <asp:TextBox ID="KullaniciAdiBox" runat="server" placeholder="Kullanıcı Adı" CssClass="TextBox_F" />
            <asp:TextBox ID="SifreBox" runat="server" placeholder="Şifre" CssClass="TextBox_F" TextMode="Password" />
            <div style="margin-bottom: 20px;">
                <asp:LinkButton ID="SifremiUnuttumLink" runat="server" CssClass="forgotten-password-link" Text="Şifremi Unuttum" OnClick="SifremiUnuttumLink_Click"></asp:LinkButton>
            </div>
            <asp:Button ID="GirisBtn" runat="server" CssClass="btn-orange" Text="Giriş" OnClick="GirisBtn_Click" />
            <asp:Button ID="YeniKayitBtn" runat="server" CssClass="btn-Green" Text="Yeni Kayıt" PostBackUrl="~/UyeOl.aspx" />
        </div>

        <!-- FORGOTTEN PASSWORD -->
        <div id="SifremiUnuttumDiv" runat="server" visible="false">
            <div class="form_Elementleri">
                <asp:TextBox ID="SifremiUnuttumEpostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" />
                <asp:Button ID="SifremiUnuttumBtn" runat="server" CssClass="btn-orange" Text="Gönder" OnClick="SifremiUnuttumBtn_Click" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>


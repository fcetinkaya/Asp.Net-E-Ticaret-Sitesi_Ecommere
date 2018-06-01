<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuDosyayiGonderme.aspx.cs" Inherits="Rumrum_K" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Acss/layout.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <asp:TextBox ID="KullaniciAdi_Box" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox><br />
            <asp:TextBox ID="Sifre_Box" runat="server" placeholder="Şifre"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Kayıt" OnClick="Button1_Click" />
        </div>
        <br />
        <br />
        <p>
            <p></p>
        </p>
          <p></p>
    </form>
</body>
</html>

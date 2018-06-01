<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacebookAuthentication.aspx.cs" Inherits="FacebookAuthentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">
            <hr />
            <table>
                <tr>
                    <td rowspan="99" valign="top">
                        <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
                    </td>
                </tr>
                <tr>
                    <td>ID:<asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>UserName:<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Name:<asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Gender:<asp:Label ID="lblGender" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Location:<asp:Label ID="lblLocation" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Birthday:<asp:Label ID="lblBirthday" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Hata.aspx.cs" Inherits="Hata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var sure = 3;
        var milisec = 0;
        var seconds = 0;
        function display() {
            if (milisec >= 10) {
                milisec = 0;
                seconds += 1;
            }
            else
                milisec += 1;
            if (milisec == sure) location.href = 'Default.aspx';
            else setTimeout("display()", 2000);
        }
        display();
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: 0px auto; text-align: center;">
        <img src="image/404.png" alt="" />
    </div>
</asp:Content>


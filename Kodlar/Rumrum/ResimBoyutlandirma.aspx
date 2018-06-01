<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="ResimBoyutlandirma.aspx.cs" Inherits="Rumrum_ResimBoyutlandirma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <label class="labelfiel">
            Küçük resim (210x210)</label>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textfield" Width="410px" />

    </fieldset>
    <footer>
        <div class="submit_link">
            <asp:Button ID="btnUrunKayit" runat="server" Text="Ürünü Kaydet"
                CssClass="alt_btn" OnClick="btnUrunKayit_Click" />
        </div>
    </footer>
</asp:Content>


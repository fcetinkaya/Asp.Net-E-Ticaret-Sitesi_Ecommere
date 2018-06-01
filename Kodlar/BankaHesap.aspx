<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankaHesap.aspx.cs" Inherits="BankaHesap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Banka Hesap Numaraları
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


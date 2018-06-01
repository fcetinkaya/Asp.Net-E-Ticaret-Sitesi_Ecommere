<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KargoDetay.aspx.cs" Inherits="KargoDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Link_FontYok" NavigateUrl="~/SiparisKargoTakibi.aspx">Kargo Takibi</asp:HyperLink>&nbsp;>
        Sipariş No -
        <asp:Label ID="SiparisNoLbl" runat="server"></asp:Label>
    </div>
    <div class="Hakkimizda_Baslik">
        Siparişiniz ile ilgili kargo/kurye detaylarını aşağıda bulabilirsiniz.
    </div>
    <asp:Panel ID="Kargo_Panel" runat="server" Visible="false">
        <div class="Sepet_Baslik">
            Kargo Detayı
        </div>
        <asp:DataList ID="Kargo_DataList" runat="server" GridLines="Both">
            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
            <HeaderTemplate>
                <%--   <div style="float: left; height: 20px; width: 100px; text-align: center; padding: 5px;">
                    Sipariş No
                </div>
                <div style="float: left; height: 20px; width: 150px; text-align: center; padding: 5px;">
                    Tarih
                </div>
                <div style="float: left; height: 20px; width: 200px; text-align: center; padding: 5px;">
                    Ödeme Tipi
                </div>
                <div style="float: left; height: 20px; width: 250px; text-align: center; padding: 5px;">
                    Durum
                </div>
                <div style="float: left; height: 20px; width: 140px; text-align: center; padding: 5px;">
                    Kargo Takibi
                </div>--%>
            </HeaderTemplate>
            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <ItemTemplate>
                <%--    <div style="float: left; height: 30px; width: 100px; text-align: center; padding: 5px;">
                    <asp:Label ID="SiparisNoLbl" runat="server" Text='<%# Eval("SiparisNo") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 180px; text-align: center; padding: 5px;">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SiparisTarihi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 200px; text-align: center; padding: 5px;">
                    <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("OdemeTipi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 250px; text-align: center; padding: 5px;">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("DurumAd") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 130px; text-align: center; padding: 5px;">
                    <asp:HyperLink ID="DetayID" runat="server" CssClass="Footer_Link" Text="Kargo Takibi" NavigateUrl="~/SiparisKargoTakibi.aspx"></asp:HyperLink>
                </div>--%>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="Kurye_Panel" runat="server" Visible="false">
        <div class="Sepet_Baslik">
            Kurye Detayı
        </div>
        <asp:DataList ID="Kurye_Datalist" runat="server" GridLines="Both">
            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
            <HeaderTemplate>
                <div style="float: left; height: 20px; width: 250px;">
                    Firma Adı
                </div>
                <div style="float: left; height: 20px; width: 350px;">
                    Açıklama
                </div>
                <div style="float: left; height: 20px; width: 200px;">
                    Tarih
                </div>
            </HeaderTemplate>
            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <ItemTemplate>
                <div style="float: left; height: 30px; width: 250px;">
                    <%# Eval("FirmaAdi") %>
                </div>
                <div style="float: left; height: 20px; width: 350px;">
                    <%# Eval("Aciklama") %>
                </div>
                <div style="float: left; height: 30px; width: 200px;">
                    <%# Eval("Tarih") %>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <div id="Kargo_YokDiv" class="uyari" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">Bu sipariş ile ilgili kargo/kurye gönderimi bulunmamaktadır.</span>
        <br />
    </div>
</asp:Content>


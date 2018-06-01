<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SiparisKargoTakibi.aspx.cs" Inherits="SiparisKargoTakibi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Kargo Takibi
    </div>
    <asp:DataList ID="KargoBilgiDatalist" runat="server" GridLines="Both" OnItemDataBound="KargoBilgiDatalist_ItemDataBound">
        <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
        <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
        <HeaderTemplate>
            <div style="float: left; height: 20px; width: 200px; padding:5px 0px;">
                Sipariş No
            </div>
            <div style="float: left; height: 20px; width: 450px; padding:5px 0px;">
                Takip No
            </div>
            <div style="float: left; height: 20px; width: 150px; padding:5px 0px;">
                Kargo Durumu
            </div>
        </HeaderTemplate>
        <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
        <ItemTemplate>
            <div style="float: left; height: 20px; width: 200px; padding:5px 0px;">
                <asp:HyperLink ID="SiparisNoLink" runat="server" CssClass="Footer_Link" Text='<%# Eval("SiparisNo") %>'></asp:HyperLink>
            </div>
            <div style="float: left; height: 20px; width: 450px; padding:5px 0px;">
                <asp:Label ID="TakipNoLbl" runat="server" Text='<%# Eval("TakipNo") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
            </div>
            <div style="float: left; height: 20px; width: 150px; padding:5px 0px;">
                <asp:HyperLink ID="KargoDetayLink" runat="server" CssClass="Footer_Link" Text="Kargo Detayı"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div id="KargoYokDiv" class="uyari" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">Bu statüde sipariş için kargo bulunmamaktadır.</span>
        <br />
        <a href="Default.aspx" class="Footer_Link">Sipariş vermek için dilediğiniz ürünü/ürünleri sepetinize ekleyin.<br />
            Sepete eklediğiniz ürünler, sipariş vermediğiniz veya silmediğiniz sürece sepetinizde kalır. </a>
    </div>
</asp:Content>


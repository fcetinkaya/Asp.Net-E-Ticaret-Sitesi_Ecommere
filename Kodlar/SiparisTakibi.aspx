<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SiparisTakibi.aspx.cs" Inherits="SiparisTakibi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Sipariş Takibi
    </div>
    <div id="panelsepet" style="float: left; width: 1000px; height: auto; margin: 20px 0px;" runat="server">
        <div class="form_Elementleri">
            <asp:DropDownList ID="SiparisDurumuDrop" runat="server" CssClass="DropDown_F">
            </asp:DropDownList>
            <asp:Button ID="ListeleBtn" runat="server" CssClass="btn-orange" Text="Listele" OnClick="ListeleBtn_Click" />&nbsp;<asp:Button ID="TumunuButtton" runat="server" CssClass="btn-orange" Text="Hepsini Listele" OnClick="TumunuButtton_Click" />
        </div>
        <div id="Durum_YokDiv" class="uyari" runat="server" visible="false">
            <span class="Hakkimizda_Baslik">Bu statüde siparişiniz bulunmamaktadır.</span>
            <br />
        </div>
        <asp:DataList ID="SiparisListesi_DataList" runat="server" GridLines="Both" OnItemDataBound="SiparisListesi_DataList_ItemDataBound">
            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
            <HeaderTemplate>
                <div style="float: left; height: 20px; width: 130px; text-align: center; padding: 5px;">
                    Sipariş No
                </div>
                <div style="float: left; height: 20px; width: 140px; text-align: center; padding: 5px;">
                    Tarih
                </div>
                <div style="float: left; height: 20px; width: 200px; text-align: center; padding: 5px;">
                    Ödeme Tipi
                </div>
                <div style="float: left; height: 20px; width: 90px; text-align: center; padding: 5px;">
                    Tutar
                </div>
                <div style="float: left; height: 20px; width: 250px; text-align: center; padding: 5px;">
                    Durum
                </div>
                <div style="float: left; height: 20px; width: 110px; text-align: center; padding: 5px;">
                    Detay
                </div>
            </HeaderTemplate>
            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
            <ItemTemplate>
                <div style="float: left; height: 30px; width: 130px; text-align: center; padding: 5px;">
                    <asp:Label ID="SiparisNoLbl" runat="server" Text='<%# Eval("SiparisNo") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 140px; text-align: center; padding: 5px;">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SiparisTarihi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 200px; text-align: center; padding: 5px;">
                    <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("OdemeTipi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 90px; text-align: center; padding: 5px;">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SiparisFiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 250px; text-align: center; padding: 5px;">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("DurumAd") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
                </div>
                <div style="float: left; height: 30px; width: 110px; text-align: center; padding: 5px;">
                    <asp:LinkButton ID="DetayID" runat="server" CssClass="Footer_Link" Text="Sipariş Detayı"></asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div id="SiparisYokDiv" class="uyari" runat="server" visible="false">
        <span class="Hakkimizda_Baslik">Bu statüde siparişiniz bulunmamaktadır.</span>
        <br />
        <a href="Default.aspx" class="Footer_Link">Sipariş vermek için dilediğiniz ürünü/ürünleri sepetinize ekleyin.<br />
            Sepete eklediğiniz ürünler, sipariş vermediğiniz veya silmediğiniz sürece sepetinizde kalır. </a>
    </div>
</asp:Content>


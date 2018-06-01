<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Arama.aspx.cs" Inherits="Arama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Arama | Cep Telefonu Takı ve Aksesuarları</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Kategori_Update" runat="server">
        <ContentTemplate>
            <div class="UrunListeBaslikDiv">
                <div class="UrunListeBaslik_OrtaCizgiDiv">
                    <div class="UrunListeBaslik_SolKisimDiv">
                        <div class="UrunListeBaslik_SolKisimYaziDiv">
                            <asp:Label ID="ArananKelimeLbl" runat="server" Font-Bold="true"></asp:Label>
                            kelimesi için arama sonuçları
                        </div>
                    </div>
                    <div class="UrunListeBaslik_SagKisimDiv">
                        <div class="UrunListeBaslik_SagKisimYaziDiv">
                        </div>
                    </div>
                </div>
            </div>
            <div class="UrunListesiDiv">
                <asp:DataList ID="KategoriRepeater" runat="server" OnItemCommand="KategoriRepeater_ItemCommand" RepeatDirection="Horizontal" Width="980px" RepeatColumns="4">
                    <ItemTemplate>
                        <div class="Kategori_UrunListeItem_IlkDiv">
                            <div class="UrunListeItem_UstKisimDiv">
                                <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                            </div>
                            <div class="UrunListeItem_AltKisimDiv">
                                <div class="UrunListeItem_BaslikLbl">
                                    <asp:HyperLink ID="UrunBaslikLbl" runat="server" Text='<%# Eval("UrunAdi") %>' NavigateUrl='<%# Eval("Link") %>' CssClass="UrunDetay_Link" ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                                </div>
                                <div class="UrunListeItem_EskiFiyatLbl">
                                    <asp:Label ID="UrunEskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                                    TL
                                </div>
                                <div class="UrunListeItem_YebiFiyatLbl">
                                    <asp:Label ID="UrunYeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>'></asp:Label>
                                    TL
                                </div>
                                <div class="UrunListeItem_SepetEkleBtn">
                                    <asp:Button ID="SepetEkleBtn" runat="server" CssClass="Sepet_buttonum" Text="SEPETE EKLE" CommandArgument='<%# Eval("UrunID") %>' CommandName="Ekle" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <div class="UrunListeItem_ArarDiv"></div>
                    </SeparatorTemplate>
                </asp:DataList>
            </div>
            <div class="nav">
                <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand" OnItemDataBound="rptPages_ItemDataBound">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PageIndex")%>'
                            CommandName="lnkbtnPaging" Text='<%#DataBinder.Eval(Container.DataItem, "PageText")%>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="UyariDiv" class="uyari" runat="server" visible="false">
                <span>Uyarı</span><br />
                Aradığınız kelime ile ilgili ürün bulunamadı. 
            </div>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TumModeller.aspx.cs" Inherits="TumModeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="NivoSlide/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="carouselengine/amazingcarousel.js" type="text/javascript"></script>
    <script src="carouselengine/initcarousel-0.js" type="text/javascript"></script>
    <link href="carouselengine/initcarousel-0.css" rel="stylesheet" type="text/css" />
    <title>Tüm Cep Telefonu ve Modeller | Cep Takı ve Aksesuarları</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Çok Satanlar Kılıf-->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Aksesuar ve Takılar
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                </div>
            </div>
        </div>
    </div>
    <div class="UrunListesiDiv">
        <div class="amazingcarousel-container-0">
            <div class="amazingcarousel-0" style="display: block; position: relative; width: 100%; margin: 0px auto 0px;">
                <div class="amazingcarousel-list-container" style="overflow: hidden;">
                    <ul class="amazingcarousel-list">
                        <asp:Repeater ID="CokSatanlarRepeater" runat="server" OnItemDataBound="CokSatanlarRepeater_ItemDataBound">
                            <ItemTemplate>
                                <li class="amazingcarousel-item">
                                    <div class="amazingcarousel-item-container">
                                        <div class="amazingcarousel-image">
                                            <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                                            <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                                                <img src="Urunler/tukendi.png" />
                                            </div>
                                            <div id="IndirimDiv" runat="server" visible="false" style="position: absolute; right: 0; top: 0;">
                                                <img src="Urunler/Indirim.png" />
                                            </div>
                                        </div>
                                        <div class="amazingcarousel-title">
                                            <asp:HyperLink ID="UrunAdiLink" runat="server" NavigateUrl='<%# Eval("Link") %>' ToolTip='<%# Eval("UrunAdi") %>' Text='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                                        </div>
                                        <div class="amazingcarousel-title_alt">
                                            <span style="text-decoration: line-through; color: gray;">
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                                                TL</span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
                                            TL
                                        </div>
                                        <div class="amazingcarousel-Indirim">
                                            <asp:Label ID="IndirimLbl" runat="server" Text='<%# Eval("Indirim") %>'></asp:Label>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="amazingcarousel-prev"></div>
                <div class="amazingcarousel-next"></div>
                <div class="amazingcarousel-nav"></div>
            </div>
        </div>
    </div>
    <!-- Bitti -->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Tüm Cep Telefonu ve Modeller
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="Kategori_Update" runat="server">
        <ContentTemplate>
            <div class="UrunListesiDiv">

                <asp:DropDownList ID="TelefonDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="TelefonDrop_SelectedIndexChanged">
                </asp:DropDownList><br />
                <asp:DropDownList ID="ModelDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                </asp:DropDownList><br />
                <asp:DropDownList ID="KategoriDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                </asp:DropDownList><br />
                <asp:Button ID="UrunleriGetirBtn" runat="server" CssClass="btn-orange" Text="Ürünleri Getir" OnClick="UrunleriGetirBtn_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


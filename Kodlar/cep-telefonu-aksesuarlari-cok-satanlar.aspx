<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cep-telefonu-aksesuarlari-cok-satanlar.aspx.cs" Inherits="cep_telefonu_aksesuarlari_cok_satanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="NivoSlide/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="carouselengine/amazingcarousel.js" type="text/javascript"></script>
    <script src="carouselengine/initcarousel-0.js" type="text/javascript"></script>
    <link href="carouselengine/initcarousel-0.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="KategoriFilter">
        <asp:DropDownList ID="TelefonDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="170px" AppendDataBoundItems="true" OnSelectedIndexChanged="TelefonDrop_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ModelDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="170px" AppendDataBoundItems="true" OnSelectedIndexChanged="ModelDrop_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <!-- Çok Satanlar Kılıf-->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Kıfıflar
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
                        <asp:Repeater ID="Kilif_CokSatanlarRepeater" runat="server" OnItemDataBound="Kilif_CokSatanlarRepeater_ItemDataBound">
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
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label></span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
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
    <!-- Çok Satanlar Koruyucu Filmler  -->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Koruyucu Filmler
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
                        <asp:Repeater ID="KorucuFilmler_Repeater" runat="server" OnItemDataBound="KorucuFilmler_Repeater_ItemDataBound">
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
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label></span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
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
    <!-- Çok Satanlar Kulaklıklar  -->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Kulaklıklar
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
                        <asp:Repeater ID="Kulakliklar_Repeater" runat="server" OnItemDataBound="Kulakliklar_Repeater_ItemDataBound">
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
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label></span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
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
    <!-- Çok Satanlar Şarj Aletler  -->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Şarj Aletleri
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
                        <asp:Repeater ID="SarjAletleri_Repeater" runat="server" OnItemDataBound="SarjAletleri_Repeater_ItemDataBound">
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
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label></span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
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
    <!-- Çok Satanlar Kablo ve Dönüştürücüler  -->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan Kablo ve Dönüştürücüler
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
                        <asp:Repeater ID="KabloveDonusturuculer_Repeater" runat="server" OnItemDataBound="KabloveDonusturuculer_Repeater_ItemDataBound">
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
                                                <asp:Label ID="EskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label></span>
                                            <asp:Label ID="YeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>' Font-Bold="true"></asp:Label>
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
</asp:Content>


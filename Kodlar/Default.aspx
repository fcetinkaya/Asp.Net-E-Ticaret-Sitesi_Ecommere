<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="NivoSlide/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="NivoSlide/jquery.nivo.slider.pack.js" type="text/javascript"></script>
    <link href="NivoSlide/nivo-slider.css" rel="stylesheet" type="text/css" />
    <link href="NivoSlide/default/default.css" rel="stylesheet" type="text/css" />
    <script src="FlexiCouresel/js/jquery.flexisel.js" type="text/javascript"></script>
    <link href="FlexiCouresel/css/style.css" rel="stylesheet" type="text/css" />
    <script src="carouselengine/amazingcarousel.js" type="text/javascript"></script>
    <script src="carouselengine/initcarousel-0.js" type="text/javascript"></script>
    <link href="carouselengine/initcarousel-0.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Haber Slider -->
    <div id="orta_sol_kayanmenu">
        <div class="slider-wrapper theme-default">
            <div id="slider" class="nivoSlider">
                <asp:Repeater ID="HaberRepeater" runat="server" OnItemDataBound="HaberRepeater_ItemDataBound">
                    <ItemTemplate>
                        <asp:HyperLink ID="HaberLink" runat="server" Height="358" Width="1024"></asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div id="orta_sol_KayanMenu_AltKisim"></div>
    <!-- Bitti -->
    <!-- Çok Satanlar Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satanlar
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="CokSatanlarTumKategoriLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="~/cep-telefonu-aksesuarlari-cok-satanlar.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Çok Satan Ürünler -->
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
                                            <asp:HyperLink ID="UrunlerLogoLink" runat="server" NavigateUrl='<%# Eval("Link") %>' ToolTip='<%# Eval("UrunAdi") %>'>
                                                <asp:Image ID="UrunlerLogoImg" runat="server" Width="157px" Height="220px" ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' />
                                            </asp:HyperLink>
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
    <!-- Kampanyalar Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Kampanyalar / İndirimdekiler
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="KampanyalarKategoriLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="~/cep-telefonu-aksesuarlari-indirim-kampanyalar.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Kampanyalar Ürünler -->
    <div class="UrunListesiDiv">
        <div class="amazingcarousel-container-0">
            <div class="amazingcarousel-0" style="display: block; position: relative; width: 100%; margin: 0px auto 0px;">
                <div class="amazingcarousel-list-container" style="overflow: hidden;">
                    <ul class="amazingcarousel-list">
                        <asp:Repeater ID="IndirimdekilerRepeater" runat="server" OnItemDataBound="IndirimdekilerRepeater_ItemDataBound">
                            <ItemTemplate>
                                <li class="amazingcarousel-item">
                                    <div class="amazingcarousel-item-container">
                                        <div class="amazingcarousel-image">
                                            <asp:HyperLink ID="UrunlerLogoLink" runat="server" NavigateUrl='<%# Eval("Link") %>' ToolTip='<%# Eval("UrunAdi") %>'>
                                                <asp:Image ID="UrunlerLogoImg" runat="server" Width="157px" Height="220px" ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' />
                                            </asp:HyperLink>
                                            <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                                                <img src="Urunler/tukendi.png" />
                                            </div>
                                            <div style="position: absolute; right: 0; top: 0;">
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
    <!-- Kılıf Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Kılıflar
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="KiliflarKategoriLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="cep-telefonu-aksesuari-kategorisi-cep-telefonu-kiliflari.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Kılıf Ürünler -->
    <div class="UrunListesiDiv">
        <asp:Repeater ID="KiliflarRepeater" runat="server" OnItemCommand="KiliflarRepeater_ItemCommand" OnItemDataBound="KiliflarRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="UrunListeItem_IlkDiv">
                    <div class="UrunListeItem_UstKisimDiv">
                        <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                            <img src="Urunler/tukendi.png" />
                        </div>
                        <div id="IndirimDiv" runat="server" visible="false" style="position: absolute; right: 0; top: 0;">
                            <img src="Urunler/Indirim.png" />
                        </div>
                    </div>
                    <div class="UrunListeItem_AltKisimDiv">
                        <div class="UrunListeItem_BaslikLbl">
                            <asp:HyperLink ID="UrunBaslikLbl" runat="server" Text='<%# Eval("UrunAdi") %>' NavigateUrl='<%# Eval("Link") %>' CssClass="UrunDetay_Link" ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        </div>
                        <div class="UrunListeItem_EskiFiyatLbl">
                            <asp:Label ID="UrunEskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                        </div>
                        <div class="UrunListeItem_YebiFiyatLbl">
                            <asp:Label ID="UrunYeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>'></asp:Label>
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
        </asp:Repeater>
    </div>
    <!-- Bitti -->
    <!-- Koruyucu Filmler Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Koruyucu Filmler
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="KoruyucuFimlerLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="cep-telefonu-aksesuari-kategorisi-ekran-koruyucu-filmler.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Koruyucu Filmler Ürünler -->
    <div class="UrunListesiDiv">
        <asp:Repeater ID="KoruyucuFilmler_Repeater" runat="server" OnItemCommand="KoruyucuFilmler_Repeater_ItemCommand" OnItemDataBound="KoruyucuFilmler_Repeater_ItemDataBound">
            <ItemTemplate>
                <div class="UrunListeItem_IlkDiv">
                    <div class="UrunListeItem_UstKisimDiv">
                        <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                            <img src="Urunler/tukendi.png" />
                        </div>
                        <div id="IndirimDiv" runat="server" visible="false" style="position: absolute; right: 0; top: 0;">
                            <img src="Urunler/Indirim.png" />
                        </div>
                    </div>
                    <div class="UrunListeItem_AltKisimDiv">
                        <div class="UrunListeItem_BaslikLbl">
                            <asp:HyperLink ID="UrunBaslikLbl" runat="server" Text='<%# Eval("UrunAdi") %>' NavigateUrl='<%# Eval("Link") %>' CssClass="UrunDetay_Link" ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        </div>
                        <div class="UrunListeItem_EskiFiyatLbl">
                            <asp:Label ID="UrunEskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                        </div>
                        <div class="UrunListeItem_YebiFiyatLbl">
                            <asp:Label ID="UrunYeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>'></asp:Label>
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
        </asp:Repeater>
    </div>
    <!-- Bitti -->
    <!-- Kulaklık Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Kulaklıklar
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="KulakliklarKategoriLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="cep-telefonu-aksesuari-kategorisi-kulakliklar.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Kulaklık Ürünler -->
    <div class="UrunListesiDiv">
        <asp:Repeater ID="KulaklikRepeater" runat="server" OnItemCommand="KulaklikRepeater_ItemCommand" OnItemDataBound="KulaklikRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="UrunListeItem_IlkDiv">
                    <div class="UrunListeItem_UstKisimDiv">
                        <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                            <img src="Urunler/tukendi.png" />
                        </div>
                        <div id="IndirimDiv" runat="server" visible="false" style="position: absolute; right: 0; top: 0;">
                            <img src="Urunler/Indirim.png" />
                        </div>
                    </div>
                    <div class="UrunListeItem_AltKisimDiv">
                        <div class="UrunListeItem_BaslikLbl">
                            <asp:HyperLink ID="UrunBaslikLbl" runat="server" Text='<%# Eval("UrunAdi") %>' NavigateUrl='<%# Eval("Link") %>' CssClass="UrunDetay_Link" ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        </div>
                        <div class="UrunListeItem_EskiFiyatLbl">
                            <asp:Label ID="UrunEskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                        </div>
                        <div class="UrunListeItem_YebiFiyatLbl">
                            <asp:Label ID="UrunYeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>'></asp:Label>
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
        </asp:Repeater>
    </div>
    <!-- Bitti -->
    <!-- Kulaklık Başlık -->
    <div class="UrunListeBaslikDiv">
        <!-- Ürün Detay Sayfası-->
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Şarj Aletleri
                </div>
            </div>
            <div class="UrunListeBaslik_SagKisimDiv">
                <div class="UrunListeBaslik_SagKisimYaziDiv">
                    <asp:HyperLink ID="SarjAletleriKategoriLink" runat="server" Text=" Tüm Ürünler" CssClass="TumUrunler_Link" NavigateUrl="cep-telefonu-aksesuari-kategorisi-sarj-aletleri.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <!-- Şarj Aletleri Ürünler -->
    <div class="UrunListesiDiv">
        <!-- Ürün Detay -->
        <asp:Repeater ID="SarjAletleriRepeater" runat="server" OnItemCommand="SarjAletleriRepeater_ItemCommand" OnItemDataBound="SarjAletleriRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="UrunListeItem_IlkDiv">
                    <div class="UrunListeItem_UstKisimDiv">
                        <asp:HyperLink ID="UrunlerLogo" runat="server" NavigateUrl='<%# Eval("Link") %>' ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        <div id="TukendiDiv" runat="server" visible="false" style="position: absolute; left: 0; bottom: 0;">
                            <img src="Urunler/tukendi.png" />
                        </div>
                        <div id="IndirimDiv" runat="server" visible="false" style="position: absolute; right: 0; top: 0;">
                            <img src="Urunler/Indirim.png" />
                        </div>
                    </div>
                    <div class="UrunListeItem_AltKisimDiv">
                        <div class="UrunListeItem_BaslikLbl">
                            <asp:HyperLink ID="UrunBaslikLbl" runat="server" Text='<%# Eval("UrunAdi") %>' NavigateUrl='<%# Eval("Link") %>' CssClass="UrunDetay_Link" ToolTip='<%# Eval("UrunAdi") %>'></asp:HyperLink>
                        </div>
                        <div class="UrunListeItem_EskiFiyatLbl">
                            <asp:Label ID="UrunEskiFiyatLbl" runat="server" Text='<%# Eval("EskiFiyat") %>'></asp:Label>
                        </div>
                        <div class="UrunListeItem_YebiFiyatLbl">
                            <asp:Label ID="UrunYeniFiyatLbl" runat="server" Text='<%# Eval("YeniFiyat") %>'></asp:Label>
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
        </asp:Repeater>
        <!-- Bitti -->
    </div>
    <!-- Bitti -->
    <div class="KampanyaEpostaListesi">
        <div class="KampanyaEpostaListesi_Sol">
            <div style="float: left; margin-right: 20px;">
                <img src="Image/Eposta_Icon.png" title="EPosta" />
            </div>
            <div class="Kampanya_Baslik">
                KAMPANYALARDAN HABERDAR OLMAK İÇİN
            </div>
            <div class="Kampanya_Aciklama">
                Kampanya takvimi ile bilgileri gönderiyoruz
            </div>
        </div>
        <div class="KampanyaEpostaListesi_Sag">
            <div class="KampanyaBoxDiv">
                <asp:TextBox ID="KamapanyaEpostaBox" runat="server" CssClass="Kampanyabox" placeholder="E-Posta Adresiniz"></asp:TextBox><asp:Button ID="KampanyaEpostaBtn" runat="server" Text="GÖNDER" CssClass="Kampanya_buttonum" OnClick="KampanyaEpostaBtn_Click" />
            </div>
        </div>
    </div>
    <div class="KampanyaEpostaListesi_AltKisim"></div>
    <script type="text/javascript">

        $(window).load(function () {
            $("#flexiselDemo1").flexisel();
        });
    </script>
    <div class="Flexi">
        <ul id="flexiselDemo1">
            <li>
                <img src="img/Telefon_Logo/Iphone.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Htc.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Samsung.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/GM.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Nokia.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Avea.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Benq.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/blackberry.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Huawei.png" />
            </li>

            <li>
                <img src="img/Telefon_Logo/LG.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Motorola.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Turkcell.png" />
            </li>
            <li>
                <img src="img/Telefon_Logo/Vodafone.png" />
            </li>
        </ul>
    </div>
</asp:Content>


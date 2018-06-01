<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UrunDetay.aspx.cs" Inherits="UrunDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <link href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet" />
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link href="colorbox/colorbox.css" rel="stylesheet" />
    <script src="colorbox/jquery.colorbox.js"></script>
    <script src="Spinner/ui.spinner.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery().ready(function ($) {
            $('#ContentPlaceHolder1_spinner').spinner({ min: 1, max: 100 });
        });
        // Tab Menu
        $(document).ready(function () {
            $("#content").find("[id^='tab']").hide(); // Hide all content
            $("#tabs li:first").attr("id", "current"); // Activate the first tab
            $("#content #tab1").fadeIn(); // Show first tab's content

            $('#tabs a').click(function (e) {
                e.preventDefault();
                if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                    return;
                }
                else {
                    $("#content").find("[id^='tab']").hide(); // Hide all content
                    $("#tabs li").attr("id", ""); //Reset id's
                    $(this).parent().attr("id", "current"); // Activate this
                    $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
                }
            });
        });
        $(document).ready(function () {
            $(".group1").colorbox({
                rel: 'group1'
            //    width: "50%",
             //   height: "50%"
                //  inline: true
            });
        });
    </script>
    <style type="text/css">
        #tabs {
            overflow: hidden;
            width: 100%;
            margin: 0;
            padding: 0;
            list-style: none;
        }

            #tabs li {
                float: left;
                margin: 0 .5em 0 0;
            }

            #tabs a {
                border: 1px solid #D4D0D0;
                position: relative;
                background: #ddd;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ddd));
                background-image: -webkit-linear-gradient(top, #fff, #ddd);
                background-image: -moz-linear-gradient(top, #fff, #ddd);
                background-image: -ms-linear-gradient(top, #fff, #ddd);
                background-image: -o-linear-gradient(top, #fff, #ddd);
                background-image: linear-gradient(to bottom, #fff, #ddd);
                padding: .7em 3.5em;
                float: left;
                text-decoration: none;
                color: #444;
                text-shadow: 0 1px 0 rgba(255,255,255,.8);
                -webkit-border-radius: 5px 0 0 0;
                -moz-border-radius: 5px 0 0 0;
                border-radius: 5px 0 0 0;
                -moz-box-shadow: 0 2px 2px rgba(0,0,0,.4);
                -webkit-box-shadow: 0 2px 2px rgba(0,0,0,.4);
                box-shadow: 0 2px 2px rgba(0,0,0,.4);
                font-weight: bold;
            }

                #tabs a:hover,
                #tabs a:hover::after,
                #tabs a:focus,
                #tabs a:focus::after {
                    background: #fff;
                }

                #tabs a:focus {
                    outline: 0;
                }

                #tabs a::after {
                    content: '';
                    position: absolute;
                    z-index: 1;
                    top: 0;
                    right: -.5em;
                    bottom: 0;
                    width: 1em;
                    background: #ddd;
                    background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ddd));
                    background-image: -webkit-linear-gradient(top, #fff, #ddd);
                    background-image: -moz-linear-gradient(top, #fff, #ddd);
                    background-image: -ms-linear-gradient(top, #fff, #ddd);
                    background-image: -o-linear-gradient(top, #fff, #ddd);
                    background-image: linear-gradient(to bottom, #fff, #ddd);
                    -moz-box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    -webkit-box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    -webkit-transform: skew(10deg);
                    -moz-transform: skew(10deg);
                    -ms-transform: skew(10deg);
                    -o-transform: skew(10deg);
                    transform: skew(10deg);
                    -webkit-border-radius: 0 5px 0 0;
                    -moz-border-radius: 0 5px 0 0;
                    border-radius: 0 5px 0 0;
                }

            #tabs #current a {
                background: #fff;
                z-index: 3;
            }

                #tabs #current a::after {
                    background: #fff;
                    z-index: 3;
                }

        #content {
            background: #fff;
            padding: 2em;
            position: relative;
            z-index: 2;
            -moz-border-radius: 0 5px 5px 5px;
            -webkit-border-radius: 0 5px 5px 5px;
            border-radius: 0 5px 5px 5px;
            -moz-box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            -webkit-box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            float: left;
            border: 1px solid #D4D0D0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
    </div>
    <div class="OrtaBolum">
        <div class="UrunDetay_ResimlerDiv">
            <div id="AnaResimDiv" style="border: 1px solid #F2F1F1;">
                <asp:Image ID="AnaResim" runat="server" Width="410px" Height="525px"
                    ImageUrl="~/Urunler/Resimler/resim_yok.png" />
            </div>
            <div id="AltResimlerDiv" style="float: left; width: 420px; margin-top: 10px; height: auto;">
                <asp:Repeater ID="ResimlerRepeater" runat="server">
                    <ItemTemplate>
                        <div id="ResimBoyutlariDiv" style="padding: 2px; width: 100px; height: 75px; float: left;">
                            <a href='<%# Eval("ResimAd","Urunler/Resimler/{0}") %>' class="group1">
                                <asp:Image ID="TedLogo" runat="server" Height="75px" Width="100px" ImageUrl='<%# Eval("ResimAd","Urunler/Resimler/{0}") %>' /></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="UrunDetay_AyrintilarDiv">
            <div class="UrunDetay_LinkHaritasi_Sossial">
                <div class="UrunDetay_LinkHaritasi">
                    <asp:HyperLink ID="KategoriLink" runat="server" CssClass="LinkHaritasi">[KategoriLink]</asp:HyperLink>
                    <span class="LinkHaritasi_Ayrac">> </span>
                    <asp:HyperLink ID="TelefonMarkaLink" runat="server" CssClass="LinkHaritasi">[TelefonMarkaLink]</asp:HyperLink>
                    <span class="LinkHaritasi_Ayrac">> </span>
                    <asp:HyperLink ID="TelefonModelLink" runat="server" CssClass="LinkHaritasi">[TelefonModelLink]</asp:HyperLink>
                </div>
                <div class="UrunDetay_Sossial">
                    <!-- AddThis Button BEGIN -->
                    <div class="addthis_toolbox addthis_default_style ">
                        <a class="addthis_button_preferred_1"></a>
                        <a class="addthis_button_preferred_2"></a>
                        <a class="addthis_button_preferred_3"></a>
                        <a class="addthis_button_preferred_4"></a>
                        <a class="addthis_button_compact"></a>
                        <a class="addthis_counter addthis_bubble_style"></a>
                    </div>
                    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=fcetinkaya"></script>
                    <!-- AddThis Button END -->
                </div>
            </div>
            <div class="UrunDetay_UrunAdi">
                <asp:Label ID="UrunAdiLbl" runat="server"></asp:Label>
            </div>
            <div id="Detay_Div" runat="server">
                <div id="FiyatDiv" class="UrunDetay_Fiyat">
                    <div class="UrunDetay_Fiyat_EskiFiyatLbl">
                        <asp:Label ID="EskiFiyatLbl" runat="server"></asp:Label>
                        TL
                    </div>
                    <div class="UrunDetay_Fiyat_YeniFiyatLbl">
                        <asp:Label ID="YeniFiyatLbl" runat="server"></asp:Label>
                        TL
                    </div>
                </div>
                <div id="KDVDahilDiv" class="UrunDetay_Fiyat">
                    <div class="UrunDetay_Fiyat_YeniFiyatLbl">
                        KDV Dahil :
                    </div>
                    <div class="UrunDetay_Fiyat_YeniFiyatLbl">
                        <asp:Label ID="KDVDahilLBl" runat="server"></asp:Label>
                        TL
                    </div>
                </div>
                <div id="HavaleIleDiv" class="UrunDetay_Fiyat">
                    <div class="UrunDetay_Fiyat_YeniFiyatLbl">
                        Havale İle :
                    </div>
                    <div class="UrunDetay_Fiyat_YeniFiyatLbl">
                        <asp:Label ID="HavaleLbl" runat="server"></asp:Label>
                        TL
                    </div>
                </div>
                <div class="UrunDetay_SepetEkle">
                    <div class="UrunDetay_SepetEkle_SayiArttir">
                        <input type="text" id="spinner" runat="server" size="5" value="1" />
                    </div>
                    <div class="UrunDetay_SepetEkle_EkleBtn">
                        <asp:Button ID="SepetEkleBtn" runat="server" CssClass="Sepet_buttonum" Text="Sepete Ekle" OnClick="SepetEkleBtn_Click" />
                    </div>
                </div>
                <div class="UrunDetay_RenkSecenekleriDiv">
                    <div class="UrunDetay_UrunAdi">
                        RENK SEÇENEKLERİ
                    </div>
                    <asp:Repeater ID="RenkSecenekleriRepeater" runat="server">
                        <ItemTemplate>
                            <div id="RepetearItemDiv" style="float: left; height: 61px; width: 530px; text-align: left; padding: 5px;">
                                <div id="ResimDiv" style="float: left; height: 50px; width: 30px; padding: 4px; border: 1px solid #D4D0D0;">
                                    <asp:HyperLink ID="Resim" runat="server" NavigateUrl='<%# Eval("Link") %>'>
                                <img src='<%# Eval("Logo","Urunler/Logo/{0}") %>' alt='<%# Eval("UrunAdi") %>' height="50" width="30" />
                                    </asp:HyperLink>
                                </div>
                                <div id="AdiDiv" style="float: left; height: 30px; width: 480px; padding: 15px 5px;">
                                    <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("Link") %>' Text='<%# Eval("UrunAdi") %>' ToolTip='<%# Eval("UrunAdi") %>' CssClass="Footer_Link"></asp:HyperLink>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div id="Tukendi_Div" runat="server" visible="false" style="float: left;">
                <img src="Image/Tukendi.PNG" alt="Tükendi" />

                <div id="UyariDiv" class="uyari" runat="server" visible="false" style="float: left; width: 500px;">
                    <span>Uyarı</span><br />
                    Ürünler tedarik ediliyor.<br />
                    Lütfen daha sonra tekrar ziyaret ediniz. Anlayışınız
                için teşekkürler.
            <br />
                    <br />
                    <div class="Uyari_BoxDiv">
                        <asp:TextBox ID="HaberdarEtEpostaBox" runat="server" CssClass="Kampanyabox" placeholder="E-Posta Adresiniz"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="KampanyaEpostaBtn" runat="server" Text="ÜRÜN EKLENDİĞİNDE BENİ HABERDAR ET" CssClass="Kampanya_buttonum" OnClick="KampanyaEpostaBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="UrunDetay_Ayrintilar_Aciklama">
            <ul id="tabs">
                <li><a href="#" name="tab1">Ürün Açıklamaları</a></li>
                <li id="Taksit_Secenek" runat="server"><a href="#" name="tab2">Taksit Seçenekleri</a></li>
            </ul>
            <div id="content">
                <div id="tab1" style="float: left; width: 980px; padding-bottom: 70px; height: 100%;">
                    <h2>Ürün Açıklaması</h2>
                    <p>
                        <asp:Literal ID="AciklamaLitearal" runat="server"></asp:Literal>
                    </p>
                </div>
                <div id="tab2" style="float: left; width: 980px; padding-bottom: 70px; height: 100%;">
                    <asp:Repeater ID="OdemeSecenekleriRepeater" runat="server" OnItemDataBound="OdemeSecenekleriRepeater_ItemDataBound">
                        <ItemTemplate>
                            <div id="RepetearItemDiv" style="float: left; height: 300px; width: 220px; text-align: center; font-size: 12px; margin: 5px;">
                                <div id="LogoDiv" style="float: left; height: 35px; width: 220px;">
                                    <img src='<%# Eval("BankaLogo","img/Banka/{0}") %>' alt='<%# Eval("BankaAdi") %>' height="35" width="220" />
                                </div>
                                <div id="BaslikDiv" style="float: left; height: 20px; width: 220px; margin-top: 5px;">
                                    <div style="float: left; height: 20px; width: 70px;">
                                        Taksit Sayısı
                                    </div>
                                    <div style="float: left; height: 20px; width: 75px;">
                                        Taksit Tutar
                                    </div>
                                    <div style="float: left; height: 20px; width: 75px;">
                                        Toplam Tutar
                                    </div>
                                </div>
                                <div id="DevamRepeaderDiv" style="float: left; height: 20px; width: 220px; margin-top: 5px;">
                                    <asp:Repeater ID="TaksitSayisiRepeater" runat="server">
                                        <ItemTemplate>
                                            <div style="float: left; height: 20px; width: 70px;">
                                                <asp:Label ID="TaksitSayisiLBl" runat="server" Text='<%# Eval("TaksitSayisi") %>'></asp:Label>
                                            </div>
                                            <div style="float: left; height: 20px; width: 75px;">
                                                <asp:Label ID="TaksitTutariLbl" runat="server" Text='<%# Eval("TaksitTutari") %>'></asp:Label>
                                            </div>
                                            <div style="float: left; height: 20px; width: 75px;">
                                                <asp:Label ID="ToplamTutariLbl" runat="server" Text='<%# Eval("ToplamTutar") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


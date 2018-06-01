<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Yonetim.aspx.cs" Inherits="Yonetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="main" class="column">
        <h4 class="alert_info">E-Ticaret yönetim paneline hoş geldiniz.</h4>
        <h4 id="YeniMesaj_alert" runat="server" class="alert_info" visible="false" style="width: 21%; float: left; margin-right: 0px;">
            <asp:HyperLink ID="MesajAdetiLbl" runat="server" NavigateUrl="~/Rumrum/IletisimMesajlari.aspx"></asp:HyperLink>
        </h4>
        <h4 id="AramaTalebi_Alert" runat="server" class="alert_info" visible="false" style="width: 21%; float: left; margin-left: 1%; margin-right: 0px;">
            <asp:HyperLink ID="BeniAraAdetLbl" runat="server" NavigateUrl="~/Rumrum/IletisimMesajlari.aspx"></asp:HyperLink>
        </h4>
        <h4 id="UrunTalep_Alet" runat="server" class="alert_info" visible="false" style="width: 21%; float: left; margin-left: 1%;">
            <asp:HyperLink ID="UrunTalepAdetLbl" runat="server" NavigateUrl="~/Rumrum/UrunTalepleri.aspx"></asp:HyperLink>
        </h4>
        <div class="clear"></div>
        <article id="BekleyenSiparis_Article" class="module width_quarter_II">
            <header>
                <h3>Yeni Siparişler</h3>
            </header>
            <div class="message_list">
                <div class="module_content">
                    <asp:Repeater ID="YeniSiparisler" runat="server">
                        <ItemTemplate>
                            <div class="message">
                                <p>
                                    <strong>Ödeme Türü :</strong>
                                    <%# Eval("OdemeTipi") %>
                                    <br />
                                    <strong>Sipariş No / Tutarı :</strong>
                                    <%# Eval("SiparisNoFiyat") %>
                                    <br />
                                    <strong>Tarih :</strong>
                                    <%# Eval("SiparisTarihi") %>
                                    <p style="text-align: right;">
                                        <asp:HyperLink ID="Siparis_DetayBtn" runat="server" CssClass="alt_btn" Text="Devamı >>" NavigateUrl="~/Rumrum/BekleyenSiparisler.aspx" ></asp:HyperLink>
                                    </p>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <h4 id="YeniSiparisYok_Div" runat="server" class="alert_warning" visible="false">Yeni Sipariş Bulunamadı !</h4>
                </div>
            </div>
        </article>
        <article id="OdemeBildirimler_article" class="module width_quarter_II">
            <header>
                <h3>ödeme bildirimleri</h3>
            </header>
            <div class="message_list">
                <div class="module_content">
                    <asp:Repeater ID="OdemeBildirim_Repeater" runat="server" OnItemDataBound="OdemeBildirim_Repeater_ItemDataBound">
                        <ItemTemplate>
                            <div class="message">
                                <p>
                                    <strong>Üye Ad Soyad :</strong>
                                    <asp:Label ID="AdSoyadLbl" runat="server" Text='<%# Eval("AdSoyad") %>'></asp:Label>
                                    <br />
                                    <strong>Sipariş No / Tutarı :</strong>
                                    <%# Eval("SiparisNoFiyat") %>
                                    <br />
                                    <strong>Tarih :</strong>
                                    <%# Eval("Tarih") %>
                                    <p style="text-align: right;">
                                        <asp:Button ID="Odeme_DetayBtn" runat="server" CssClass="alt_btn" Text="Devamı >>"></asp:Button>
                                    </p>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <h4 id="Odeme_Yok_Div" runat="server" class="alert_warning" visible="false">Yeni Ödeme Bildirimi Bulunamadı !</h4>
                </div>
            </div>
        </article>
        <article id="IadeDegisim_Article" class="module width_quarter_II">
            <header>
                <h3>İade / Değişim Bildirimleri</h3>
            </header>
            <div class="message_list">
                <div class="module_content">
                    <asp:Repeater ID="IadeDegisim_Repeater" runat="server" OnItemDataBound="IadeDegisim_Repeater_ItemDataBound">
                        <ItemTemplate>
                            <div class="message">
                                <p>
                                    <strong>İade Nedeni :</strong>
                                    <%# Eval("IadeNedeni") %>
                                    <br />
                                    <strong>Sipariş No / Tutarı :</strong>
                                    <%# Eval("SiparisNoFiyat") %>
                                    <br />
                                    <strong>Tarih :</strong>
                                    <%# Eval("Tarih") %>
                                    <p style="text-align: right;">
                                        <asp:Button ID="Iade_DetayBtn" runat="server" CssClass="alt_btn" Text="Devamı >>"></asp:Button>
                                    </p>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <h4 id="IadeDegisimYok" runat="server" class="alert_warning" visible="false">Yeni İade / Değişim Bildirimi Bulunamadı !</h4>
                </div>
            </div>
        </article>
        <article id="UyeIstatistik_Article" class="module width_quarter_II">
            <header>
                <h3>Üye İstatistikleri</h3>
            </header>
            <div id="BugunUyeOlan" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bugün</p>
                            <p class="overview_count">
                                <asp:Label ID="BugunUyeLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Üye Olan</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="BuAyUyeOlan" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Ay</p>
                            <p class="overview_count">
                                <asp:Label ID="BuAyUyeLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Üye Olan</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="BuYilUyeOlan" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Yıl</p>
                            <p class="overview_count">
                                <asp:Label ID="BuYilUyeLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Üye Olan</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="ToplamUyeOlan" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Toplam</p>
                            <p class="overview_count">
                                <asp:Label ID="ToplamUyeLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Üye Olan</p>
                        </div>
                    </div>
                </article>
            </div>
        </article>
        <article id="SiparisIstatistikleri" class="module width_quarter_II">
            <header>
                <h3>sipariş İstatistikleri</h3>
            </header>
            <div id="BugunSiparis" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bugün</p>
                            <p class="overview_count">
                                <asp:Label ID="BugunSiparisLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Sipariş</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="BuAysiparis" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Ay</p>
                            <p class="overview_count">
                                <asp:Label ID="BuAySiparisLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Sipariş</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="BuYilSiparis" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Yıl</p>
                            <p class="overview_count">
                                <asp:Label ID="BuYilSiparisLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Sipariş</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="ToplamSiparis" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Toplam</p>
                            <p class="overview_count">
                                <asp:Label ID="ToplamSiparislbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">Sipariş</p>
                        </div>
                    </div>
                </article>
            </div>
        </article>
        <article id="Hasilat_Istatistikleri" class="module width_quarter_II">
            <header>
                <h3>hasılat İstatistikleri</h3>
            </header>
            <div id="bugunhasilat" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bugün</p>
                            <p class="overview_count">
                                <asp:Label ID="BugunHasilatlbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">hasılatı</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="buayhasilat" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Ay</p>
                            <p class="overview_count">
                                <asp:Label ID="BuAyHasilatLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">hasılatı</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="buyilhasilat" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Bu Yıl</p>
                            <p class="overview_count">
                                <asp:Label ID="BuYilHasilatlbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">hasılatı</p>
                        </div>
                    </div>
                </article>
            </div>
            <div id="toplamhasilat" class="module_content">
                <article class="stats_overview">
                    <div class="message">
                        <div class="overview_today">
                            <p class="overview_day">Toplam</p>
                            <p class="overview_count">
                                <asp:Label ID="ToplamHasilatLbl" runat="server"></asp:Label>
                            </p>
                            <p class="overview_type">hasılatı</p>
                        </div>
                    </div>
                </article>
            </div>
        </article>
        <div class="spacer"></div>
    </section>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KategoriListe_Alt.aspx.cs" Inherits="KategoriListe_Alt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="NivoSlide/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="carouselengine/amazingcarousel.js" type="text/javascript"></script>
    <script src="carouselengine/initcarousel-0.js" type="text/javascript"></script>
    <link href="carouselengine/initcarousel-0.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Çok Satanlar Kılıf-->
    <div class="UrunListeBaslikDiv">
        <div class="UrunListeBaslik_OrtaCizgiDiv">
            <div class="UrunListeBaslik_SolKisimDiv">
                <div class="UrunListeBaslik_SolKisimYaziDiv">
                    Çok Satan
                    <asp:Label ID="CokSatanLbl" runat="server"></asp:Label>
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
    <asp:UpdatePanel ID="Kategori_Update" runat="server">
        <ContentTemplate>
            <div class="KategoriFilter_Sol">
                <asp:DropDownList ID="TelefonDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="170px" AppendDataBoundItems="true" OnSelectedIndexChanged="TelefonDrop_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ModelDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="170px" AppendDataBoundItems="true" OnSelectedIndexChanged="ModelDrop_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="KategoriFilter_Sag">
                <asp:DropDownList ID="AlfabetikDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="AlfabetikDrop_SelectedIndexChanged">
                    <asp:ListItem Value="0">Alfabetik Sırala</asp:ListItem>
                    <asp:ListItem Value="1">A'dan Z'ye</asp:ListItem>
                    <asp:ListItem Value="2">Z'den A'ya</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="FiyatDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" Width="170px" OnSelectedIndexChanged="FiyatDrop_SelectedIndexChanged">
                    <asp:ListItem Value="0">Fiyata Göre Sırala</asp:ListItem>
                    <asp:ListItem Value="1">Artan Fiyat</asp:ListItem>
                    <asp:ListItem Value="2">Azalan Fiyat</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="UrunListeBaslikDiv">
                <div class="UrunListeBaslik_OrtaCizgiDiv">
                    <div class="UrunListeBaslik_SolKisimDiv">
                        <div class="UrunListeBaslik_SolKisimYaziDiv">
                            <asp:Label ID="KategoriAdiLbl" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="UrunListeBaslik_SagKisimDiv">
                        <div class="UrunListeBaslik_SagKisimYaziDiv">
                        </div>
                    </div>
                </div>
            </div>
            <div class="UrunListesiDiv">
                <asp:DataList ID="KategoriRepeater" runat="server" OnItemCommand="KategoriRepeater_ItemCommand" RepeatDirection="Horizontal" Width="980px" RepeatColumns="4" OnItemDataBound="KategoriRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="Kategori_UrunListeItem_IlkDiv">
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
                Ürünler tedarik ediliyor.<br />
                Lütfen daha sonra tekrar ziyaret ediniz. Anlayışınız
                için teşekkürler.
            <br />
                <br />
                <div class="Uyari_BoxDiv">
                    <asp:TextBox ID="HaberdarEtEpostaBox" runat="server" CssClass="Kampanyabox" placeholder="E-Posta Adresiniz"></asp:TextBox><asp:Button ID="KampanyaEpostaBtn" runat="server" Text="ÜRÜN EKLENDİĞİNDE BENİ HABERDAR ET" CssClass="Kampanya_buttonum" OnClick="KampanyaEpostaBtn_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunListesi.aspx.cs" Inherits="Rumrum_UrunListesi" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function OnClientPopulating(sender, e) {
            sender._element.className = "loading";
        }
        function OnClientCompleted(sender, e) {
            sender._element.className = "";
        }
    </script>
    <script type="text/javascript">
        function DivKapat() {
            document.getElementById('AramaPopup').style.display = 'none';
            return false;
        }
        function DivAc() {
            document.getElementById('AramaPopup').style.display = 'block';
            return false;
        }
    </script>
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        /*Auto Complete*/
        .AutoExtender {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left: 10px;
        }

        .AutoExtenderList {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }

        .AutoExtenderHighlight {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }

        #divwidth {
            width: 350px !important;
        }

            #divwidth div {
                width: 350px !important;
            }

        .loading {
            background-image: url(images/loader.gif);
            background-position: right;
            background-repeat: no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section id="main" class="column">
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <article class="module width_full">
                    <header>
                        <h3>kayıtlı ürünler listesi</h3>
                    </header>
                    <div class="module_content">
                        <div id="AramaKriter_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="DivAc()">Filtreleme</a>
                        </div>
                        <div id="AramaPopup" class="AramaKriteri">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset style="width: 99%; float: left;">
                                    <label class="labelfiel">
                                        ürün adı</label>
                                    <asp:TextBox ID="UrunAdiBox" runat="server" CssClass="textfield" Width="470px"></asp:TextBox>
                                    <div id="divwidth"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                                        runat="server" ServiceMethod="SearchCustomers"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="UrunAdiBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                                <fieldset style="width: 49%; float: left;">
                                    <label class="labelfiel">
                                        ana kategori</label>
                                    <asp:DropDownList ID="AnaKategoriDrop" runat="server" CssClass="select" OnSelectedIndexChanged="AnaKategoriDrop_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                </fieldset>
                                <fieldset style="width: 49%; margin-left: 1%; float: left;">
                                    <label class="labelfiel">
                                        Alt kategori</label>
                                    <asp:DropDownList ID="AltKategoriDrop" runat="server" CssClass="select" Enabled="false"></asp:DropDownList>

                                </fieldset>
                                <fieldset style="width: 49%; float: left;">
                                    <label class="labelfiel">
                                        Telefon</label>
                                    <asp:DropDownList ID="TelefonDrop" runat="server" AppendDataBoundItems="true" CssClass="select" OnSelectedIndexChanged="TelefonDrop_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </fieldset>
                                <fieldset style="width: 49%; margin-left: 1%; float: left;">
                                    <label class="labelfiel">
                                        Model</label>
                                    <asp:DropDownList ID="ModelDrop" runat="server" AppendDataBoundItems="true" CssClass="select" Enabled="false"></asp:DropDownList>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 960px" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 180px;">ÜRÜN ADI
                                </td>
                                <td style="width: 95px;">KATEGORİ ADI
                                </td>
                                <td style="width: 95px;">TELEFON ADI
                                </td>
                                <td style="width: 95px;">MODEL ADI
                                </td>
                                <td style="width: 15px;">T
                                </td>
                                <td style="width: 15px;">İ
                                </td>
                                <td style="width: 80px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:GridView ID="Urunler_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" OnPageIndexChanging="Urunler_Grid_PageIndexChanging" DataKeyNames="UrunID" CssClass="Gridview" ShowHeader="false" OnRowDataBound="Urunler_Grid_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="285px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUrunAdi" runat="server"
                                                        Text='<%# Eval("UrunAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKategoriAdi" runat="server"
                                                        Text='<%# Eval("KategoriAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTlf" runat="server"
                                                        Text='<%# Eval("TelefonAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModelAdi" runat="server"
                                                        Text='<%# Eval("ModelAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTiklamaAdi" runat="server"
                                                        Text='<%# Eval("Tiklama")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIndirimAdi" runat="server"
                                                        Text='<%# Eval("Indirim")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                        ToolTip="Düzenle">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="DeleteBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                        ToolTip="Sil">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="KopyalaBtn" runat="server" ImageUrl="~/Rumrum/images/icn_copy.png"
                                                        ToolTip="Kopyala">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="ResimlerBtn" runat="server" ImageUrl="~/Rumrum/images/icn_photo.png"
                                                        ToolTip="Ürün Resimleri">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="DetayBtn" CssClass="Detay" runat="server" ImageUrl="~/Rumrum/images/icn_info.png"
                                                        ToolTip="Ürün Detayı" NavigateUrl="#">
                                                    </asp:HyperLink>
                                                    <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="DetayBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                                                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                                                        <div class="header">
                                                            Ürün Detayı
                                                        </div>
                                                        <div class="body">
                                                            <div id="AnaDiv" style="width: 750px; height: 225px; float: left;">
                                                                <div id="Logodiv" style="width: 210px; height: 220px; float: left;">
                                                                    <asp:Image ID="UrunlerLogoImg" runat="server" Width="210px" Height="210px" ImageUrl='<%# Eval("Logo","~/Urunler/Logo/{0}") %>' />

                                                                </div>
                                                                <div id="BilgilerDiv" style="width: 530px; height: 220px; float: left; margin-left: 10px;">
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Ürün Adı</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("UrunAdi")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Eski Fiyatı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("EskiFiyat")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Yeni Fiyatı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("YeniFiyat")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Kategori Adı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("KategoriAdi")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Telefon Adı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("TelefonAdi")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Model Adı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("ModelAdi")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>İndirim Var Mı ?</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <asp:Label ID="IndirimVarmiLbl" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>İndirim Oranı :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("Indirim")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Görüntüleme Adeti :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <%# Eval("Tiklama")%>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Stok Durumu :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <asp:Label ID="TukendimiLbl" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div style="width: 130px; height: 20px; float: left;">
                                                                        <b>Satış Durumu :</b>
                                                                    </div>
                                                                    <div style="width: 400px; height: 20px; float: left;">
                                                                        <asp:Label ID="SatisDurumuLbl" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                                                        </div>
                                                    </asp:Panel>

                                                    <asp:HyperLink ID="WebBtn" runat="server" ImageUrl="~/Rumrum/images/icn_web.png"
                                                        ToolTip="Ürün Sayfası Görüntüleme" Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Alt_GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Ürün Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>

                    </div>
                </article>
                <br />
                <br />
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


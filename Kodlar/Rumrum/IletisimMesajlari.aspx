<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="IletisimMesajlari.aspx.cs" Inherits="Rumrum_IletisimMesajlari" %>

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
        function Ara_DivKapat() {
            document.getElementById('Ara_AramaPopup').style.display = 'none';
            return false;
        }
        function Ara_DivAc() {
            document.getElementById('Ara_AramaPopup').style.display = 'block';
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

        #divwidth_Ara {
            width: 350px !important;
        }

            #divwidth_Ara div {
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
    <section id="main" class="column">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h4 id="KayitTamam" runat="server" class="alert_success" visible="false">
                    <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
                </h4>
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label></h4>
                <article class="module width_full">
                    <header>
                        <h3>iletişim mesajları</h3>
                    </header>
                    <div class="module_content">
                        <div id="AramaKriter_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="DivAc()">Filtreleme</a>
                        </div>
                        <div id="AramaPopup" class="AramaKriteri_Small">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset>
                                    <label class="labelfiel">
                                        Ad Soyad</label>
                                    <asp:TextBox ID="Iletisim_AdSoyad_Box" runat="server" CssClass="textfield" Width="470px"></asp:TextBox>
                                    <div id="divwidth"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                                        runat="server" ServiceMethod="SearchCustomers"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="Iletisim_AdSoyad_Box"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right; font-size: 13px;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 953px" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 180px;">AD SOYAD
                                </td>
                                <td style="width: 105px;">KONU
                                </td>
                                <td style="width: 105px;">E-POSTA ADRESİ
                                </td>
                                <td style="width: 90px;">TARİH
                                </td>
                                <td style="width: 75px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="Iletisim_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" ShowHeader="false" CssClass="Gridview" OnPageIndexChanging="Iletisim_Grid_PageIndexChanging" OnRowCommand="Iletisim_Grid_RowCommand" OnRowDataBound="Iletisim_Grid_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="295px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMusteriAdi" runat="server"
                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="165px">
                                                <ItemTemplate>
                                                    <%# Eval("Konu")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="165px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMusteriEposta" runat="server" Text='<%# Eval("EpostaBox")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <%# Eval("Tarih")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="115px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="KapatBtn" runat="server" Text="Bildirimi Kapat"
                                                        ToolTip="Bildirimi Kapat" CommandArgument='<%# Eval("E_Iletisim_BildirimID")%>' CommandName="Kapat">
                                                    </asp:LinkButton>
                                                    <asp:ConfirmButtonExtender
                                                        ID="ConfirmButtonExtender1" runat="server" TargetControlID="KapatBtn" ConfirmText="Bildirimi kapatmak istediğinize emin misiniz ?">
                                                    </asp:ConfirmButtonExtender>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:HyperLink ID="DetayBtn" CssClass="Detay" runat="server" ImageUrl="~/Rumrum/images/icn_info.png"
                                                        ToolTip="Detay" NavigateUrl="#">
                                                    </asp:HyperLink>
                                                    <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="DetayBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                                                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                                                        <div class="header">
                                                            Mesaj Detayı
                                                        </div>
                                                        <div class="body">
                                                            <div id="BilgilerDiv" style="width: 330px; height: 320px; float: left; margin-left: 10px;">
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>Ad Soyad :</b>
                                                                </div>
                                                                <div style="width: 200px; height: 20px; float: left;">
                                                                    <asp:Label ID="lblMusteriAdi_detay" runat="server"
                                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                                </div>
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>E-Posta Adresi</b>
                                                                </div>
                                                                <div style="width: 200px; height: 20px; float: left;">
                                                                    <asp:Label ID="lblMusteriEposta_Detay" runat="server"
                                                                        Text='<%# Eval("EpostaBox")%>'></asp:Label>
                                                                </div>
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>Cep Telefonu :</b>
                                                                </div>
                                                                <div style="width: 200px; height: 20px; float: left;">
                                                                    <asp:Label ID="lblCepTlf" runat="server"
                                                                        Text='<%# Eval("CepTlf")%>'></asp:Label>
                                                                </div>
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>Tarih :</b>
                                                                </div>
                                                                <div style="width: 200px; height: 20px; float: left;">
                                                                    <%# Eval("Tarih")%>
                                                                </div>
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>Konu :</b>
                                                                </div>
                                                                <div style="width: 200px; height: 20px; float: left;">
                                                                    <%# Eval("Konu")%>
                                                                </div>
                                                                <div style="width: 130px; height: 20px; float: left;">
                                                                    <b>Açıklama :</b>
                                                                </div>
                                                                <div style="width: 200px; height: 100px; float: left;">
                                                                    <%# Eval("Aciklama")%>
                                                                </div>
                                                            </div>
                                                            <div class="footer" align="right">
                                                                <asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Iletisim_Grid_KayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı İletişim Mesajı Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
                <div class="clear"></div>
                <article class="module width_full">
                    <header>
                        <h3>Ara beni mesajları</h3>
                    </header>
                    <div class="module_content">
                        <div id="AraBeni_AramaKriterleri_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="Ara_DivAc()">Filtreleme</a>
                        </div>
                        <div id="Ara_AramaPopup" class="AramaKriteri_Small">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset>
                                    <label class="labelfiel">
                                        Ad Soyad</label>
                                    <asp:TextBox ID="AraBeni_AdSoyad_Box" runat="server" CssClass="textfield" Width="470px"></asp:TextBox>
                                    <div id="divwidth_Ara"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2"
                                        runat="server" ServiceMethod="SearchCustomers_Ara"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="AraBeni_AdSoyad_Box"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth_Ara" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AraBeni_AramaBaslatBtn_Click" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AraBeni_AramaBaslatBtn_Click_Click" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right; font-size: 13px;">
                                    <a href="#" class="AramaKriteri_button" onclick="Ara_DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 953px" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 225px;">AD SOYAD
                                </td>
                                <td style="width: 150px;">E-POSTA
                                </td>
                                <td style="width: 105px;">TARİH
                                </td>
                                <td style="width: 75px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="AraBeni_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" ShowHeader="false" CssClass="Gridview" OnPageIndexChanging="AraBeni_Grid_PageIndexChanging" OnRowCommand="AraBeni_Grid_RowCommand" OnRowDataBound="AraBeni_Grid_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="370px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMusteriAdi" runat="server"
                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="245px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMustericep" runat="server" Text='<%# Eval("CepTelefonu")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="165px">
                                                <ItemTemplate>
                                                    <%# Eval("Tarih")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="115px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="KapatBtn" runat="server" Text="Bildirimi Kapat"
                                                        ToolTip="Bildirimi Kapat" CommandArgument='<%# Eval("E_AraBeni_BildirimID")%>' CommandName="Kapat">
                                                    </asp:LinkButton>
                                                    <asp:ConfirmButtonExtender
                                                        ID="ConfirmButtonExtender1" runat="server" TargetControlID="KapatBtn" ConfirmText="Bildirimi kapatmak istediğinize emin misiniz ?">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="AraBeni_Grid_KayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Ara Beni Mesajı Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>


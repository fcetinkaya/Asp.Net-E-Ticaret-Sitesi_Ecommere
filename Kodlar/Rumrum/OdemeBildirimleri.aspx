<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="OdemeBildirimleri.aspx.cs" Inherits="Rumrum_OdemeBildirimleri" %>

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
    <section id="main" class="column">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h4 id="KayitTamam" runat="server" class="alert_success" visible="false">
                    <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
                </h4>
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <article class="module width_full">
                    <header>
                        <h3>Sipariş ödeme bildirimleri</h3>
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
                                <fieldset style="width: 49%; float: left;">
                                    <label class="labelfiel">
                                        Müşteri Adı Soyadı</label>
                                    <asp:TextBox ID="MusteriBox" runat="server" CssClass="textfield" Width="300px"></asp:TextBox>
                                    <div id="divwidth"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                                        runat="server" ServiceMethod="SearchCustomers"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="MusteriBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                                <fieldset style="width: 49%; float: left; margin-left: 1px;">
                                    <label class="labelfiel">
                                        Banka</label>
                                    <asp:DropDownList ID="BankaDrop" runat="server" CssClass="select"></asp:DropDownList>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 25%; float: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" />
                                </div>
                                <div style="width: 25%; float: left; font-size: 13px; text-align:right;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 953px;" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 180px;">MÜŞTERİ AD SOYAD
                                </td>
                                <td style="width: 105px;">BANKA
                                </td>
                                <td style="width: 105px;">SİPARİŞ NO / FİYAT
                                </td>
                                <td style="width: 90px;">TARİH
                                </td>
                                <td style="width: 75px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="AltKategori_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" ShowHeader="false" CssClass="Gridview" OnPageIndexChanging="AltKategori_Grid_PageIndexChanging" OnRowDataBound="AltKategori_Grid_RowDataBound" OnRowCommand="AltKategori_Grid_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="290px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMusteriAdi" runat="server"
                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="165px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKategoriAdi" runat="server"
                                                        Text='<%# Eval("BankaAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="165px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTlf" runat="server"
                                                        Text='<%# Eval("SiparisNoFiyat")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModelAdi" runat="server"
                                                        Text='<%# Eval("Tarih")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="115px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="KapatBtn" runat="server" Text="Bildirimi Kapat"
                                                        ToolTip="Bildirimi Kapat" CommandArgument='<%# Eval("Odeme_BildirimID")%>' CommandName="Kapat">
                                                    </asp:LinkButton>
                                                       <asp:LinkButton ID="AcBtn" runat="server" Text="Bildirimi Aç"
                                                        ToolTip="Bildirimi Aç" CommandArgument='<%# Eval("Odeme_BildirimID")%>' CommandName="Ac">
                                                    </asp:LinkButton>
                                                    <asp:ConfirmButtonExtender
                                                        ID="ConfirmButtonExtender1" runat="server" TargetControlID="KapatBtn" ConfirmText="Bildirimi kapatmak istediğinize emin misiniz ?">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Alt_GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Ödeme Bildirimi Bulunamadı !</h4>
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


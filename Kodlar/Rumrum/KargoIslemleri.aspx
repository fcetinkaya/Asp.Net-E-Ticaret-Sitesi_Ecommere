<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="KargoIslemleri.aspx.cs" Inherits="Rumrum_KargoIslemleri" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <script type="text/javascript">
        function OnClientPopulating(sender, e) {
            sender._element.className = "loading";
        }
        function OnClientCompleted(sender, e) {
            sender._element.className = "";
        }
    </script>
    <style type="text/css">
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

        #divwidth2 {
            width: 350px !important;
        }

            #divwidth2 div {
                width: 350px !important;
            }

        #divwidth3 {
            width: 350px !important;
        }

            #divwidth3 div {
                width: 350px !important;
            }

        #divwidth4 {
            width: 350px !important;
        }

            #divwidth4 div {
                width: 350px !important;
            }

        #divwidth5 {
            width: 350px !important;
        }

            #divwidth5 div {
                width: 350px !important;
            }

        #divwidth6 {
            width: 350px !important;
        }

            #divwidth6 div {
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
                        <h3>yeni kargo kayıt işlemi</h3>
                    </header>
                    <div class="module_content" style="height: 220px;">
                        <fieldset style="width: 48%; float: left;">
                            <label class="labelfiel">
                                kargo firması</label>
                            <asp:DropDownList ID="KargoDrop" runat="server" CssClass="select">
                                <asp:ListItem Value="0">Lütfen Seçiniz</asp:ListItem>
                                <asp:ListItem>MNG Kargo</asp:ListItem>
                                <asp:ListItem>Yurtiçi Kargo</asp:ListItem>
                                <asp:ListItem>Aras Kargo</asp:ListItem>
                                <asp:ListItem>Sürat Kargo</asp:ListItem>
                                <asp:ListItem>Fedex Kargo</asp:ListItem>
                                <asp:ListItem>UPS Kargo</asp:ListItem>
                                <asp:ListItem>DHL Kargo</asp:ListItem>
                                <asp:ListItem>PTT Kargo</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Required_Kayit_1" runat="server" ErrorMessage="Lütfen  kargo firmasını seçiniz."
                                Display="None" ControlToValidate="KargoDrop" ValidationGroup="Kargo" InitialValue="0"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="Validator_Kayit_1" runat="server" TargetControlID="Required_Kayit_1"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <fieldset style="width: 48%; float: left; margin-left: 1%;">
                            <label class="labelfiel">Takip / Gönderi / Barkod No</label>
                            <asp:TextBox ID="TakipNoBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Required_Kayit_2" runat="server" ErrorMessage="Lütfen numarayı yazınız."
                                Display="None" ControlToValidate="TakipNoBox" ValidationGroup="Kargo"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="Validator_Kayit_2" runat="server" TargetControlID="Required_Kayit_2"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <div class="clear"></div>
                        <fieldset style="width: 48%; float: left;">
                            <label class="labelfiel">müşteri adı soyadı</label>
                            <asp:TextBox ID="MusteriAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <div id="divwidth"></div>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                                runat="server" ServiceMethod="SearchCustomers"
                                MinimumPrefixLength="2"
                                CompletionInterval="100"
                                EnableCaching="false"
                                CompletionSetCount="10"
                                TargetControlID="MusteriAdiBox"
                                FirstRowSelected="false"
                                CompletionListCssClass="AutoExtender"
                                CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListElementID="divwidth" OnClientHiding="OnClientCompleted"
                                OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                            </asp:AutoCompleteExtender>

                            <asp:RequiredFieldValidator ID="Required_Kayit_3" runat="server" ErrorMessage="Lütfen ad ve soyad yazınız"
                                Display="None" ControlToValidate="MusteriAdiBox" ValidationGroup="Kargo"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="Validator_Kayit_3" runat="server" TargetControlID="Required_Kayit_3"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <fieldset style="width: 48%; float: left; margin-left: 1%;">
                            <label class="labelfiel">sipariş numarası</label>
                            <asp:TextBox ID="SiparisNoBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <div id="divwidth2"></div>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2"
                                runat="server" ServiceMethod="SearchCustomers_siparisNo"
                                MinimumPrefixLength="2"
                                CompletionInterval="100"
                                EnableCaching="false"
                                CompletionSetCount="10"
                                TargetControlID="SiparisNoBox"
                                FirstRowSelected="false"
                                CompletionListCssClass="AutoExtender"
                                CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListElementID="divwidth2" OnClientHiding="OnClientCompleted"
                                OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                            </asp:AutoCompleteExtender>

                            <asp:RequiredFieldValidator ID="Required_Kayit_4" runat="server" ErrorMessage="Lütfen sipariş numarasını yazınız."
                                Display="None" ControlToValidate="SiparisNoBox" ValidationGroup="Kargo"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="Validator_Kayit_4" runat="server" TargetControlID="Required_Kayit_4"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <div class="clear"></div>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="KargoEkleBtn" runat="server" Text="Kargo Kaydet" CssClass="alt_btn" ValidationGroup="Kargo" OnClick="KargoEkleBtn_Click" />
                            </div>
                        </footer>
                        <br />
                        <br />
                    </div>
                </article>
                <div class="clear"></div>
                <article class="module width_full">
                    <header>
                        <h3>kayıtlı Kargo listesi</h3>
                    </header>
                    <div class="module_content">
                        <div id="AramaKriter_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="DivAc()">Filtreleme</a>
                        </div>
                        <div id="AramaPopup" class="AramaKriteri_Small_Yukseklik">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset style="width: 48%; float: left;">
                                    <label class="labelfiel">
                                        kargo firması</label>
                                    <asp:DropDownList ID="Ara_KargoDrop" runat="server" CssClass="select">
                                        <asp:ListItem Value="0">Lütfen Seçiniz</asp:ListItem>
                                        <asp:ListItem>MNG Kargo</asp:ListItem>
                                        <asp:ListItem>Yurtiçi Kargo</asp:ListItem>
                                        <asp:ListItem>Aras Kargo</asp:ListItem>
                                        <asp:ListItem>Sürat Kargo</asp:ListItem>
                                        <asp:ListItem>Fedex Kargo</asp:ListItem>
                                        <asp:ListItem>UPS Kargo</asp:ListItem>
                                        <asp:ListItem>DHL Kargo</asp:ListItem>
                                        <asp:ListItem>PTT Kargo</asp:ListItem>
                                    </asp:DropDownList>
                                </fieldset>
                                <fieldset style="width: 48%; float: left; margin-left: 1%;">
                                    <label class="labelfiel">Takip / Gönderi / Barkod No</label>
                                    <asp:TextBox ID="Ara_TakipNoBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                                </fieldset>
                                <div class="clear"></div>
                                <fieldset style="width: 48%; float: left;">
                                    <label class="labelfiel">müşteri adı soyadı</label>
                                    <asp:TextBox ID="Ara_MusteriAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                                    <div id="divwidt3"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender3"
                                        runat="server" ServiceMethod="SearchCustomers"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="Ara_MusteriAdiBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth3" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                                <fieldset style="width: 48%; float: left; margin-left: 1%;">
                                    <label class="labelfiel">sipariş numarası</label>
                                    <asp:TextBox ID="Ara_SiparisNoBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                                    <div id="divwidth4"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender4"
                                        runat="server" ServiceMethod="SearchCustomers_siparisNo"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="Ara_SiparisNoBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth4" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kargo Bilgilerini Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" ValidationGroup="Ara" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right; font-size: 13px;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 955px" border="0" cellpadding="0" cellspacing="1"
                            class="GridviewTable">
                            <tr>
                                <td style="width: 145px;">KARGO FİRMASI
                                </td>
                                <td style="width: 260px;">TAKİP NO
                                </td>
                                <td style="width: 155px;">SİPARİŞ NO
                                </td>
                                <td style="width: 180px;">MÜŞTERİ ADI SOYADI
                                </td>
                                <td style="width: 100px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="KargoListesi_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="E_KargoTakipID" OnPageIndexChanging="KargoListesi_Grid_PageIndexChanging" CssClass="Gridview" ShowHeader="false" PageSize="20" OnRowDataBound="KargoListesi_Grid_RowDataBound" OnRowCommand="KargoListesi_Grid_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="155px">
                                                <ItemTemplate>
                                                    <%# Eval("KargoFirmasi")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="280px">
                                                <ItemTemplate>
                                                    <asp:Label ID="TakipNoLbl" runat="server" Text='<%# Eval("TakipNo")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="170px">
                                                <ItemTemplate>
                                                    <%# Eval("SiparisNoFiyat")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="190px">
                                                <ItemTemplate>
                                                    <asp:Label ID="AdSoyadLbl" runat="server" Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                        ToolTip="Düzenle" CommandArgument='<%#Eval ("E_KargoTakipID") %>' AlternateText='<%# Eval("TakipNo")%>' OnClick="DuzenleBtn_Click" />
                                                    &nbsp;&nbsp;<asp:ImageButton ID="SilBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                        ToolTip="Kargo Firmasını Sil" CommandArgument='<%#Eval ("E_KargoTakipID") %>' CommandName="Sil" /><asp:ConfirmButtonExtender
                                                            ID="ConfirmButtonExtender1" runat="server" TargetControlID="SilBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                                                        </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />

                                    </asp:GridView>
                                    <h4 id="GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Kargo Bilgisi Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
                <asp:Button ID="GosterBtn" runat="server" Style="display: none;" />
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="GosterBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                    <div class="header">
                        Kargo Bilgileri Güncelleme
                    </div>
                    <div class="body">
                        <div id="BilgilerDiv" style="width: 330px; height: 130px; float: left; margin-left: 10px;">
                            <div style="width: 130px; height: 20px; float: left;">
                                <b>Kargo Firması :</b>
                            </div>
                            <div style="width: 200px; height: 30px; float: left;">
                                <asp:DropDownList ID="Guncelle_KargoFirmasi" runat="server" CssClass="select" Width="200px">
                                    <asp:ListItem>MNG Kargo</asp:ListItem>
                                    <asp:ListItem>Yurtiçi Kargo</asp:ListItem>
                                    <asp:ListItem>Aras Kargo</asp:ListItem>
                                    <asp:ListItem>Sürat Kargo</asp:ListItem>
                                    <asp:ListItem>Fedex Kargo</asp:ListItem>
                                    <asp:ListItem>UPS Kargo</asp:ListItem>
                                    <asp:ListItem>DHL Kargo</asp:ListItem>
                                    <asp:ListItem>PTT Kargo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="width: 130px; height: 20px; float: left;">
                                <b>Takip No :</b>
                            </div>
                            <div style="width: 200px; height: 30px; float: left;">
                                <asp:TextBox ID="Guncelle_TakipNoBox" runat="server" CssClass="textfield" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Required_Gun_1" runat="server" ErrorMessage="Lütfen numarayı yazınız."
                                    Display="None" ControlToValidate="Guncelle_TakipNoBox" ValidationGroup="KargoGuncelle"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="Validator_Gun_1" runat="server" TargetControlID="Required_Gun_1"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                            <div style="width: 130px; height: 20px; float: left;">
                                <b>Sipariş No :</b>
                            </div>
                            <div style="width: 200px; height: 30px; float: left;">
                                <asp:TextBox ID="Guncelle_SiparisNoBox" runat="server" CssClass="textfield" Width="200px"></asp:TextBox>
                                <div id="divwidth5"></div>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender5"
                                    runat="server" ServiceMethod="SearchCustomers_siparisNo"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100"
                                    EnableCaching="false"
                                    CompletionSetCount="10"
                                    TargetControlID="Guncelle_SiparisNoBox"
                                    FirstRowSelected="false"
                                    CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="divwidth5" OnClientHiding="OnClientCompleted"
                                    OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                </asp:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Required_Gun_2" runat="server" ErrorMessage="Lütfen sipariş numarasını yazınız."
                                    Display="None" ControlToValidate="Guncelle_SiparisNoBox" ValidationGroup="KargoGuncelle"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="Validator_Gun_2" runat="server" TargetControlID="Required_Gun_2"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                            <div style="width: 130px; height: 20px; float: left;">
                                <b>Müşteri Ad Soyad :</b>
                            </div>
                            <div style="width: 200px; height: 30px; float: left;">
                                <asp:TextBox ID="Guncelle_MusteriAdBox" runat="server" CssClass="textfield" Width="200px"></asp:TextBox>
                                <div id="divwidth6"></div>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender6"
                                    runat="server" ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100"
                                    EnableCaching="false"
                                    CompletionSetCount="10"
                                    TargetControlID="Guncelle_MusteriAdBox"
                                    FirstRowSelected="false"
                                    CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="divwidth6" OnClientHiding="OnClientCompleted"
                                    OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                </asp:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Required_Gun_3" runat="server" ErrorMessage="Lütfen sipariş numarasını yazınız."
                                    Display="None" ControlToValidate="Guncelle_MusteriAdBox" ValidationGroup="KargoGuncelle"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="Validator_Gun_3" runat="server" TargetControlID="Required_Gun_3"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <div class="footer" align="right">
                            <asp:Button ID="KaydetBtn" runat="server" Text="Kaydet" CssClass="button" OnClick="KaydetBtn_Click" ValidationGroup="KargoGuncelle" />
                            &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>


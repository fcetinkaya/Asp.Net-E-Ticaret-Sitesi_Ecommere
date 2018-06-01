<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunTaksitlendirme.aspx.cs" Inherits="Rumrum_UrunTaksitlendirme" %>

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
        function HighlightRow(chkB) {
            var IsChecked = chkB.checked;
            if (IsChecked) {
                chkB.parentElement.parentElement.style.backgroundColor = '#c9cdcf';
                chkB.parentElement.parentElement.style.color = 'white';
            } else {
                chkB.parentElement.parentElement.style.backgroundColor = 'white';
                chkB.parentElement.parentElement.style.color = 'black';
            }
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
                <h4 id="KayitTamam" runat="server" class="alert_success" visible="false" style="height: 50px;">
                    <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
                    <br />
                    <asp:HyperLink ID="UrunKontrolLink" runat="server" CssClass="submit_link" Target="_blank">Ürünü Kontrol Etmek için Tıklayın..</asp:HyperLink>
                </h4>
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <h4 id="Urunyok" runat="server" class="alert_warning" visible="false">
                    <asp:Label ID="InfoLbl" runat="server">Aradığınız ürün ile ilgili taksitlendirme bulunamadı.</asp:Label>
                </h4>
                <article class="module width_full">
                    <header>
                        <h3>ürün arama</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="labelfiel">ürün adı</label>
                            <asp:TextBox ID="UrunAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen  adını yazınız."
                                Display="None" ControlToValidate="UrunAdiBox" ValidationGroup="UrunAra"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="urunBilgileriniGetirBtn" runat="server" Text="Ürün Bilgilerini Getir" CssClass="alt_btn" ValidationGroup="UrunAra" OnClick="urunBilgileriniGetirBtn_Click" />
                            </div>
                        </footer>
                    </div>
                </article>
                <div class="clear"></div>
                <article id="TaksitEkleme_Article" class="module width_full" runat="server" visible="false">
                    <header>
                        <h3>Taksit ekleme</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="labelfiel">banka adı</label>
                            <asp:DropDownList ID="bankalarDrop" runat="server" AppendDataBoundItems="true" CssClass="select" AutoPostBack="true" OnSelectedIndexChanged="bankalarDrop_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen banka seçiniz."
                                Display="None" ControlToValidate="bankalarDrop" ValidationGroup="TaksitEkle"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <fieldset>
                            <label class="labelfiel">Taksit Sayısı</label>
                            <asp:DropDownList ID="TaksitSayisiDrop" runat="server" CssClass="select" AppendDataBoundItems="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen banka seçiniz."
                                Display="None" ControlToValidate="TaksitSayisiDrop" ValidationGroup="TaksitEkle"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div style="padding: 5px 0px 0px 5px; font-weight: bold; width: 210px; float: left;">
                                Ürün Fiyatı :
                    <asp:Label ID="UrunFiyatiLbl" runat="server"></asp:Label>
                            </div>
                            <div class="submit_link">
                                <asp:Button ID="TaksitEkleBtn" runat="server" Text="Taksit Ekle" CssClass="alt_btn" ValidationGroup="TaksitEkle" OnClick="TaksitEkleBtn_Click" />
                            </div>
                        </footer>
                    </div>
                </article>
                <div class="clear"></div>
                <article id="Details" class="module width_full" runat="server" visible="false">
                    <header>
                        <h3>ürün taksit bilgileri</h3>
                    </header>
                    <div class="module_content">
                        <asp:Panel ID="KayitliTaksitler" runat="server" ScrollBars="Horizontal" Height="400px">
                            <asp:Repeater ID="TaksitRepeater" runat="server">
                                <HeaderTemplate>
                                    <div id="item" style="width: 35px; height: 20px; float: left;">
                                    </div>
                                    <div style="width: 350px; height: 20px; float: left; font-weight: bold;">
                                        ÜRÜN ADI
                                    </div>
                                    <div style="width: 150px; height: 20px; float: left; font-weight: bold;">
                                        BANKA ADI
                                    </div>
                                    <div style="width: 100px; height: 20px; float: left; font-weight: bold;">
                                        TAKSİT SAYISI
                                    </div>
                                    <div style="width: 100px; height: 20px; float: left; font-weight: bold;">
                                        TAKSİT FİYATI
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="margin: 10px; width: 750px; height: 20px; float: left;">
                                        <div id="item" style="width: 35px; height: 20px; float: left;">
                                            <asp:CheckBox ID="ResimCheck" runat="server" onclick="javascript:HighlightRow(this);" /><asp:HiddenField ID="TaksitID" runat="server" Value='<%# Eval("TaksitID") %>' />
                                        </div>
                                        <div style="width: 350px; height: 20px; float: left;">
                                            <%# Eval("UrunAdi") %>
                                        </div>
                                        <div style="width: 150px; height: 20px; float: left;">
                                            <%# Eval("BankaAdi") %>
                                        </div>
                                        <div style="width: 100px; height: 20px; float: left;">
                                            <%# Eval("TaksitSayisi") %>
                                        </div>
                                        <div style="width: 100px; height: 20px; float: left;">
                                            <%# Eval("TaksitTutari") %> TL
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                        <h4 id="TaksitYok" runat="server" class="alert_warning" visible="false">Ürün için kayıtlı taksitlendirme bulunamadı !
                        </h4>
                    </div>
                    <footer>
                        <div class="submit_link">
                            <asp:Button ID="silBtn" runat="server" Text="Seçili Ürünlerin Taksitlerini Sil" CssClass="butoncuk" OnClick="silBtn_Click" />
                            <asp:ConfirmButtonExtender
                                ID="ConfirmButtonExtender1" runat="server" TargetControlID="silBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                            </asp:ConfirmButtonExtender>
                        </div>
                    </footer>
                </article>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


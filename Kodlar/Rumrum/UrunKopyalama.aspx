<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunKopyalama.aspx.cs" Inherits="Rumrum_UrunKopyalama" ValidateRequest="false" %>

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
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <h4 id="Urunyok" runat="server" class="alert_info" visible="false">
                    <asp:Label ID="InfoLbl" runat="server"> Aradığınız ürün bulunamadı.</asp:Label>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen ürün adını yazınız."
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
                        <br />
                        <br />
                    </div>
                </article>
                <div class="clear"></div>
                <article id="Details" class="module width_full" runat="server" visible="false">
                    <header>
                        <h3>ürün bilgileri</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="Small_labelfiel">ürün adı</label>
                            <label class="labelfiel" style="width:650px;">
                                <asp:Label ID="UrunAdiLbl" runat="server"></asp:Label>
                            </label>
                        </fieldset>
                        <fieldset>
                            <label class="Small_labelfiel">ürün resim</label>
                            <asp:Image ID="UrunResim" runat="server" Height="120px" Width="115px" />
                        </fieldset>
                        <fieldset>
                            <label class="Small_labelfiel">ürün fiyatı</label>
                            <label class="labelfiel">
                                Eski Fiyatı :&nbsp; 
                                <asp:Label ID="EskiFiyatLbl" runat="server"></asp:Label>
                                &nbsp;  /&nbsp; 
                              Yeni Fiyatı :&nbsp; 
                                <asp:Label ID="YeniFiyatlbl" runat="server"></asp:Label>
                            </label>
                        </fieldset>
                        <fieldset>
                            <label class="Small_labelfiel">kategori adı</label>
                            <label class="labelfiel">
                                <asp:Label ID="KategoriAdiLbl" runat="server"></asp:Label>
                            </label>
                        </fieldset>
                        <fieldset>
                            <label class="Small_labelfiel">Telefon / Model</label>
                            <label class="labelfiel">
                                <asp:Label ID="TelefonLbl" runat="server"></asp:Label>
                                &nbsp;  /&nbsp; 
                                <asp:Label ID="ModelLbl" runat="server"></asp:Label>
                            </label>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="DuzenleBtn" runat="server" Text="Ürünü Kopyala" CssClass="alt_btn" OnClick="DuzenleBtn_Click" />
                            </div>
                        </footer>
                        <br />
                        <br />
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

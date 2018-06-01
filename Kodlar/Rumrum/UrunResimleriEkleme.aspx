<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunResimleriEkleme.aspx.cs" Inherits="Rumrum_UrunResimleriEkleme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="../colorbox/colorbox.css" rel="stylesheet" />
    <script src="../colorbox/jquery.colorbox.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modall");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
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
        $(document).ready(function () {
            $(".group1").colorbox({
                rel: 'group1'
                //     width: "50%",
                //    height: "50%"
                //  inline: true
            });
        });
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
        .modall {
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

        .Page_loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
        /*Auto Complete*/
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
    <div class="Page_loading" align="center">
        Yükleniyor. Lütfen Bekleyin...<br />
        <br />
        <img src="images/Loading.gif" alt="" />
    </div>
    <section id="main" class="column">
        <h4 class="alert_info">Ürün için en fazla 8 adet yükleme yapabilirsiniz.</h4>
        <h4 id="HataVar" runat="server" class="alert_error" visible="false">
            <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
        </h4>
        <h4 id="Urunyok" runat="server" class="alert_warning" visible="false">Aradığınız ürün bulunamadı.
        </h4>
        <h4 id="KayitTamam" runat="server" class="alert_success" visible="false" style="height:50px;">
            <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="UrunKontrolLink" runat="server" CssClass="submit_link" Target="_blank"></asp:HyperLink>
        </h4>
        <article id="Arama_Article" class="module width_full" runat="server">
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
                        <asp:Button ID="urunBilgileriniGetirBtn" runat="server" Text="Ürün Resimlerini Getir" CssClass="alt_btn" ValidationGroup="UrunAra" OnClick="urunBilgileriniGetirBtn_Click" />
                    </div>
                </footer>
                <br />
                <br />
            </div>
        </article>
        <div class="clear"></div>
        <article id="ResimUpload_Article" class="module width_full" runat="server" visible="false">
            <header>
                <h3>Resim Yükleme</h3>
            </header>
            <div class="module_content">
                <fieldset id="ResimYukleme_field" runat="server">
                    <label class="Small_labelfiel">Resim(ler) Seçiniz :</label>
                    <label class="labelfiel">
                        <asp:FileUpload runat="server" ID="UploadImages" CssClass="textfield" AllowMultiple="true" Width="400px" />
                    </label>
                </fieldset>
                <h4 id="ResimUploadYok" runat="server" class="alert_warning" visible="false">Resim ekleme limiti dolmuştur.
                </h4>
                <footer>
                    <div class="submit_link">
                        <asp:Button ID="ResimleriYukleBtn" runat="server" Text="Resimleri Yükle" CssClass="alt_btn" OnClick="ResimleriYukleBtn_Click" />
                    </div>
                </footer>
                <br />
                <br />
            </div>
        </article>
        <div class="clear"></div>
        <article id="KayitliResimler_Article" class="module width_full" runat="server" visible="false">
            <header>
                <h3>Kayıtlı Resimler</h3>
            </header>
            <div class="module_content" style="height: 350px;">
                <asp:Panel ID="YukluResimler" runat="server">
                    <div id="AltResimlerDiv" style="float: left; width: 900px; height: 340px;">
                        <asp:Repeater ID="ResimlerRepeater" runat="server">
                            <ItemTemplate>
                                <div id="ResimBoyutlariDiv" style="margin: 10px; width: 200px; height: 150px; float: left;">
                                    <div id="item" style="height: 150px; width: 200px; float: left;">
                                        <asp:CheckBox ID="ResimCheck" runat="server" onclick="javascript:HighlightRow(this);" /><asp:HiddenField ID="ResimID" runat="server" Value='<%# Eval("E_ResimID") %>' />
                                        <a href='<%# Eval("ResimAd","../Urunler/Resimler/{0}") %>' class="group1">
                                            <asp:Image ID="TedLogo" runat="server" Height="150px" Width="200px" ImageUrl='<%# Eval("ResimAd","../Urunler/Resimler/{0}") %>' /></a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </asp:Panel>
                <h4 id="ResimlerYok" runat="server" class="alert_warning" visible="false">Ürün için kayıtlı resim bulunamadı !
                </h4>
                <br />
                <br />
            </div>
            <footer>
                <div class="submit_link">
                    <asp:Button ID="ResimleriSilBtn" runat="server" Text="Seçili Resimleri Sil" CssClass="butoncuk" OnClick="ResimleriSilBtn_Click" />
                    <asp:ConfirmButtonExtender
                        ID="ConfirmButtonExtender1" runat="server" TargetControlID="ResimleriSilBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                    </asp:ConfirmButtonExtender>
                </div>
            </footer>
        </article>
    </section>
</asp:Content>


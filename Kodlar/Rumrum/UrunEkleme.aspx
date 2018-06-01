<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunEkleme.aspx.cs" Inherits="Rumrum_UrunEkleme" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <script src="https://jqueryjs.googlecode.com/files/jquery-1.3.2.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckeditor/adapters/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_AciklamaBox').ckeditor();
        });

        function UpdateContent() {
            var ckeditorinstance = $('#ContentPlaceHolder1_AciklamaBox').ckeditorGet();
            ckeditorinstance.updateElement();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="main" class="column">
        <h4 id="KayitTamam" runat="server" class="alert_success" visible="false" style="height: 70px;">
            <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
            <br /><br />
            <asp:HyperLink ID="UrunKontrolLink" runat="server" CssClass="submit_link" Target="_blank"></asp:HyperLink>
            <!-- Google Plus -->
            <script type="text/javascript" src="https://apis.google.com/js/platform.js">
  {lang: 'tr', parsetags: 'explicit'}
            </script>
            <div id="GooglePlus" runat="server" class="g-plus" data-action="share" data-annotation="none"></div>
            <script type="text/javascript">gapi.plus.go();</script>
            <!-- Pinterest -->
            <a id="Pinterest" runat="server" data-pin-do="buttonPin" data-pin-config="none">
                <img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_rect_gray_20.png" /></a>
            <!-- Please call pinit.js only once per page -->
            <script type="text/javascript" async src="//assets.pinterest.com/js/pinit.js"></script>
            <!-- Facebook -->
            <a id="Facebook2" runat="server" type="button" name="fb_share" href="http://www.facebook.com/sharer.php" _fcksavedurl="http://www.facebook.com/sharer.php">Paylaş</a><script src="http://static.ak.fbcdn.net/connect.php/js/FB.Share" type="text/javascript"></script>
            <!-- Twitter -->
            <a id="Twetter" runat="server" href="https://twitter.com/share" class="twitter-share-button" data-via="ceptaki" data-lang="tr" data-related="anywhereTheJavascriptAPI" data-count="none">Tweet</a>
            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
        </h4>
        <h4 id="HataVar" runat="server" class="alert_error" visible="false">
            <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
        </h4>
        <article id="UrunEklemeDiv" runat="server" class="module width_full">
            <header>
                <h3>ürün ekleme işlemleri</h3>
            </header>
            <div class="module_content">
                <fieldset>
                    <label class="labelfiel">
                        ürün adı</label>
                    <asp:TextBox ID="UrunAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen ürün adını yazınız."
                        Display="None" ControlToValidate="UrunAdiBox" ValidationGroup="UrunEkle"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        fiyat</label>
                    <asp:TextBox ID="Fiyatbox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="Fiyatbox_FilteredTextBoxExtender" runat="server"
                        Enabled="True" TargetControlID="Fiyatbox" FilterType="Custom,Numbers" ValidChars=",">
                    </asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen ürün fiyatını yazınız."
                        Display="None" ControlToValidate="Fiyatbox" ValidationGroup="UrunEkle">
                    </asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        indirim oranı</label>
                    <asp:DropDownList ID="IndirimOraniDrop" runat="server" AppendDataBoundItems="true" CssClass="select"></asp:DropDownList>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        kategori</label>
                    <asp:DropDownList ID="KategoriDrop" runat="server" AppendDataBoundItems="true" CssClass="select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen kategoriyi seçiniz."
                        Display="None" ControlToValidate="KategoriDrop" ValidationGroup="UrunEkle"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator3"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        telefon</label>
                    <asp:DropDownList ID="telefonDrop" runat="server" AppendDataBoundItems="true" CssClass="select" OnSelectedIndexChanged="telefonDrop_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen telefon seçiniz."
                        Display="None" ControlToValidate="telefonDrop" ValidationGroup="UrunEkle"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        telefon modeli</label>
                    <asp:DropDownList ID="dropTelefonModel" runat="server" AppendDataBoundItems="true" CssClass="select" Enabled="false"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Lütfen telefon modelini seçiniz."
                        Display="None" ControlToValidate="dropTelefonModel" ValidationGroup="UrunEkle"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator5"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        Küçük resim (210x210)</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textfield" Width="410px" />

                </fieldset>
                <fieldset>
                    <label class="labelfiel">
                        açıklama</label><br />
                    <br />
                    <asp:TextBox ID="AciklamaBox" runat="server" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="AciklamaBox" ValidationGroup="UrunEkle" Display="None" ErrorMessage="Lütfen ürün için açıklama yazınız."></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RequiredFieldValidator6"
                            PopupPosition="BottomLeft">
                        </asp:ValidatorCalloutExtender>

                </fieldset>
                <footer>
                    <div class="submit_link">
                        <asp:Button ID="btnUrunKayit" runat="server" Text="Ürünü Kaydet"
                            CssClass="alt_btn" OnClientClick="javascript:UpdateContent()" ValidationGroup="UrunEkle" OnClick="btnUrunKayit_Click" />
                    </div>
                </footer>
            </div>
        </article>
    </section>
</asp:Content>


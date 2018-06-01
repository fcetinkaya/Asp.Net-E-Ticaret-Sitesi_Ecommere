<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunDuzenlemeOnay.aspx.cs" Inherits="Rumrum_UrunDuzenlemeOnay" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Ajs/main.js"></script>
    <script src="https://jqueryjs.googlecode.com/files/jquery-1.3.2.min.js" type="text/javascript"></script>
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
            <br />
            <asp:HyperLink ID="UrunKontrolLink" runat="server" CssClass="submit_link" Target="_blank"></asp:HyperLink>
        </h4>
        <h4 id="HataVar" runat="server" class="alert_error" visible="false">
            <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
        </h4>
        <article id="UrunGuncellemeDiv" runat="server" class="module width_full">
            <header>
                <h3>ürün düzenleme</h3>
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
                        resim
                    </label>
                    <span style="width: 75px; text-align: right;">
                        <asp:HyperLink ID="ResimOnIzlemeLink" class="screenshot" runat="server" NavigateUrl="#"> Resim Ön İzleme</asp:HyperLink></span>
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
                        <asp:Button ID="btnUrunKayit" runat="server" Text="Ürünü Güncelle"
                            CssClass="alt_btn" OnClientClick="javascript:UpdateContent()" ValidationGroup="UrunEkle" OnClick="btnUrunKayit_Click" />
                    </div>
                </footer>
            </div>
        </article>
    </section>
</asp:Content>


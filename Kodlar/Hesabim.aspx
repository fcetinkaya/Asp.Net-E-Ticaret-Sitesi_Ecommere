<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hesabim.aspx.cs" Inherits="Hesabim" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js" language="javascript"></script>
    <link type="text/css" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js" language="javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#content").find("[id^='tab']").hide(); // Hide all content
            $("#tabs li:first").attr("id", "current"); // Activate the first tab
            $("#content #tab1").fadeIn(); // Show first tab's content

            $('#tabs a').click(function (e) {
                e.preventDefault();
                if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                    return;
                }
                else {
                    $("#content").find("[id^='tab']").hide(); // Hide all content
                    $("#tabs li").attr("id", ""); //Reset id's
                    $(this).parent().attr("id", "current"); // Activate this
                    $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
                }
            });
        });
    </script>
    <style type="text/css">
        #tabs {
            overflow: hidden;
            width: 100%;
            margin: 0;
            padding: 0;
            list-style: none;
        }

            #tabs li {
                float: left;
                margin: 0 .5em 0 0;
            }

            #tabs a {
                border: 1px solid #D4D0D0;
                position: relative;
                background: #ddd;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ddd));
                background-image: -webkit-linear-gradient(top, #fff, #ddd);
                background-image: -moz-linear-gradient(top, #fff, #ddd);
                background-image: -ms-linear-gradient(top, #fff, #ddd);
                background-image: -o-linear-gradient(top, #fff, #ddd);
                background-image: linear-gradient(to bottom, #fff, #ddd);
                padding: .7em 3.5em;
                float: left;
                text-decoration: none;
                color: #444;
                text-shadow: 0 1px 0 rgba(255,255,255,.8);
                -webkit-border-radius: 5px 0 0 0;
                -moz-border-radius: 5px 0 0 0;
                border-radius: 5px 0 0 0;
                -moz-box-shadow: 0 2px 2px rgba(0,0,0,.4);
                -webkit-box-shadow: 0 2px 2px rgba(0,0,0,.4);
                box-shadow: 0 2px 2px rgba(0,0,0,.4);
                font-weight: bold;
            }

                #tabs a:hover,
                #tabs a:hover::after,
                #tabs a:focus,
                #tabs a:focus::after {
                    background: #fff;
                }

                #tabs a:focus {
                    outline: 0;
                }

                #tabs a::after {
                    content: '';
                    position: absolute;
                    z-index: 1;
                    top: 0;
                    right: -.5em;
                    bottom: 0;
                    width: 1em;
                    background: #ddd;
                    background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ddd));
                    background-image: -webkit-linear-gradient(top, #fff, #ddd);
                    background-image: -moz-linear-gradient(top, #fff, #ddd);
                    background-image: -ms-linear-gradient(top, #fff, #ddd);
                    background-image: -o-linear-gradient(top, #fff, #ddd);
                    background-image: linear-gradient(to bottom, #fff, #ddd);
                    -moz-box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    -webkit-box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    box-shadow: 2px 2px 2px rgba(0,0,0,.4);
                    -webkit-transform: skew(10deg);
                    -moz-transform: skew(10deg);
                    -ms-transform: skew(10deg);
                    -o-transform: skew(10deg);
                    transform: skew(10deg);
                    -webkit-border-radius: 0 5px 0 0;
                    -moz-border-radius: 0 5px 0 0;
                    border-radius: 0 5px 0 0;
                }

            #tabs #current a {
                background: #fff;
            }

                #tabs #current a::after {
                    background: #fff;
                }

        #content {
            background: #fff;
            padding: 2em;
            -moz-border-radius: 0 5px 5px 5px;
            -webkit-border-radius: 0 5px 5px 5px;
            border-radius: 0 5px 5px 5px;
            -moz-box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            -webkit-box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            box-shadow: 0 -2px 3px -2px rgba(0, 0, 0, .5);
            float: left;
            border: 1px solid #D4D0D0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Hesabım
    </div>
    <div class="Footer_Linkler_Baslik">
        Hoş geldiniz,
        <asp:Label ID="AdSoyadLbl" runat="server">Fatih Çetinkaya</asp:Label>
    </div>
    <div class="UrunDetay_Ayrintilar_Aciklama">
        <asp:Button ID="SepetBtn" runat="server" CssClass="btn-orange-H" Text="Sepetiniz" PostBackUrl="~/Sepet.aspx" />
        <asp:Button ID="SiparisTakipBtn" runat="server" CssClass="btn-orange-H" Text="Sipariş Takip" PostBackUrl="~/SiparisTakibi.aspx" />
        <asp:Button ID="KargoTakipBtn" runat="server" CssClass="btn-orange-H" Text="Kargo Takip" PostBackUrl="~/SiparisKargoTakibi.aspx" />
         <asp:Button ID="KuryeTakibiBtn" runat="server" CssClass="btn-orange-H" Text="Kurye Takip" PostBackUrl="~/SiparisKuryeTakibi.aspx" />
        <asp:Button ID="OdemeBildirimBtn" runat="server" CssClass="btn-orange-H" Text="Ödeme Bildirim Formu" PostBackUrl="~/OdemeBildirimFormu.aspx" />
        <asp:Button ID="IadeDegisimBtn" runat="server" CssClass="btn-orange-H" Text="İade/Değişim Formu" PostBackUrl="~/IadeDegisimFormu.aspx" />
        <ul id="tabs">
            <li><a href="#" name="tab1">Bilgi Güncelleme</a></li>
            <li><a href="#" name="tab2">Teslimat ve Fatura Adresi</a></li>
            <li><a href="#" name="tab3">Şifre Değiştirme</a></li>
        </ul>
        <div id="content">
            <div id="tab1" style="float: left; width: 980px; padding-bottom: 10px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form_Elementleri">
                            <asp:TextBox ID="AdSoyadBox" runat="server" placeholder="Adınız Soyadınız" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="Ad ve Soyad Yazınız." Display="None" ControlToValidate="AdSoyadBox" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="EvTlfBox" runat="server" placeholder="Ev Telefonu" CssClass="TextBox_F" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ErrorMessage="Ev Telefonu Yazınız." Display="None" ControlToValidate="EvTlfBox"
                                ValidationGroup="kayit"></asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                TargetControlID="EvTlfBox" FilterType="Custom,Numbers">
                            </asp:FilteredTextBoxExtender>
                            <br />
                            <asp:TextBox ID="IsTlfBox" runat="server" placeholder="İş Telefonu" CssClass="TextBox_F" /><asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="IsTlfBox"
                                FilterType="Custom,Numbers">
                            </asp:FilteredTextBoxExtender>
                            <br />
                            <asp:TextBox ID="CepTlfBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ErrorMessage="Cep Telefonunu Yazınız." Display="None" ControlToValidate="CepTlfBox"
                                ValidationGroup="kayit"></asp:RequiredFieldValidator><asp:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="CepTlfBox"
                                    FilterType="Custom,Numbers">
                                </asp:FilteredTextBoxExtender>
                            <br />
                            <asp:DropDownList ID="SehirDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" OnSelectedIndexChanged="SehirDrop_SelectedIndexChanged">
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Şehir Seçiniz."
                                Display="None" ControlToValidate="SehirDrop" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="IlceDrop" runat="server" CssClass="DropDown_F" Enabled="false">
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="İlçe Seçiniz."
                                Display="None" ControlToValidate="IlceDrop" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="EPostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" ReadOnly="true" />
                            <br />
                            <asp:Button ID="KayitBtn" runat="server" CssClass="btn-orange" Text="Tamam" OnClick="KayitBtn_Click" ValidationGroup="kayit" />
                            <asp:ValidationSummary ID="KaydetSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="kayit" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="tab2" style="float: left; width: 980px; padding-bottom: 10px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="Sepet_Sol_Satir">
                            <div class="Hakkimizda_Baslik">
                                Teslimat Bilgileri
                            </div>
                            <div class="form_Elementleri">
                                <asp:TextBox ID="Teslimat_TckimlikNoBox" runat="server" placeholder="Tc Kimlik No" CssClass="TextBox_F" MaxLength="11" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ErrorMessage="Tc Kimlik No Yazınız." Display="None" ControlToValidate="Teslimat_TckimlikNoBox"
                                    ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                    TargetControlID="Teslimat_TckimlikNoBox" FilterType="Custom,Numbers">
                                </asp:FilteredTextBoxExtender>
                                <asp:TextBox ID="Teslimat_EpostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="E-Posta Adresini Yazınız."
                                    Display="None" ControlToValidate="Teslimat_EpostaBox" ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="EpostaExpressionValidator" runat="server" ErrorMessage="Geçerli bir e-posta adresi yazınız."
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Teslimat_EpostaBox"
                                    ValidationGroup="adres" Display="None"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="Teslimat_CepBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ErrorMessage="Cep Telefonunu Yazınız." Display="None" ControlToValidate="Teslimat_CepBox"
                                    ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="Teslimat_CepBox"
                                    FilterType="Custom,Numbers">
                                </asp:FilteredTextBoxExtender>
                                <asp:TextBox ID="Teslimat_TelefonBox" runat="server" placeholder="Telefon" CssClass="TextBox_F" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ErrorMessage="Ev Telefonu Yazınız." Display="None" ControlToValidate="Teslimat_TelefonBox"
                                    ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True"
                                    TargetControlID="Teslimat_TelefonBox" FilterType="Custom,Numbers">
                                </asp:FilteredTextBoxExtender>
                                <asp:DropDownList ID="Teslimat_SehirDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Teslimat_SehirDrop_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Şehir Seçiniz."
                                    Display="None" ControlToValidate="Teslimat_SehirDrop" ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="Teslimat_IlceDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="İlçe Seçiniz."
                                    Display="None" ControlToValidate="Teslimat_IlceDrop" ValidationGroup="adres"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="Teslimat_AdresBox" runat="server" placeholder="Adres" CssClass="TextBox_F" TextMode="MultiLine" Height="100px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                    ErrorMessage="Teslimat Adresini Yazınız." Display="None" ControlToValidate="Teslimat_AdresBox" ValidationGroup="adres"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="Sepet_Sag_Satir">
                            <div class="Hakkimizda_Baslik">
                                Fatura Bilgileri
                            </div>
                            <div class="form_Elementleri">
                                <asp:TextBox ID="Ft_YetkiliAdSoyadBox" runat="server" placeholder="Yetkili Adı Soyadı" CssClass="TextBox_F" />
                                <asp:TextBox ID="Ft_FirmaBox" runat="server" placeholder="Firma Adı" CssClass="TextBox_F" />
                                <asp:TextBox ID="Ft_VergiDairesiBox" runat="server" placeholder="Vergi Dairesi" CssClass="TextBox_F" />
                                <asp:TextBox ID="Ft_VergiNoBox" runat="server" placeholder="Vergi Numarası" CssClass="TextBox_F" />
                                <asp:DropDownList ID="Ft_FirmaSehirDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ft_FirmaSehirDrop_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Ft_FirmaIlceDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                                </asp:DropDownList>
                                <asp:TextBox ID="Ft_FirmaAdresBox" runat="server" placeholder="Fatura Adresi" CssClass="TextBox_F" TextMode="MultiLine" Height="100px" />
                                <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                    <asp:CheckBox ID="TeslimatIleFaturaAyniCheck" runat="server" Text="Teslimat Adresi ile Aynı" OnCheckedChanged="TeslimatIleFaturaAyniCheck_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <asp:Button ID="DevamBtn" runat="server" CssClass="btn-orange" Text="Kaydet  " OnClick="DevamBtn_Click" ValidationGroup="adres" />
                                <asp:ValidationSummary ID="ValidationSummary_Teslimat" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="adres" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="tab3" style="float: left; width: 980px; padding-bottom: 10px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="form_Elementleri">
                            <asp:TextBox ID="SifreBox" runat="server" placeholder="Şifre" CssClass="TextBox_F" TextMode="Password" /><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Şifreyi Yazınız."
                                Display="None" ControlToValidate="SifreBox" ValidationGroup="SifreValide"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SifreTekrarBox" runat="server" placeholder="Tekrar Şifre" CssClass="TextBox_F" TextMode="Password" /><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                ErrorMessage="Şifreyi Tekrar Yazınız." Display="None" ControlToValidate="SifreTekrarBox"
                                ValidationGroup="SifreValide"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="SifreBox"
                                ControlToValidate="SifreTekrarBox" ErrorMessage="Şifre aynı değil" ValidationGroup="SifreValide"
                                Display="None"></asp:CompareValidator>
                            <asp:Button ID="SifreKayitBtn" runat="server" CssClass="btn-orange" Text="Tamam" ValidationGroup="SifreValide" OnClick="SifreKayitBtn_Click" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="SifreValide" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UyeOl.aspx.cs" Inherits="UyeOl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form">
        <div id="GirisDiv">YENİ KAYIT</div>
        <div class="line"></div>

        <!-- If you don't want a social buttons, delete all of these code -->
        <asp:Button ID="FacebookBtn" runat="server" CssClass="btn-facebook" Text="Facebook ile bağlan" OnClick="FacebookBtn_Click" />
        <asp:Button ID="TwitterBtn" runat="server" CssClass="btn-twitter" Text="Twitter ile bağlan" OnClick="TwitterBtn_Click" />
        <!-- Till here -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="Basarali_Div" runat="server" class="Basarili" visible="false" style="width: 370px;">
                    <span class="Hakkimizda_Baslik">Üyeliğiniz Onaylandı<br />
                        Üyeliğiniz başarıyla oluşturulmuştur.<br />
                        <a class="MenuLink" href="Giris.aspx" title="Giriş Yap">Giriş yapmak için tıklayın..</a>
                    </span>
                    <br />
                    <br />
                </div>
                <div class="form_Elementleri">
                    <asp:TextBox ID="AdSoyadBox" runat="server" placeholder="Adınız Soyadınız" CssClass="TextBox_F" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Ad ve Soyad Yazınız." Display="None" ControlToValidate="AdSoyadBox" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="EvTlfBox" runat="server" placeholder="Ev Telefonu" CssClass="TextBox_F" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Ev Telefonu Yazınız." Display="None" ControlToValidate="EvTlfBox"
                        ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                        TargetControlID="EvTlfBox" FilterType="Custom,Numbers">
                    </asp:FilteredTextBoxExtender>
                    <asp:TextBox ID="IsTlfBox" runat="server" placeholder="İş Telefonu" CssClass="TextBox_F" /><asp:FilteredTextBoxExtender
                        ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="IsTlfBox"
                        FilterType="Custom,Numbers">
                    </asp:FilteredTextBoxExtender>
                    <asp:TextBox ID="CepTlfBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="Cep Telefonunu Yazınız." Display="None" ControlToValidate="CepTlfBox"
                        ValidationGroup="kayit"></asp:RequiredFieldValidator><asp:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="CepTlfBox"
                            FilterType="Custom,Numbers">
                        </asp:FilteredTextBoxExtender>
                    <asp:DropDownList ID="SehirDrop" runat="server" CssClass="DropDown_F" AutoPostBack="true" OnSelectedIndexChanged="SehirDrop_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Şehir Seçiniz."
                        Display="None" ControlToValidate="SehirDrop" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="IlceDrop" runat="server" CssClass="DropDown_F" Enabled="false">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="İlçe Seçiniz."
                        Display="None" ControlToValidate="IlceDrop" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="EPostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="E-Posta Adresini Yazınız."
                        Display="None" ControlToValidate="EPostaBox" ValidationGroup="kayit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="EpostaExpressionValidator" runat="server" ErrorMessage="Geçerli bir e-posta adresi yazınız."
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EPostaBox"
                            ValidationGroup="kayit" Display="None"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="SifreBox" runat="server" placeholder="Şifre" CssClass="TextBox_F" TextMode="Password" /><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Şifreyi Yazınız."
                        Display="None" ControlToValidate="SifreBox" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="SifreTekrarBox" runat="server" placeholder="Tekrar Şifre" CssClass="TextBox_F" TextMode="Password" /><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                        ErrorMessage="Şifreyi Tekrar Yazınız." Display="None" ControlToValidate="SifreTekrarBox"
                        ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="SifreBox"
                        ControlToValidate="SifreTekrarBox" ErrorMessage="Şifre aynı değil" ValidationGroup="kayit"
                        Display="None"></asp:CompareValidator>
                    <br />
                    <br />
                    Güvenlik Kodu :
                    <img src="SecurityCode.aspx" />
                    <br />
                    <asp:TextBox ID="GuvenlikKodubox" runat="server" placeholder="Güvenlik Kodunu Girini" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="Güvenlik Kodunu Yazınız." Display="None" ControlToValidate="GuvenlikKodubox"
                        ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    <div class="YaziKarekter_Light" style="margin-top: 20px;">
                        <asp:CheckBox ID="SozlemeOkudumCheckBox" runat="server" /><a class="Footer_Link" href="#">Kullanıcı Sözleşmesini</a>,okudum kabul ediyorum.
                    </div>
                    <asp:Button ID="KayitBtn" runat="server" CssClass="btn-orange" Text="Kayıt Ol" OnClick="KayitBtn_Click" ValidationGroup="kayit" />
                    <asp:ValidationSummary ID="KaydetSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="kayit" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>


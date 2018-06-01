<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Iletisim_Buyuk_Baslik">
        İletişim Bilgileri
    </div>
    <div class="Iletisim_Sol_Satir">
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d96300.59990668843!2d28.82708884658585!3d41.03851774644467!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cabae935cb4949%3A0x3aea47bcaf71a222!2sY%C4%B1ld%C4%B1z+Teknik+%C3%9Cniversitesi+Teknopark+Davutpa%C5%9Fa!5e0!3m2!1str!2sus!4v1527852938681" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
    </div>
    <div class="Iletisim_Sag_Satir">
        <div class="Iletisim_Icerik">
            <div class="Iletisim_Sag_Satir_Baslik">Ünvan</div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="FirmaAdiLbl" runat="server"></asp:Label>
            </div>
            <div class="Iletisim_Sag_Satir_Baslik">Ticaret Sicil No</div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="TicaretSicilLbl" runat="server"></asp:Label>
            </div>
            <div class="Iletisim_Sag_Satir_Baslik">Adres</div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="AdresLbl" runat="server"></asp:Label>
            </div>
            <div class="Iletisim_Sag_Satir_Baslik">E-Mail</div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="EPostaLbl" runat="server"></asp:Label>
            </div>
            <div class="Iletisim_Sag_Satir_Baslik">Telefon </div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="TelefonLbl" runat="server"></asp:Label>
            </div>
            <div class="Iletisim_Sag_Satir_Baslik">Fax</div>
            <div class="Iletisim_Sag_Satir_Icerik">
                :
                <asp:Label ID="FaxLbl" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="Hakkimizda_Buyuk_Baslik">
        Sizi Arayalım
    </div>
    <div class="form_Elementleri">
        <asp:TextBox ID="SiziArayalimAdSoyadBox" runat="server" placeholder="Adınız Soyadınız" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Adınızı ve Soyadınızı Yazınız."
            Display="None" ControlToValidate="SiziArayalimAdSoyadBox" ValidationGroup="BeniAra"></asp:RequiredFieldValidator>
        <asp:TextBox ID="SiziArayalimCepTlfBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" MaxLength="20" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Cep Telefonu Yazınız."
            Display="None" ControlToValidate="SiziArayalimCepTlfBox" ValidationGroup="BeniAra"></asp:RequiredFieldValidator>
        <asp:Button ID="GonderBtn" runat="server" CssClass="btn-orange" Text="Gönder" OnClick="GonderBtn_Click" ValidationGroup="BeniAra" />
        <asp:ValidationSummary ID="ValidationSummary_BeniAra" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="BeniAra" />
    </div>
    <div class="Hakkimizda_Buyuk_Baslik">
        İletişim Formu
    </div>
    <div class="form_Elementleri">
        <asp:TextBox ID="IletisimAdSoyadBox" runat="server" placeholder="Adınız Soyadınız" CssClass="TextBox_F" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Adınızı ve Soyadınızı Yazınız."
            Display="None" ControlToValidate="IletisimAdSoyadBox" ValidationGroup="Iletisim"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="IletisimEPostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="E-Posta Adresini Yazınız."
            Display="None" ControlToValidate="IletisimEPostaBox" ValidationGroup="Iletisim"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="IletisimCepBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Cep Telefonu Yazınız."
            Display="None" ControlToValidate="IletisimCepBox" ValidationGroup="Iletisim"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="IletisimKonuBox" runat="server" placeholder="Konu" CssClass="TextBox_F" MaxLength="20" /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Konuyu Yazınız."
            Display="None" ControlToValidate="IletisimKonuBox" ValidationGroup="Iletisim"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="IletisimAciklamaBox" runat="server" placeholder="Açıklama" CssClass="TextBox_F" TextMode="MultiLine" Height="200px" MaxLength="250" /><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Açıklama Yazınız."
            Display="None" ControlToValidate="IletisimKonuBox" ValidationGroup="Iletisim"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="IletisimGonderBtn" runat="server" CssClass="btn-orange" Text="Gönder" OnClick="IletisimGonderBtn_Click" ValidationGroup="Iletisim" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Iletisim" />
    </div>
</asp:Content>


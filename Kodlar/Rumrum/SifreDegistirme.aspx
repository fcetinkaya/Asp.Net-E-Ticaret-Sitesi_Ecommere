<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="SifreDegistirme.aspx.cs" Inherits="Rumrum_SifreDegistirme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                        <h3>şifre işlemleri</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="labelfiel">şifre</label>
                            <asp:TextBox ID="SifreDegistirBox" runat="server" CssClass="textfield" Width="410px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen kategori adını yazınız."
                                Display="None" ControlToValidate="SifreDegistirBox" ValidationGroup="Ana_Kat"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="SifreDegistir_Btn" runat="server" Text="Şifre Değiştir" CssClass="alt_btn" ValidationGroup="Ana_Kat" OnClick="SifreDegistir_Btn_Click" />
                            </div>
                        </footer>
                        <br />
                        <br />
                    </div>
                </article>
                <div class="clear"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>


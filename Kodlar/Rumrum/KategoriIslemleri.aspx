<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="KategoriIslemleri.aspx.cs" Inherits="Rumrum_KategoriIslemleri" %>

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
                        <h3>ana kategori işlemleri</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="labelfiel">kategori adı</label>
                            <asp:TextBox ID="ana_kategoriAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen kategori adını yazınız."
                                Display="None" ControlToValidate="ana_kategoriAdiBox" ValidationGroup="Ana_Kat"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="anakategori_Btn" runat="server" Text="Kategori Kaydet" CssClass="alt_btn" ValidationGroup="Ana_Kat" OnClick="anakategori_Btn_Click" />
                            </div>
                        </footer>
                        <br />
                        <br />
                    </div>
                </article>
                <div class="clear"></div>
                <article class="module width_full">
                    <header>
                        <h3>alt kategori işlemleri</h3>
                    </header>
                    <div class="module_content">
                        <fieldset>
                            <label class="labelfiel">
                                ana Kategori adı</label>
                            <asp:DropDownList ID="anaKategoriDrop" runat="server" AppendDataBoundItems="true" CssClass="select"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen ana kategoriyi seçiniz."
                                Display="None" ControlToValidate="anaKategoriDrop" ValidationGroup="Alt_Kat"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <fieldset>
                            <label class="labelfiel">
                                Alt Kategori adı</label>
                            <asp:TextBox ID="Alt_KategoriAdibox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen alt kategori adını yazınız."
                                Display="None" ControlToValidate="Alt_KategoriAdibox" ValidationGroup="Alt_Kat"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="btnAltKategori" runat="server" Text="Alt Kategori Kaydet"
                                    CssClass="alt_btn" ValidationGroup="Alt_Kat" OnClick="btnAltKategori_Click" />
                            </div>
                        </footer>
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>


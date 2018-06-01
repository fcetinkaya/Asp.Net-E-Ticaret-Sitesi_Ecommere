<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="HaberSistemi.aspx.cs" Inherits="Rumrum_HaberSistemi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="main" class="column">
        <h4 id="KayitTamam" runat="server" class="alert_success" visible="false">
            <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
        </h4>
        <h4 id="HataVar" runat="server" class="alert_error" visible="false">
            <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
        </h4>
        <article class="module width_full">
            <header>
                <h3>yeni haber kayıt</h3>
            </header>
            <div class="module_content" style="height: auto;">
                <fieldset>
                    <label class="labelfiel">haber başlık</label>
                    <asp:TextBox ID="BaslikBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen başlık yazınız."
                        Display="None" ControlToValidate="BaslikBox" ValidationGroup="Haber"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">haber linki</label>
                    <asp:TextBox ID="LinkBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen haberin link'ni yazınız."
                        Display="None" ControlToValidate="LinkBox" ValidationGroup="Haber"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                        PopupPosition="BottomLeft">
                    </asp:ValidatorCalloutExtender>
                </fieldset>
                <fieldset>
                    <label class="labelfiel">Resim Seçiniz : (1000x360)</label>
                    <label class="labelfiel">
                        <asp:FileUpload runat="server" ID="UploadImages" CssClass="textfield" Width="400px" />
                    </label>
                </fieldset>
                <footer>
                    <div class="submit_link">
                        <asp:Button ID="HaberekleBtn" runat="server" Text="Haberi Kaydet" CssClass="alt_btn" ValidationGroup="Haber" OnClick="HaberekleBtn_Click" />
                    </div>
                </footer>
            </div>
        </article>
        <div class="clear"></div>
        <article class="module width_full">
            <header>
                <h3>kayıtlı haberler</h3>
            </header>
            <div class="module_content">
                <table style="width: 657px" border="0" cellpadding="0" cellspacing="1"
                    class="GridviewTable">
                    <tr>
                        <td style="width: 395px;">BAŞLIK
                        </td>
                        <td style="width: 90px;">SIRALAMA
                        </td>
                        <td style="width: 90px;">İŞLEMLER
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="HaberSlider_Grid" runat="server" AutoGenerateColumns="False" CssClass="Gridview" ShowHeader="false" OnRowCommand="HaberSlider_Grid_RowCommand" DataKeyNames="HaberID" OnRowCancelingEdit="HaberSlider_Grid_RowCancelingEdit" OnRowEditing="HaberSlider_Grid_RowEditing" OnRowUpdating="HaberSlider_Grid_RowUpdating">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="435px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBaslikAdi" runat="server"
                                                Text='<%# Eval("Baslik")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="EditBaslikBox" runat="server" CssClass="textfield" Width="250px"
                                                Text='<%# Eval("Baslik") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen başlık yazınız."
                                                Display="None" ControlToValidate="EditBaslikBox" ValidationGroup="Duzenle"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSira" runat="server"
                                                Text='<%# Eval("sira")%>'></asp:Label>
                                            . Haber
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="EditLinkBox" runat="server" CssClass="textfield" Width="200px"
                                                Text='<%# Eval("Link") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen Link yazınız."
                                                Display="None" ControlToValidate="EditLinkBox" ValidationGroup="Duzenle"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                ToolTip="Düzenle" CommandArgument='<%#Eval ("HaberID") %>' CommandName="Edit" />
                                            &nbsp;&nbsp;
                                            <asp:ImageButton ID="SilBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                ToolTip="Sil" CommandArgument='<%#Eval ("HaberID") %>' CommandName="Sil" /><asp:ConfirmButtonExtender
                                                    ID="ConfirmButtonExtender1" runat="server" TargetControlID="SilBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                                                </asp:ConfirmButtonExtender>
                                            &nbsp;&nbsp;
                                            <asp:ImageButton ID="SiramaBtn" runat="server" ImageUrl="~/Rumrum/images/icn_settings.png" ToolTip="Sıralamayı Değiştir" OnClick="SiramaBtn_Click" AlternateText='<%#Eval ("HaberID") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            &nbsp;&nbsp;
                                        <asp:ImageButton ID="GuncelleBtn" runat="server" ImageUrl="~/RumRum/images/Save.png"
                                            ToolTip="Bilgileri Güncelle" CommandArgument='<%#Eval ("HaberID") %>' CommandName="Update" />
                                            &nbsp;<asp:ImageButton ID="VazgecBtn" runat="server" ImageUrl="~/RumRum/images/Cancel.png"
                                                ToolTip="Vazgeç" CommandArgument='<%#Eval ("HaberID") %>' CommandName="Cancel" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <h4 id="GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Haber Bulunamadı !</h4>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button ID="GosterBtn" runat="server" Style="display: none;" />
            <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="GosterBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Sıralamayı Değiştir
                </div>
                <div class="body">
                    <div id="BilgilerDiv" style="width: 330px; height: 30px; float: left; margin-left: 10px;">
                        <div style="width: 130px; height: 20px; float: left;">
                            <b>Sıra :</b>
                        </div>
                        <div style="width: 200px; height: 20px; float: left;">
                            <asp:DropDownList ID="SiralamaDrop" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="footer" align="right">
                        <asp:Button ID="KaydetBtn" runat="server" Text="Kaydet" CssClass="button" OnClick="KaydetBtn_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                    </div>
                </div>
            </asp:Panel>
        </article>
    </section>
</asp:Content>


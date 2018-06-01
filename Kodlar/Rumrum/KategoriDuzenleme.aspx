<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="KategoriDuzenleme.aspx.cs" Inherits="Rumrum_KategoriDuzenleme" %>

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
                    <div class="module_content">
                        <table style="width: 950px" border="0" cellpadding="0" cellspacing="1"
                            class="GridviewTable">
                            <tr>
                                <td style="width: 700px;">KATEGORİ ADI
                                </td>
                                <td style="width: 200px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="AnaKategori_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="AnaKategoriID" OnPageIndexChanging="AnaKategori_Grid_PageIndexChanging" OnRowCancelingEdit="AnaKategori_Grid_RowCancelingEdit" OnRowEditing="AnaKategori_Grid_RowEditing" OnRowUpdating="AnaKategori_Grid_RowUpdating" OnRowDeleting="AnaKategori_Grid_RowDeleting" CssClass="Gridview" ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="720px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKategoriAdi" runat="server"
                                                        Text='<%# Eval("AnaKategoriAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="EditKategoriAdiBox" runat="server" CssClass="textfield" Width="350px"
                                                        Text='<%# Eval("AnaKategoriAdi") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen kategori adını yazınız."
                                                        Display="None" ControlToValidate="EditKategoriAdiBox" ValidationGroup="Duzenle"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2"
                                                        PopupPosition="BottomLeft">
                                                    </asp:ValidatorCalloutExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                        ToolTip="Düzenle" CommandArgument='<%#Eval ("AnaKategoriID") %>' CommandName="Edit" />
                                                    &nbsp;&nbsp;<asp:ImageButton ID="DeleteBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                        ToolTip="Sil" CommandArgument='<%#Eval ("AnaKategoriID") %>' CommandName="Delete" /><asp:ConfirmButtonExtender
                                                            ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                                                        </asp:ConfirmButtonExtender>

                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    &nbsp;&nbsp;
                                        <asp:ImageButton ID="GuncelleBtn" runat="server" ImageUrl="~/RumRum/images/Save.png"
                                            ToolTip="Bilgileri Güncelle" CommandArgument='<%#Eval ("AnaKategoriID") %>' CommandName="Update" />
                                                    &nbsp;<asp:ImageButton ID="VazgecBtn" runat="server" ImageUrl="~/RumRum/images/Cancel.png"
                                                        ToolTip="Vazgeç" CommandArgument='<%#Eval ("AnaKategoriID") %>' CommandName="Cancel" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />

                                    </asp:GridView>
                                    <h4 id="GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Kategori Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
                <div class="clear"></div>
                <article class="module width_full">
                    <header>
                        <h3>alt kategori işlemleri</h3>
                    </header>
                    <div class="module_content">
                        <table style="width: 953px" border="0" cellpadding="0" cellspacing="1"
                            class="GridviewTable">
                            <tr>
                                <td style="width: 345px;">ANA KATEGORİ ADI
                                </td>
                                <td style="width: 345px;">KATEGORİ ADI
                                </td>
                                <td style="width: 200px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 345px;">
                                    <asp:DropDownList ID="anaKategoriDrop" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="DropDownList" OnSelectedIndexChanged="anaKategoriDrop_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 345px;"></td>
                                <td style="width: 200px;"></td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="AltKategori_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" DataKeyNames="KategoriID" OnPageIndexChanging="AltKategori_Grid_PageIndexChanging" OnRowCancelingEdit="AltKategori_Grid_RowCancelingEdit" OnRowEditing="AltKategori_Grid_RowEditing" OnRowUpdating="AltKategori_Grid_RowUpdating" OnRowDeleting="AltKategori_Grid_RowDeleting" ShowHeader="false" CssClass="Gridview" OnRowDataBound="AltKategori_Grid_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="355px">
                                                <ItemTemplate>
                                                    <asp:Label ID="AltAna_lblKategoriAdi" runat="server"
                                                        Text='<%# Eval("AnaKategoriAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="anaKategoriDrop" runat="server" AppendDataBoundItems="true" CssClass="select"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen kategori seçiniz."
                                                        Display="None" ControlToValidate="anaKategoriDrop" ValidationGroup="Duzenle"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                        PopupPosition="BottomLeft">
                                                    </asp:ValidatorCalloutExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="355px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Alt_lblKategoriAdi" runat="server"
                                                        Text='<%# Eval("KategoriAdi")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="EditKategoriAdiBox" runat="server" CssClass="textfield" Width="350px"
                                                        Text='<%# Eval("KategoriAdi") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen kategori adını yazınız."
                                                        Display="None" ControlToValidate="EditKategoriAdiBox" ValidationGroup="Duzenle"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                        PopupPosition="BottomLeft">
                                                    </asp:ValidatorCalloutExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                        ToolTip="Düzenle" CommandArgument='<%#Eval ("KategoriID") %>' CommandName="Edit" />
                                                    &nbsp;&nbsp;<asp:ImageButton ID="DeleteBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                        ToolTip="Sil" CommandArgument='<%#Eval ("KategoriID") %>' CommandName="Delete" /><asp:ConfirmButtonExtender
                                                            ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                                                        </asp:ConfirmButtonExtender>

                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    &nbsp;&nbsp;
                                        <asp:ImageButton ID="GuncelleBtn" runat="server" ImageUrl="~/RumRum/images/Save.png"
                                            ToolTip="Bilgileri Güncelle" CommandArgument='<%#Eval ("KategoriID") %>' CommandName="Update" />
                                                    &nbsp;<asp:ImageButton ID="VazgecBtn" runat="server" ImageUrl="~/RumRum/images/Cancel.png"
                                                        ToolTip="Vazgeç" CommandArgument='<%#Eval ("KategoriID") %>' CommandName="Cancel" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Alt_GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı alt Kategori  Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AnaKategori_Grid" />
                <asp:AsyncPostBackTrigger ControlID="AltKategori_Grid" />

            </Triggers>
        </asp:UpdatePanel>
    </section>
</asp:Content>


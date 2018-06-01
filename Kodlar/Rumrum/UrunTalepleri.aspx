<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="UrunTalepleri.aspx.cs" Inherits="Rumrum_UrunTalepleri" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function DivKapat() {
            document.getElementById('AramaPopup').style.display = 'none';
            return false;
        }
        function DivAc() {
            document.getElementById('AramaPopup').style.display = 'block';
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="main" class="column">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h4 id="KayitTamam" runat="server" class="alert_success" visible="false">
                    <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
                </h4>
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label></h4>
                <article class="module width_full">
                    <header>
                        <h3>ürün talep bildirimleri</h3>
                    </header>
                    <div class="module_content">
                        <div id="AramaKriter_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="DivAc()">Filtreleme</a>
                        </div>
                        <div id="AramaPopup" class="AramaKriteri_Small">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset>
                                    <label class="labelfiel">
                                        E-Posta Adresi</label>
                                    <asp:TextBox ID="EPostaAdresi_box" runat="server" CssClass="textfield" Width="470px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen e-posta adresini  yazınız."
                                        Display="None" ControlToValidate="EPostaAdresi_box" ValidationGroup="UrunEkle"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                        PopupPosition="BottomLeft">
                                    </asp:ValidatorCalloutExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right; font-size: 13px;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 953px" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 130px;">MÜŞTERİ AD SOYAD
                                </td>
                                <td style="width: 120px;">E-POSTA ADRESİ
                                </td>
                                <td style="width: 260px;">AÇIKLAMA
                                </td>
                                <td style="width: 65px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="AltKategori_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" ShowHeader="false" CssClass="Gridview" OnPageIndexChanging="AltKategori_Grid_PageIndexChanging" OnRowDataBound="AltKategori_Grid_RowDataBound" OnRowCommand="AltKategori_Grid_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMusteriAdi" runat="server"
                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="185px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEpostaAdi" runat="server"
                                                        Text='<%# Eval("Eposta")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="420px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTlf" runat="server"
                                                        Text='<%# Eval("Aciklama")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="95px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="KapatBtn" runat="server" Text="Bildirimi Kapat"
                                                        ToolTip="Bildirimi Kapat" CommandArgument='<%# Eval("HaberdarEtID")%>' CommandName="Kapat">
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="AcBtn" runat="server" Text="Bildirimi Aç"
                                                   ToolTip="Bildirimi Aç" CommandArgument='<%# Eval("HaberdarEtID")%>' CommandName="Ac">
                                                    </asp:LinkButton>
                                                    <asp:ConfirmButtonExtender
                                                        ID="ConfirmButtonExtender1" runat="server" TargetControlID="KapatBtn" ConfirmText="Bildirimi kapatmak istediğinize emin misiniz ?">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Alt_GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Ürün Talebi Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>

</asp:Content>


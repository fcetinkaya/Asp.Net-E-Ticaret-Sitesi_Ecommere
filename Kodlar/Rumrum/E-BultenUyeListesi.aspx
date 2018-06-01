<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="E-BultenUyeListesi.aspx.cs" Inherits="Rumrum_E_BultenUyeListesi" %>

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
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <article class="module width_full">
                    <header>
                        <h3>yeni e-posta kayıt işlemi</h3>
                    </header>
                    <div class="module_content" style="height: auto;">
                        <fieldset>
                            <label class="labelfiel">e-posta adresi</label>
                            <asp:TextBox ID="EpostaAdresiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen e-posta adını yazınız."
                                Display="None" ControlToValidate="EpostaAdresiBox" ValidationGroup="Eposta"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                PopupPosition="BottomLeft">
                            </asp:ValidatorCalloutExtender>
                        </fieldset>
                        <footer>
                            <div class="submit_link">
                                <asp:Button ID="EpostaEkleBtn" runat="server" Text="Adresi Kaydet" CssClass="alt_btn" ValidationGroup="Eposta" OnClick="EpostaEkleBtn_Click" />
                            </div>
                        </footer>
                        <br />
                        <br />
                    </div>
                </article>
                <div class="clear"></div>
                <article class="module width_full">
                    <header>
                        <h3>kayıtlı e-posta listesi {<asp:Label ID="ToplamAdetLbl" runat="server"></asp:Label>}</h3>
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
                                        Ad Soyad</label>
                                    <asp:TextBox ID="Eposta_Arabox" runat="server" CssClass="textfield" Width="470px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen e-posta adresini yazınız."
                                        Display="None" ControlToValidate="Eposta_Arabox" ValidationGroup="Ara"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                        PopupPosition="BottomLeft">
                                    </asp:ValidatorCalloutExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="E-Posta Adresini Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" ValidationGroup="Ara" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right; font-size: 13px;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 720px" border="0" cellpadding="0" cellspacing="1"
                            class="GridviewTable">
                            <tr>
                                <td style="width: 400px;">E-POSTA ADRESİ
                                </td>
                                <td style="width: 200px;">DURUM
                                </td>
                                <td style="width: 100px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="EPostaListesi_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="E_bultenID" OnPageIndexChanging="EPostaListesi_Grid_PageIndexChanging" CssClass="Gridview" ShowHeader="false" PageSize="20" OnRowDataBound="EPostaListesi_Grid_RowDataBound" OnRowCommand="EPostaListesi_Grid_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="420px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEpostaAdresi" runat="server"
                                                        Text='<%# Eval("EPostaAdresi")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Label ID="DurumLbl" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DuzenleBtn" runat="server" ImageUrl="~/Rumrum/images/icn_edit.png"
                                                        ToolTip="Düzenle" CommandArgument='<%#Eval ("E_bultenID") %>' AlternateText='<%# Eval("EPostaAdresi")%>' OnClick="DuzenleBtn_Click" />
                                                    &nbsp;&nbsp;<asp:ImageButton ID="SilBtn" runat="server" ImageUrl="~/Rumrum/images/icn_trash.png"
                                                        ToolTip="E-Posta Adresini Sil" CommandArgument='<%#Eval ("E_bultenID") %>' CommandName="Sil" /><asp:ConfirmButtonExtender
                                                            ID="ConfirmButtonExtender1" runat="server" TargetControlID="SilBtn" ConfirmText="Silmek istediğinize emin misiniz ?">
                                                        </asp:ConfirmButtonExtender>
                                                    <asp:ImageButton ID="EPostaGitsin" runat="server" ImageUrl="~/Rumrum/images/icn_EpostaGitsin.png"
                                                        ToolTip="E-Posta Gitsin" CommandArgument='<%#Eval ("E_bultenID") %>' CommandName="Gitsin" />
                                                    <asp:ImageButton ID="EpostaGitmesin" runat="server" ImageUrl="~/Rumrum/images/icn_EpostaGitmesin.png"
                                                        ToolTip="E-Posta Gitmesin" CommandArgument='<%#Eval ("E_bultenID") %>' CommandName="Gitmesin" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />

                                    </asp:GridView>
                                    <h4 id="GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı E-Posta Adresi Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
                <asp:Button ID="GosterBtn" runat="server" Style="display: none;" />
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="GosterBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                    <div class="header">
                        E-posta Adresi Güncelleme
                    </div>
                    <div class="body">
                        <div id="BilgilerDiv" style="width: 330px; height: 30px; float: left; margin-left: 10px;">
                            <div style="width: 130px; height: 20px; float: left;">
                                <b>E-Posta Adresi :</b>
                            </div>
                            <div style="width: 200px; height: 20px; float: left;">
                                <asp:TextBox ID="Guncelle_EpostaAdresiBox" runat="server" CssClass="textfield" Width="180px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen e-posta adını yazınız."
                                    Display="None" ControlToValidate="Guncelle_EpostaAdresiBox" ValidationGroup="Guncelle"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>

                            </div>
                        </div>
                        <div class="footer" align="right">
                            <asp:Button ID="KaydetBtn" runat="server" Text="Kaydet" CssClass="button" OnClick="KaydetBtn_Click" ValidationGroup="Guncelle" />
                            &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>


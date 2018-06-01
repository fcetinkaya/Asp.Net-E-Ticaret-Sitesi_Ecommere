<%@ Page Title="" Language="C#" MasterPageFile="~/Rumrum/MasterPage.master" AutoEventWireup="true" CodeFile="YeniSiparisler.aspx.cs" Inherits="Rumrum_YeniSiparisler" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Css/FcyazilimCss.css" rel="stylesheet" media="screen, print" />
    <script type="text/javascript">
        function OnClientPopulating(sender, e) {
            sender._element.className = "loading";
        }
        function OnClientCompleted(sender, e) {
            sender._element.className = "";
        }
    </script>
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
    <style type="text/css">
        /*Auto Complete*/
        .AutoExtender {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left: 10px;
        }

        .AutoExtenderList {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }

        .AutoExtenderHighlight {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }

        #divwidth {
            width: 350px !important;
        }

            #divwidth div {
                width: 350px !important;
            }

        #divwidth2 {
            width: 350px !important;
        }

            #divwidth2 div {
                width: 350px !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section id="main" class="column">
                <h4 id="HataVar" runat="server" class="alert_error" visible="false">
                    <asp:Label ID="HataLbl" runat="server"> Hata !! Lütfen bilgileri kontrol edip tekrar deneyiniz !</asp:Label>
                </h4>
                <h4 id="KayitTamam" runat="server" class="alert_success" visible="false">
                    <asp:Label ID="KayitTamamLbl" runat="server"></asp:Label>
                </h4>
                <article class="module width_full">
                    <header>
                        <h3>yeni siparişler listesi {<asp:Label ID="ToplamAdetLbl" runat="server"></asp:Label>}</h3>
                    </header>
                    <div class="module_content">
                        <div id="AramaKriter_Div" style="margin-bottom: 5px; font-size: 13px;">
                            <a href="#" class="alt_btn" onclick="DivAc()">Filtreleme</a>
                        </div>
                        <div id="AramaPopup" class="AramaKriteri_Small_Yukseklik">
                            <div class="AramaKriteri_header">
                                Arama Kriterleri
                            </div>
                            <div class="AramaKriteri_body">
                                <fieldset style="width: 48%; float: left;">
                                    <label class="labelfiel">
                                        sipariş durumu</label>
                                    <asp:DropDownList ID="SiparisDurumuDrop" runat="server" CssClass="select" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </fieldset>
                                <fieldset style="width: 48%; float: left; margin-left: 1%;">
                                    <label class="labelfiel">ödeme şekli</label>
                                    <asp:DropDownList ID="OdemeSekli_Drop" runat="server" CssClass="select" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Selected="True">Lütfen Seçiniz</asp:ListItem>
                                        <asp:ListItem>Tek Çekim Kredi Kartı Ödeme</asp:ListItem>
                                        <asp:ListItem>Taksit ile Kredi Kartı Ödeme</asp:ListItem>
                                        <asp:ListItem>EFT / Havale ile Ödeme</asp:ListItem>
                                        <asp:ListItem>Kapıda Ödeme</asp:ListItem>
                                        <asp:ListItem>Paypal ile Ödeme</asp:ListItem>
                                    </asp:DropDownList>
                                </fieldset>
                                <div class="clear"></div>
                                <fieldset style="width: 48%; float: left;">
                                    <label class="labelfiel">müşteri adı soyadı</label>
                                    <asp:TextBox ID="MusteriAdiBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                                    <div id="divwidt"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender3"
                                        runat="server" ServiceMethod="SearchCustomers"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="MusteriAdiBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                                <fieldset style="width: 48%; float: left; margin-left: 1%;">
                                    <label class="labelfiel">sipariş numarası</label>
                                    <asp:TextBox ID="SiparisNoBox" runat="server" CssClass="textfield" Width="410px"></asp:TextBox>
                                    <div id="divwidth2"></div>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender4"
                                        runat="server" ServiceMethod="SearchCustomers_siparisNo"
                                        MinimumPrefixLength="2"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="10"
                                        TargetControlID="SiparisNoBox"
                                        FirstRowSelected="false"
                                        CompletionListCssClass="AutoExtender"
                                        CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListElementID="divwidth2" OnClientHiding="OnClientCompleted"
                                        OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating">
                                    </asp:AutoCompleteExtender>
                                </fieldset>
                            </div>
                            <div class="AramaKriteri_footer">
                                <div style="width: 50%; float: left; text-align: left;">
                                    <asp:LinkButton ID="AramaBaslatBtn" runat="server" Text="Kriterlere Göre Ara" CssClass="AramaKriteri_button" OnClick="AramaBaslatBtn_Click" />
                                </div>
                                <div style="width: 50%; float: left; text-align: right;">
                                    <a href="#" class="AramaKriteri_button" onclick="DivKapat()">Kapat </a>
                                </div>
                            </div>
                        </div>
                        <table style="width: 960px" border="0" cellpadding="0" cellspacing="1" class="GridviewTable">
                            <tr>
                                <td style="width: 110px;">MÜŞTERİ AD SOYAD
                                </td>
                                <td style="width: 95px;">SİPARİŞ NO / FİYAT
                                </td>
                                <td style="width: 100px;">ÖDEME ŞEKLİ
                                </td>
                                <td style="width: 130px;">SİPARİŞ DURUMU
                                </td>
                                <td style="width: 70px;">SİPARİŞ TARİHİ
                                </td>
                                <td style="width: 70px;">İŞLEMLER
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="Urunler_Grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" OnPageIndexChanging="Urunler_Grid_PageIndexChanging" CssClass="Gridview" ShowHeader="false" OnRowDataBound="Urunler_Grid_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="172px">
                                                <ItemTemplate>
                                                    <asp:Label ID="AdSoyadLbl" runat="server"
                                                        Text='<%# Eval("AdSoyad")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="145px">
                                                <ItemTemplate>
                                                    <%# Eval("SiparisNoFiyat")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="155px">
                                                <ItemTemplate>
                                                    <%# Eval("OdemeTipi")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <%# Eval("DurumAd")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="110px">
                                                <ItemTemplate>
                                                    <%# Eval("SiparisTarihi")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DurumChangeBtn" runat="server" ImageUrl="~/Rumrum/images/iadedegisim.png"
                                                        ToolTip="Sipariş Durumunu Değiştir" CommandArgument='<%# Eval("E_SiparisID")%>' AlternateText=' <%# Eval("DurumAd")%>' OnClick="DurumChangeBtn_Click"></asp:ImageButton>
                                                    <asp:ImageButton ID="UrunlerBtn" runat="server" ImageUrl="~/Rumrum/images/icn_urunler.png"
                                                        ToolTip="Sipariş Ürünleri" CommandArgument='<%# Eval("E_SiparisID")%>' OnClick="UrunlerBtn_Click"></asp:ImageButton>
                                                    <asp:ImageButton ID="KargoBtn" runat="server" ImageUrl="~/Rumrum/images/kargo.png"
                                                        ToolTip="Kargo İşlemleri"></asp:ImageButton>
                                                    <asp:ImageButton ID="KuryeBtn" runat="server" ImageUrl="~/Rumrum/images/kurye.png"
                                                        ToolTip="Kurye İşlemleri"></asp:ImageButton>
                                                    <asp:ImageButton ID="SiparisDetay_Btn" runat="server" ImageUrl="~/Rumrum/images/icn_siparis_detay.png"
                                                        ToolTip="Sipariş Detayı" CommandArgument='<%# Eval("E_SiparisID")%>' AlternateText='<%# Eval("UyeID")%>' OnClick="SiparisDetay_Btn_Click"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="İlk" LastPageText="Son" />
                                    </asp:GridView>
                                    <h4 id="Alt_GridKayitYokDiv" runat="server" class="alert_warning" visible="false">Kayıtlı Sipariş Bulunamadı !</h4>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </article>
            </section>
            <asp:Button ID="GosterBtn" runat="server" Style="display: none;" />
            <asp:ModalPopupExtender ID="DurumGuncelleme_MPE" runat="server" PopupControlID="pnlPopup" TargetControlID="GosterBtn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Sipariş Durumunu Güncelle
                </div>
                <div class="body">
                    <div id="BilgilerDiv" style="width: 330px; height: 130px; float: left; margin-left: 10px;">
                        <div style="width: 130px; height: 20px; float: left;">
                            <b>Sipariş Durumu :</b>
                        </div>
                        <div style="width: 200px; height: 30px; float: left;">
                            <asp:DropDownList ID="Guncelle_SiparisDurumuDrop" runat="server" CssClass="select" Width="200px">
                            </asp:DropDownList>
                        </div>
                        <div style="width: 130px; height: 20px; float: left;">
                            <b>Sipariş Sonucu :</b>
                        </div>
                        <div style="width: 200px; height: 30px; float: left;">
                            <asp:CheckBox ID="TamamDevamCheck" runat="server" Text="Siparişi Kapat" />
                        </div>
                    </div>
                    <div class="footer" align="right">
                        <asp:Button ID="DurumuDegistir_Btn" runat="server" Text="Kaydet" CssClass="button" OnClick="DurumuDegistir_Btn_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Kapat" CssClass="button" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Button ID="UrunlerBtn" runat="server" Style="display: none;" />
            <asp:ModalPopupExtender ID="Urunler_Modal" runat="server" PopupControlID="Urunler_Popup" TargetControlID="UrunlerBtn" CancelControlID="Urunler_btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
            <asp:Panel ID="Urunler_Popup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Sipariş Ürünleri
                </div>
                <div class="body">
                    <div id="UrunlerDiv" style="width: 765px; height: auto; float: left; margin-left: 10px;">
                        <asp:DataList ID="Sepet_Datalist" runat="server" GridLines="Both" OnItemDataBound="Sepet_Datalist_ItemDataBound">
                            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
                            <HeaderTemplate>
                                <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                    Resim
                                </div>
                                <div style="float: left; height: 20px; width: 300px; text-align: left; padding: 5px;">
                                    Ürün Adı
                                </div>
                                <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                    Birim Fiyat
                                </div>
                                <div style="float: left; height: 20px; width: 60px; text-align: center; padding: 5px;">
                                    Adet
                                </div>
                                <div style="float: left; height: 20px; width: 150px; text-align: left; padding: 5px;">
                                    Toplam Tutar
                                </div>
                            </HeaderTemplate>
                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <ItemTemplate>
                                <div style="float: left; height: 50px; width: 100px; text-align: left; padding: 5px;">
                                    <asp:HyperLink ID="Resim" runat="server" NavigateUrl='<%# Eval("link") %>' Target="_blank">
                                        <asp:Image ID="Logo" runat="server" ImageUrl='<%# Eval("resim") %>' alt='<%# Eval("isim") %>' Height="50" Width="100" />
                                    </asp:HyperLink>
                                </div>
                                <div style="float: left; height: 40px; width: 290px; text-align: left; padding: 10px;">
                                    <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("isim") %>' ToolTip='<%# Eval("isim") %>' CssClass="Footer_Link" Target="_blank"></asp:HyperLink>
                                </div>
                                <div style="float: left; height: 40px; width: 90px; text-align: left; padding: 10px;">
                                    <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("fiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>&nbsp;TL
                                </div>
                                <div style="float: left; height: 40px; width: 50px; text-align: center; padding: 10px;">
                                    <asp:TextBox ID="AdetBox" runat="server" Text='<%# Eval("adet") %>' Enabled="false" Width="30px"></asp:TextBox>
                                </div>
                                <div style="float: left; height: 40px; width: 140px; text-align: left; padding: 10px;">
                                    <asp:Label ID="ToplamTutarLbl" runat="server" CssClass="UrunListeItem_YebiFiyatLbl" Text='<%# Eval("toplam") %>'> </asp:Label>&nbsp;TL
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div class="footer" align="right">
                        <asp:Button ID="Urunler_btnClose" runat="server" Text="Kapat" CssClass="button" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Button ID="SiparisDetay_Btn" runat="server" Style="display: none;" />
            <asp:ModalPopupExtender ID="Siparis_Detay_Modal" runat="server" PopupControlID="SiparisDetay_pnlPopup" TargetControlID="SiparisDetay_Btn" CancelControlID="SiparisDetay_btnClose" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
            <asp:Panel ID="SiparisDetay_pnlPopup" runat="server" CssClass="modalPopup" Style="display: none; width:850px; height:600px;" ScrollBars="Horizontal">
                <div class="header">
                    Sipariş Detayı
                </div>
                <div class="body">
                    <div class="Sepet_Baslik">
                        Sipariş Sepeti
                    </div>
                    <div id="siparis_Detayi_Div" style="width: 765px; height: auto; float: left; margin-left: 10px;">
                        <asp:DataList ID="Siparis_DetayDatalist" runat="server" GridLines="Both" OnItemDataBound="Siparis_DetayDatalist_ItemDataBound">
                            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
                            <HeaderTemplate>
                                <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                    Resim
                                </div>
                                <div style="float: left; height: 20px; width: 300px; text-align: left; padding: 5px;">
                                    Ürün Adı
                                </div>
                                <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                    Birim Fiyat
                                </div>
                                <div style="float: left; height: 20px; width: 60px; text-align: center; padding: 5px;">
                                    Adet
                                </div>
                                <div style="float: left; height: 20px; width: 150px; text-align: left; padding: 5px;">
                                    Toplam Tutar
                                </div>
                            </HeaderTemplate>
                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <ItemTemplate>
                                <div style="float: left; height: 50px; width: 100px; text-align: left; padding: 5px;">
                                    <asp:HyperLink ID="Resim" runat="server" NavigateUrl='<%# Eval("link") %>' Target="_blank">
                                        <asp:Image ID="Logo" runat="server" ImageUrl='<%# Eval("resim") %>' alt='<%# Eval("isim") %>' Height="50" Width="100" />
                                    </asp:HyperLink>
                                </div>
                                <div style="float: left; height: 40px; width: 290px; text-align: left; padding: 10px;">
                                    <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("isim") %>' ToolTip='<%# Eval("isim") %>' CssClass="Footer_Link" Target="_blank"></asp:HyperLink>
                                </div>
                                <div style="float: left; height: 40px; width: 90px; text-align: left; padding: 10px;">
                                    <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("fiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>&nbsp;TL
                                </div>
                                <div style="float: left; height: 40px; width: 50px; text-align: center; padding: 10px;">
                                    <asp:TextBox ID="AdetBox" runat="server" Text='<%# Eval("adet") %>' Enabled="false" Width="30px"></asp:TextBox>
                                </div>
                                <div style="float: left; height: 40px; width: 140px; text-align: left; padding: 10px;">
                                    <asp:Label ID="ToplamTutarLbl" runat="server" CssClass="UrunListeItem_YebiFiyatLbl" Text='<%# Eval("toplam") %>'> </asp:Label>&nbsp;TL
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div class="SepetAltKisim">
                        <div class="SepetAltKisim_SepetTutarlar">
                            <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Toplam Ücret :</div>
                            <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                <asp:Label ID="ODeme_SepetFiyatLbl" runat="server"></asp:Label>
                            </div>
                            <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">KDV :</div>
                            <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                <asp:Label ID="Odeme_SepetKDVLbl" runat="server"></asp:Label>
                            </div>
                            <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Kargo Bedeli :</div>
                            <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                <asp:Label ID="Odeme_KargoBedeliLbl" runat="server"></asp:Label>
                            </div>
                            <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Genel Toplam :</div>
                            <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                <asp:Label ID="Odeme_GenelToplamLbl" runat="server"></asp:Label>
                            </div>
                            <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Havale ile Ödeme:</div>
                            <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                <asp:Label ID="Odeme_HavaleOdeme" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="Sepet_Baslik">
                        Adres Bilgileri
                    </div>
                    <div class="Sepet_Iletisim_Sag_Satir">
                        <div class="Hakkimizda_Baslik">Teslimat Adresi</div>
                        <div class="Iletisim_Icerik">
                            <div class="Iletisim_Sag_Satir_Baslik">Ad Soyad</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="AdSoyadLbl" runat="server"></asp:Label>

                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Tc Kimlik No</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="TckimlikNoLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">E-Posta Adresi</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                 <asp:Label ID="EPostaAdresiLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Cep Telefonu</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="CepTelefonLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Telefon</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="TelefonLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Şehir</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="SehirLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">İlçe</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="IlceLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Adres</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="AdresLbl" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="Sepet_Iletisim_Sag_Satir">
                        <div class="Hakkimizda_Baslik">Fatura Adresi</div>
                        <div class="Iletisim_Icerik">
                            <div class="Iletisim_Sag_Satir_Baslik">Yetkili Adı Soyad</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="YetkiliAdSoyadLbl" runat="server"></asp:Label>

                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Firma Adı</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="FirmaAdiLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Vergi Dairesi</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                 <asp:Label ID="VergiDairesiLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Vergi No</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="VergiNoLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Şehir</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="FirmaSehirLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">İlçe</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                : 
                <asp:Label ID="FirmaIlceLbl" runat="server"></asp:Label>
                            </div>
                            <div class="Iletisim_Sag_Satir_Baslik">Adres</div>
                            <div class="Iletisim_Sag_Satir_Icerik">
                                :
                <asp:Label ID="FirmaAdresLbl" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="footer" align="right">
                        <asp:Button ID="SiparisDetay_btnClose" runat="server" Text="Kapat" CssClass="button" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


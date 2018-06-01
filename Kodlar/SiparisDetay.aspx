<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SiparisDetay.aspx.cs" Inherits="SiparisDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Link_FontYok" NavigateUrl="~/SiparisTakibi.aspx">Sipariş Takibi</asp:HyperLink>&nbsp;>
        <asp:Label ID="SiparisNoLbl" runat="server"></asp:Label>
    </div>
    <div class="Sepet_Baslik">
        Sipariş Detayı
    </div>
    <asp:DataList ID="SiparisListesi_DataList" runat="server" GridLines="Both" OnItemDataBound="SiparisListesi_DataList_ItemDataBound">
        <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
        <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
        <HeaderTemplate>
            <div style="float: left; height: 20px; width: 100px; text-align: center; padding: 5px;">
                Sipariş No
            </div>
            <div style="float: left; height: 20px; width: 150px; text-align: center; padding: 5px;">
                Tarih
            </div>
            <div style="float: left; height: 20px; width: 200px; text-align: center; padding: 5px;">
                Ödeme Tipi
            </div>
            <div style="float: left; height: 20px; width: 250px; text-align: center; padding: 5px;">
                Durum
            </div>
            <div style="float: left; height: 20px; width: 140px; text-align: center; padding: 5px;">
                Kargo Takibi
            </div>
        </HeaderTemplate>
        <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
        <ItemTemplate>
            <div style="float: left; height: 30px; width: 100px; text-align: center; padding: 5px;">
                <asp:Label ID="SiparisNoLbl" runat="server" Text='<%# Eval("SiparisNo") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
            </div>
            <div style="float: left; height: 30px; width: 180px; text-align: center; padding: 5px;">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("SiparisTarihi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
            </div>
            <div style="float: left; height: 30px; width: 200px; text-align: center; padding: 5px;">
                <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("OdemeTipi") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
            </div>
            <div style="float: left; height: 30px; width: 250px; text-align: center; padding: 5px;">
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DurumAd") %>' CssClass="UrunListeItem_YebiFiyatLbl"></asp:Label>
            </div>
            <div style="float: left; height: 30px; width: 130px; text-align: center; padding: 5px;">
                <asp:HyperLink ID="DetayID" runat="server" CssClass="Footer_Link" Text="Kargo Takibi"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="Sepet_Baslik">
        Sipariş Sepeti
    </div>
    <asp:DataList ID="Sepet_Datalist" runat="server" GridLines="Both">
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
                <asp:HyperLink ID="Resim" runat="server" NavigateUrl='<%# Eval("link") %>'>
                                <img src='<%# Eval("resim") %>' alt='<%# Eval("isim") %>' height="50" width="100" />
                </asp:HyperLink>
            </div>
            <div style="float: left; height: 40px; width: 290px; text-align: left; padding: 10px;">
                <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("isim") %>' ToolTip='<%# Eval("isim") %>' CssClass="Footer_Link" Target="_blank"></asp:HyperLink>
            </div>
            <div style="float: left; height: 40px; width: 90px; text-align: left; padding: 10px;">
                <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("fiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>&nbsp;TL
            </div>
            <div style="float: left; height: 40px; width: 50px; text-align: center; padding: 10px;">
                <asp:TextBox ID="AdetBox" runat="server" Text='<%# Eval("adet") %>' Width="30px"></asp:TextBox>
            </div>
            <div style="float: left; height: 40px; width: 140px; text-align: left; padding: 10px;">
                <asp:Label ID="ToplamTutarLbl" runat="server" CssClass="UrunListeItem_YebiFiyatLbl" Text='<%# Eval("toplam") %>'> </asp:Label>&nbsp;TL
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="SepetAltKisim_Odeme">
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
        İade / Değişim işlemleri
    </div>
    <div class="Hakkimizda_Icerik">
        Satın almış olduğunuz ürünlerle ilgili <span style="font-weight: bold;">iade ve geri gönderim</span> başvuru işlemleri için lütfen tıklayın.
    </div>
    <div style="clear: both;"></div>
    <asp:Button ID="ListeleBtn" runat="server" CssClass="btn-orange" Text="İade ve Değişim İşlemleri >" PostBackUrl="~/IadeDegisimFormu.aspx" />
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
</asp:Content>

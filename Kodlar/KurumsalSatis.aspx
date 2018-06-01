<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KurumsalSatis.aspx.cs" Inherits="KurumsalSatis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Kurumsal Satış
    </div>
    <div class="Hakkimizda_Baslik">
        Toptan Satış Şartları
    </div>
    <div class="Hakkimizda_Icerik">
        Kurumsal müşteri olarak,
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>
        şirketinden aksesuar, batarya,telefon vs gibi ürünler toplu alım yapabilirler.<br />

        Firmaların "Kurumsal Müşteri" olarak işlem yapabilmesi için, öncelikle tarafımıza  müracaat etmeleri gerekmektedir.<br />
        Kurumsal müşteri temsilcimize <span style="font-weight: bold;">
            <asp:Label ID="TelefonLbl" runat="server"></asp:Label></span> nolu telefondan ulaşabilir, kurumsal toptan siparişlerinizi kolayca oluşturabilirsiniz.<br />
        Başvuru
        <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label>
        tarafından değerlendirilir ve başvuru sonucu olumlu /olumsuz başvuru sahibine en kısa sürede bildirilir.<br />
        <div class="Hakkimizda_Baslik">
            Kurumsal Müşterilerimiz
        </div>
        Sitemizde satılan tüm ürünler için, model ve tipine göre çeşitli indirimlerden faydalanırlar.<br />
        Kurumsal müşterilerimiz, sitede yayınlanan her bir üründen toplu olarak sipariş verebilirler.
        <br />
        Kurumsal üyeler çalışma süresi içinde firmamızla karşılıklı belirlenecek hedef taahhütleri oranında ekstra indirimlerden faydalanabilirler.<br />
    </div>
    <div class="Hakkimizda_Baslik">Sipariş</div>
    <div class="Hakkimizda_Icerik">
        Siparişiniz, hafta içi günlerde 15:00’a kadar kesinleştiği takdirde stok durumuna göre ertesi gün kargoya verilir. Hafta sonu ve resmi tatil günlerinde geçilen siparişler, takip eden ikinci iş günü içinde kargoya teslim edilir.
    </div>
    <div class="Hakkimizda_Baslik">Ürünler</div>
    <div class="Hakkimizda_Icerik">
        Şirketimiz tarafından satılan; batarya, kulaklık, şarj aleti, data kablosu, kapak gibi tüm ürünler %100 orijinaldir. İthalatı sırasında ana distribütör firmalar tarafından denetlenerek orijinalliği tescil edilmektedir.
    </div>
    <div class="Hakkimizda_Baslik">Paketleme ve Ambalajlama</div>
    <div class="Hakkimizda_Icerik">
        Ürünlerimiz,
        <asp:Label ID="WebSitesiLbl3" runat="server"></asp:Label>
        özel ambalajında satılmaktadır.
        <asp:Label ID="WebSitesiLbl4" runat="server"></asp:Label>
        ambalajında yer alan tüm ürünlerin üzerinde şirketimizin logolu etiketi bandrol olarak yer almaktadır. Özellikle iade ve değişim işlemlerinde ürün üzerinde yer alan bandrolün sökülmemiş, ambalajının zarar görmemiş olması gerekmektedir. Şirketimizin kendi EPEE markası ile satılan çeşitli kılıf modelleri kendi ambalajında sunulmaktadır.
    </div>
    <div class="Hakkimizda_Baslik">Ödeme İşlemleri</div>
    <div class="Hakkimizda_Icerik">
        Kurumsal Üyeler havale, kredi kartı tek çekim ve Paypal olmak üzere 3 şekilde ödeme yapabilirler..
    </div>
    <div class="Hakkimizda_Baslik">Döviz Kurları</div>
    <div class="Hakkimizda_Icerik">
        Sitemizde teşhir edilen ürün fiyatları, dolar kurundaki artış ve azalışa göre dönemsel olarak revize edilmektedir. Cepeksen ürün fiyatlarını istediği zaman değiştirme hakkına sahiptir.
    </div>
    <div class="Hakkimizda_Baslik">Garanti Şartları</div>
    <div class="Hakkimizda_Icerik">
        Şirketimiz tarafından satılan tüm ürünler, şirketimizin garantisi altındadır. Ürünlerle birlikte gönderilen irsaliyeli faturalar aynı zamanda garanti belgesi yerine geçmektedir. Ürünlerle ilgili garanti şartları, ürün ambalajının üzerinde yer almaktadır.
    </div>
    <div class="Hakkimizda_Baslik">Kargo Takibi</div>
    <div class="Hakkimizda_Icerik">
        Şirketimiz, özel anlaşmalı fiyatlarla Aras kargo şirketi ile çalışmaktadır.  Toplu alımlarda, toplamı 100 TL ve üzeri siparişlerde kargo bedeli ücretsizdir. 
    </div>
    <div class="Hakkimizda_Baslik">İade İşlemleri</div>
    <div class="Hakkimizda_Icerik">
        Kurumsal satışlarda iade işleminde, (Ayıplı ürünler hariç) ürünün ambalajı açılmamış, zarar görmemiş ve ürünün üzerinde yer alan Cepeksen bandrolünün sökülmemiş olması gerekmektedir. İade, kargo bedeli müşteri tarafından ödenmek şartıyla 10 gün içinde yapılır.<br />
        <br />
        <span style="font-weight: bold;">
            <asp:Label ID="WebSitesiLbl5" runat="server"></asp:Label>
            bireysel ve kurumsal üyelikleri, indirim oranlarını, sebep göstermeksizin değiştirebilir  ve/veya  sonlandırabilir.
        </span>
    </div>

</asp:Content>


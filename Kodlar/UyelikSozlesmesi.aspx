<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UyelikSozlesmesi.aspx.cs" Inherits="UyelikSozlesmesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Üyelik Sözleşmesi
    </div>
    <div class="Hakkimizda_Baslik">
        Site Üyelik Sözleşmesi ve Gizlilik Bildirimi
    </div>
    <div class="Hakkimizda_Icerik">
        Bu internet sitesine girmeniz veya bu internet sitesindeki herhangi bir bilgiyi kullanmanız aşağıdaki koşulları kabul ettiğiniz anlamına gelir.
        <br />
        <br />
        Bu internet sitesine girilmesi, sitenin ya da sitedeki bilgilerin ve diğer verilerin, programların vs. kullanılması sebebiyle, sözleşmenin ihlali, haksız fiil, ya da başkaca sebeplere binaen, doğabilecek doğrudan ya da dolaylı hiçbir zarardan
        <asp:Label ID="SirketAdiLbl" runat="server"></asp:Label>
        ("<asp:Label ID="BuyukIsimLbl" runat="server"></asp:Label>") sorumlu değildir.
        <asp:Label ID="BuyukIsimLbl2" runat="server"></asp:Label>, sözleşmenin ihlali, haksız fiil, ihmal veya diğer sebepler neticesinde; işlemin kesintiye uğraması, hata, ihmal, kesinti hususunda herhangi bir sorumluluk kabul etmez.
        <br />
        <br />
        Gizlilik Bildirimi, sözleşmenin ihlali, haksız fiil, ihmal veya diğer sebepler neticesinde; işlemin kesintiye uğraması, hata, ihmal, kesinti, silinme, kayıp, işlemin veya iletişimin gecikmesi, bilgisayar virüsü, iletişim hatası, hırsızlık, imha veya izinsiz olarak kayıtlara girilmesi, değiştirilmesi veya kullanılması hususunda herhangi bir sorumluluk kabul etmez.
        <br />
        <br />
        Bu internet sitesi
        <asp:Label ID="BuyukIsimLbl3" runat="server"></asp:Label>'un kontrolü altında olmayan başka internet sitelerine bağlantı veya referans içerebilir.
        <asp:Label ID="BuyukIsimLbl4" runat="server"></asp:Label>, bu sitelerin içerikleri veya içerdikleri diğer bağlantılardan sorumlu değildir.
        <asp:Label ID="BuyukIsimLbl5" runat="server"></asp:Label>
        işbu site ve site uzantısında mevcut her tür hizmet, ürün, siteyi kullanma koşulları ile sitede sunulan bilgileri önceden bir ihtara gerek olmaksızın değiştirme, siteyi yeniden organize etme, yayını durdurma hakkını saklı tutar. Değişiklikler sitede yayım anında yürürlüğe girer. Sitenin kullanımı ya da siteye giriş ile bu değişiklikler de kabul edilmiş sayılır. Bu koşullar link verilen diğer web sayfaları için de geçerlidir. 
        <br />
        <br />
        <asp:Label ID="BuyukIsimLbl6" runat="server"></asp:Label>
        bu internet sitesinin genel görünüm ve dizaynı ile internet sitesindeki tüm bilgi, resim,
        <asp:Label ID="BuyukIsimLbl7" runat="server"></asp:Label>
        markası ve diğer markalar,
        <asp:Label ID="WebSitesiLbl4" runat="server"></asp:Label>
        alan adı, logo, ikon, demonstratif, yazılı, elektronik, grafik veya makinede okunabilir şekilde sunulan teknik veriler, bilgisayar yazılımları, uygulanan satış sistemi, iş metodu ve iş modeli de dahil tüm materyallerin ("Materyaller") ve bunlara ilişkin fikri ve sınai mülkiyet haklarının sahibi veya lisans sahibidir ve yasal koruma altındadır. Internet sitesinde bulunan hiçbir materyal; önceden izin alınmadan ve kaynak gösterilmeden, kod ve yazılım da dahil olmak üzere, değiştirilemez, kopyalanamaz, çoğaltılamaz, başka bir lisana çevrilemez, yeniden yayımlanamaz, başka bir bilgisayara yüklenemez, postalanamaz, iletilemez, sunulamaz ya da dağıtılamaz. İnternet sitesinin bütünü veya bir kısmı başka bir internet sitesinde izinsiz olarak kullanılamaz. Aksine hareketler hukuki ve cezai sorumluluğu gerektirir.
        <asp:Label ID="BuyukIsimLbl15" runat="server"></asp:Label>'un burada açıkça belirtilmeyen diğer tüm hakları saklıdır. 
        <br />
        <br />
        İşbu kullanıcı üyelik sözleşmesinde belirlenen ve <asp:Label ID="WebSitesiLbl5" runat="server"></asp:Label> tarafından tek taraflı olarak belirlenecek amaçlar dışında kullanıcı tarafından
        <asp:Label ID="BuyukIsimLbl8" runat="server"></asp:Label>
        hesabının gerek
        <asp:Label ID="BuyukIsimLbl14" runat="server"></asp:Label>'i gerekse de üçüncü kişileri zarara uğratacak şekilde kullanılması ve/veya
        <asp:Label ID="BuyukIsimLbl9" runat="server"></asp:Label>'in ticari itibarının kullanıcının eylemlerinden dolayı zarar görmesi halinde
        <asp:Label ID="BuyukIsimLbl16" runat="server"></asp:Label>, kullanıcının üyeliğini derhal iptal etme, kullanıcıya karşı gerek adli gerekse idari her türlü merciye başvurma hakkına sahiptir.
        <br />
        <br />
        <asp:Label ID="BuyukIsimLbl10" runat="server"></asp:Label>, dilediği zaman bu yasal uyarı sayfasının içeriğini güncelleme yetkisini saklı tutmaktadır ve kullanıcılarına siteye her girişte yasal uyarı sayfasını ziyaret etmelerini tavsiye etmektedir.
    </div>
    <div class="Hakkimizda_Baslik">
        Gizlilik Bildirimi
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>, siz müşterilerine daha iyi hizmet verebilmek için kişisel bilgilerinizi (isim, yaş, adres, firma bilgisi vs. ) sizlerden talep etmektedir. Müşterinin sisteme girdiği tüm bilgilere sadece Müşteri ulaşabilmekte ve bu bilgileri sadece müşteri değiştirebilmektedir. Bir başkasının bu bilgilere ulaşması ve bunları değiştirmesi mümkün değildir. Yasal olarak belirlenen çerçevede toplanan ve saklanan bu bilgiler, müşteri profillerine yönelik özel promosyon faaliyetlerinin kurgulanması ve istenmeyen e-postaların iletilmemesine yönelik müşteri "sınıflandırma" çalışmaları için sadece
        <asp:Label ID="BuyukIsimLbl17" runat="server"></asp:Label>
        tarafından kullanılmaktadır.
    <br />
        <br />
        <asp:Label ID="BuyukIsimLbl11" runat="server"></asp:Label>, alışveriş süresince topladığı bilgileri, müşterinin haberi ya da aksi bir talimatı olmaksızın, üçüncü şahıslarla kesinlikle paylaşmamakta, faaliyet dışı hiçbir nedenle ticari amaçla kullanmamakta ve satmamaktadır. 
        <asp:Label ID="BuyukIsimLbl12" runat="server"></asp:Label>'den gönderilen maillerin alt kısmında bulunan "
        <asp:Label ID="BuyukIsimLbl13" runat="server"></asp:Label>
        e-bültenini almak istemiyorsanız lütfen tıklayınız" linkine tıklayarak mail gönderim listesinden kolayca çıkabilirsiniz.
    <br />
        <br />
        Müşterinin sisteme girdiği tüm bilgilere sadece Müşteri ulaşabilmekte ve bu bilgileri sadece Müşteri değiştirebilmektedir. Bir başkasının bu bilgilere ulaşması ve bunları değiştirmesi mümkün değildir.
    <br />
        <br />
        Müşteri bilgileri, ancak resmi makamlarca usulü dairesinde bu bilgilerin talep edilmesi halinde ve yürürlükteki emredici mevzuat hükümleri gereğince resmi makamlara açıklama yapmak zorunda olduğu durumlarda resmi makamlara açıklanabilecektir.
    <br />
        <br />
        Ödeme sayfasında istenen kredi kartı bilgileriniz, siteden alışveriş yapan siz değerli müşterilerimizin güvenliğini en üst seviyede tutmak amacıyla hiçbir şekilde
        <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label>
        veya ona hizmet veren şirketlerin sunucularında tutulmamaktadır. Bu şekilde ödemeye yönelik tüm işlemlerin
        <asp:Label ID="WebSitesiLbl3" runat="server"></asp:Label>
        arayüzü üzerinden banka ve bilgisayarınız arasında gerçekleşmesi sağlanmaktadır.
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SatisSozlesmesi.aspx.cs" Inherits="SatisSozlesmesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        SATIŞ SÖZLEŞMESİ
    </div>
    <div class="Hakkimizda_Icerik">
        <span style="font-weight: bold;">DİKKAT:</span> Lütfen aşağıdaki sözleşme metnini yazdırıp okuyunuz. İnternet sitemize üye olup, alışveriş yapan herkes, aşağıdaki satış sözleşmesinin tüm maddelerini, başka bir ihbara gerek kalmadan okumuş ve kabul etmiş sayılır.<br />
        <br />
        Bu sözleşme, 13.06.2003 tarih ve 25137 sayılı Resmi Gazetede yayınlanan Mesafeli Sözleşmeler Uygulama Usul ve Esasları Hakkında Yönetmelik gereği internetten gerçekleştiren satışlar için sözleşme yapılması zorunluluğuna istinaden düzenlenmiş olup, maddeler halinde aşağıdaki gibidir. Siparişin sonuçlanması durumunda TÜKETİCİ bu sözleşmenin tüm koşullarını kabul etmiş sayılır.ulaşabilirsiniz.
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 1- TARAFLAR 
    </div>
    <div class="Hakkimizda_Icerik">
        <span style="font-weight: bold;">1.A- SATICI:</span>
        <br />
        <br />
        Ünvan : <asp:Label ID="SirketAdiLbl" runat="server"></asp:Label>
        <br />
        Web adres : <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>
        <br />
        Adres : <asp:Label ID="AdresLbl" runat="server"></asp:Label>
        <br />
        Telefon : <asp:Label ID="TelefonLbl" runat="server"></asp:Label>
        <br />
        Faks : <asp:Label ID="FaksLbl" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <span style="font-weight: bold;">1.B- ALICI:</span>
        <br />
        Adı/Soyadı/Ünvanı:
        <br />
        Adresi:
        <br />
        Telefon:
        <br />
        E-Posta:
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 2- KONU
    </div>
    <div class="Hakkimizda_Icerik">
        İşbu sözleşmenin konusu, ALICI'nın SATICI'ya ait <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label> &nbsp;internet sitesinden elektronik ortamda siparişini yaptığı aşağıda nitelikleri ve satış fiyatları belirtilen ürün/ürünlerin satişi ve teslimi ile ilgili olarak 4077 sayılı Tüketicilerin Korunması Hakkındaki Kanun ve Mesafeli Sözleşmeleri Uygulama Esas ve Usulleri Hakkında Yönetmelik hükümleri gereğince tarafların hak ve yükümlülüklerinin saptanmasıdır.
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 3- SÖZLEŞME KONUSU ÜRÜN
    </div>
    <div class="Hakkimizda_Icerik">
        Ürünlerin Cinsi ve Türü, Miktarı, Marka/Modeli, Rengi aşağıda belirtildiği gibidir.
        <br />
        Ödeme Şekli:
        <br />
        Teslimat Adresi:
        <br />
        Teslim Edilecek Kişi:
        <br />
        Fatura Adresi:
        <br />
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 4- GENEL HÜKÜMLER
    </div>
    <div class="Hakkimizda_Icerik">
        4.1- ALICI, SATICI internet sitesinde sözleşme konusu ürünlerin temel nitelikleri, satış fiyatı ve ödeme şekli ile teslimata ilişkin ön bilgileri okuyup bilgi sahibi olduğunu ve elektronik ortamda gerekli teyidi verdigini beyan eder.
        <br />
        4.2- Sözleşme konusu ürün, yasal 30 günlük süreyi aşmamak koşulu ile her bir ürün için ALICI'nın yerleşim yerinin uzaklığına bağlı olarak internet sitesinde ön bilgiler içinde açıklanan süre içinde ALICI veya gösterdiği adresteki kişi/kuruluşa teslim edilir.
        <br />
        4.3- SATICI, sözleşme konusu ürünün sağlam, eksiksiz, siparişte belirtilen niteliklere uygun ve varsa garanti belgeleri ve kullanım kılavuzları ile teslim edilmesinden sorumludur.
        <br />
        4.4- SATICI, sözleşme konusu ürünün sağlam, eksiksiz, siparişte belirtilen niteliklere uygun ve varsa garanti belgeleri ve kullanım kılavuzları ile teslim edilmesinden sorumludur.
        <br />
        4.5- Sözleşme konusu ürünün teslimatı için ürün(ler) bedelinin ALICI'nın tercih ettiği ödeme şekli ile ödenmiş olması şarttır. Herhangi bir nedenle ürün bedeli ödenmez veya banka kayıtlarında iptal edilir ise, SATICI ürünün teslimi yükümlülüğünden kurtulmuş kabul edilir.
        <br />
        4.6- Ürünün tesliminden sonra ALICI'ya ait kredi kartının ALICI'nın kusurundan kaynaklanmayan bir sekilde yetkisiz kişilerce haksız veya hukuka aykırı olarak kullanılması nedeni ile ilgili banka veya finans kuruluşun ürün bedelini SATICI'ya ödememesi halinde, ALICI'nın kendisine teslim edilmiş olması kaydıyla ürünün 3 gün içinde SATICI'ya gönderilmesi zorunludur. Bu takdirde nakliye giderleri ALICI'ya aittir.
        <br />
        4.7- SATICI mücbir sebepler veya nakliyeyi engelleyen hava muhalefeti, ulaşımın kesilmesi gibi olağanüstü durumlar nedeni ile sözleşme konusu ürünü süresi içinde teslim edemez ise, durumu ALICI'ya bildirmekle yükümlüdür. Bu takdirde ALICI siparişin iptal edilmesini, sözleşme konusu ürünün varsa emsali ile değiştirilmesini, ve/veya teslimat süresinin engelleyici durumun ortadan kalkmasına kadar ertelenmesi haklarından birini kullanabilir. ALICI'nın siparişi iptal etmesi halinde ödediği tutar 10 gün içinde kendisine nakten ve defaten ödenir.
        <br />
        4.8- Garanti belgesi ile satılan ürünlerden olan veya olmayan ürünlerin arızalı veya bozuk olanları, garanti şartları içinde gerekli onarımın yapılması için SATICI'ya gönderilebilir, bu takdirde kargo giderleri SATICI tarafından karşılanacaktır.
        <br />
        4.9- Tipografi hatalar ve yanlış fiyat girilmesinden firmamız sorumlu tutulamaz.
        <br />
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 5- CAYMA HAKKI

    </div>
    <div class="Hakkimizda_Icerik">
        ALICI, sözleşme konusu ürünün kendisine veya gösterdigi adresteki kişi/kuruluşa tesliminden itibaren 10 gün içinde cayma hakkına sahiptir. Cayma hakkının kullanılması için bu süre içinde SATICI'ya faks, email veya telefon ile bildirimde bulunulması ve ürünün 6. madde hükümleri çerçevesinde kullanılmamış olması şarttır. Bu hakkın kullanılması halinde, 3. kişiye veya ALICI'ya teslim edilen ürünün SATICI'ya gönderildiğine dair kargo teslim tutanağı örneği ile fatura aslının iadesi zorunludur. Bu belgelerin ulasmasını takip eden 7 gün içinde ürün bedeli ALICI'ya iade edilir. Fatura aslı gönderilmez ise KDV ve varsa sair yasal yükümlülükler iade edilemez. Cayma hakkı nedeni ile iade edilen ürünün kargo bedeli ALICI tarafından karşılanır.
    </div>
    <div class="SatisSozlesmesi_Baslik">
        MADDE 6- CAYMA HAKKI KULLANILAMAYACAK ÜRÜNLER
    </div>
    <div class="Hakkimizda_Icerik">
        Niteliği itibariyle iade edilemeyecek ürünler, tek kullanımlık ürünler, kopyalanabilir yazılım ve programlar, hızlı bozulan veya son kullanım tarihi geçen ürünler için cayma hakkı kullanılamaz. Aşağıdaki ürünlerde cayma hakkının kullanılması, ürünün ambalajının açılmamış, bozulmamış ve ürünün kullanılmamış olması şartına bağlıdır.
        <br />
        <br />
        - Her türlü yazılım ve programlar
        <br />
        - DVD, VCD, CD ve kasetler
        <br />
        - Bilgisayar ve kırtasiye sarf malzemeleri (toner, kartuş, şerit v.b)
        <br />
        - Hür türlü kozmetik ve sağlık ürünleri
    </div>

    <div class="SatisSozlesmesi_Baslik">
        MADDE 7- YETKİLİ MAHKEME
    </div>
    <div class="Hakkimizda_Icerik">
        İşbu sözleşmenin uygulanmasında, Sanayi ve Ticaret Bakanlığınca ilan edilen değere kadar Tüketici Hakem Heyetleri ile ALICI'nın veya SATICI'nın yerleşim yerindeki Tüketici Mahkemeleri yetkilidir.
        <br />
        Siparişin gerçekleşmesi durumunda ALICI işbu sözleşmenin tüm koşullarını kabul etmiş sayılır.
    </div>
</asp:Content>


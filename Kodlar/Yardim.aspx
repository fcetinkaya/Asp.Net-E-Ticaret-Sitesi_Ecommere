<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Yardim.aspx.cs" Inherits="Yardim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Accordion/js/modernizr.custom.29473.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="ac-container">
        <div id="BilgiHizmetleriDiv">
            <input id="ac-1" name="accordion-1" type="radio" checked />
            <label for="ac-1">BİLGİ HİZMETLERİ</label>
            <article class="ac-large">
                <p><span style="font-weight: bold;">Ürün Arama:</span></p>
                Sitemizde aradığınız ürüne en kısa şekilde ulaşmak için 3 yöntem tanımlıdır.
                 <p>
                     <span style="font-weight: bold;">1) Genel Arama Motoru:</span>
                 </p>
                Sitemizin sağ üst köşesindedir. Site içinde aradığınız ürün hakkında, arama motorunda ürün ile ilgili kısa bilgi yazarak ürüne ulaşmanızı sağlar. Örn:"Iphone 5S Kılıf"
                <p>
                    <span style="font-weight: bold;">2) Kategori Bazında Ürün Arama:</span>
                </p>

                Sitemizde üst menüde yer alan bölümde, ürünler 13 farklı kategoride sınıflandırımıştır. Aradığınız ürün kılıf kategorisinde ise, ilgili "KILIFLAR" menüsü üstüne gelip, marka bazında sınıflanmış tüm kılıflara kolayca ulaşabilirsiniz.
                <p>
                    <span style="font-weight: bold;">3) Marka Bazında Arama:</span>
                </p>
                Sitemizde üst menüde yer alan bölümde, telefonunuzun markasına uygun ürün çeşitliliğini kolayca görebilirsiniz. Aradığınız ürün için ilgili menü üzerine gelip sonrasında telefon markası linkine tıklamanız yeterlidir. Eğer telefon modeliniz yok ise "Diğer Markalar" seçeneğini seçerek, açılan sayfada telefon modelinizi seçebilirsiniz.
 <p>
     <span style="font-weight: bold;">En Çok Satanlar</span>
 </p>

                En çok satanlar; sitemizde en fazla satılan ürünleri gösteren bölümdür. Hangi ürünlerin daha çok tercih edildiğini bu bölümden takip edebilirsiniz. Bu bölüm sitemizde günlük olarak güncellenmektedir. Bu bölüme sitemizin ana sayfasında yer alan vitrin ürünlerinin yer aldığı bölümdeki "ÇOK SATILANLAR" başlığından ulaşabilirsiniz.
                <p>
                    <span style="font-weight: bold;">Kampanyalar / İndirimdekiler</span>
                </p>
                Üyelerimiz için, İndirimdekiler; sitemizde satılan ve sonradan fiyatlarında değişiklik yapılarak indirime girmiş olan ürünlerimizin listesidir. Sitemizde satılmakta olan tüm indirimli ürünlere ana sayfamızda ürün vitrininde bulunan "Kampanyalar / İndirimdekiler" başlığından ulaşabilirsiniz.
                <p>
                    <span style="font-weight: bold;">Ürünler Hakkında Kullanıcı Yorumları</span>
                </p>
                Ürünün detay sayfasına girdiğinizde ürünün fiyat bilgilerinin yan tarafında "YORUMLAR" linkimizi tıklayarak, o ürün hakkında sitemizde yayınlanmış olan tüm yorumları okuyabilirsiniz. Sitemize ücretsiz üye olduktan sonra sitemizde yer alan tüm ürünler ile ilgili sizler de yorum yapabilirsiniz. Yorum yapan üyemizin yorumu ile birlikte ; Adı, Soyadı ve il bilgileri yayımlanır.
 
            </article>
        </div>
        <div id="UyelikDiv">
            <input id="ac-2" name="accordion-1" type="radio" />
            <label for="ac-2">ÜYELİK</label>
            <article class="ac-Uyelik">
                <p>
                    <span style="font-weight: bold;">Üyelik Avantajları</span>
                </p>
                Sitemizde üye olduğunuz zaman indirimlerden ve kampanyalardan haberdar olursunuz.
                <p>
                    <span style="font-weight: bold;">Şifremi Unuttum</span>
                </p>
                Eğer üyelik şifrenizi unuttuysanız;<br />
                Sayfanın sağ üst köşesinde bulunan "Üye Ol" linkine tıkladıktan sonra açılan sayfadan "Şifremi Unuttum" linkine tıklayınız. Alt kısımda çıkıcak olan kutuya e-posta adresininizi yazın ve "Gönder" butonuna basın. Sonrasında şifreniz yazmış olduğunuz e-posta adresinize gönderilecektir.
                 <p>
                     <span style="font-weight: bold;">Üyelik Bilgilerimi Nasıl Değiştirebilirim ?</span>
                 </p>
                Üyelik bilgilerinizde değişiklik yapabilmeniz için öncelikle siteye giriş yapmalısınız. Daha sonra sitemizde bulunan "Hesabım" linkimizin içindeki "Üye İşlemleri" başlığında, güncellemek istediğiniz bölümü seçebilir ve istediğiniz değişiklikleri yapabilirsiniz.
                  <p>
                      <span style="font-weight: bold;">Üyelik Ücretli mi ?</span>
                  </p>
                Sitemizde üyelik ücreti talep edilmemektedir. Sitemize ücretsiz üye olarak, ilgi alanınızdaki ürünler hakkında yenilikler ve kampanyalardan haberdar edilirsiniz.
                <p>
                    <span style="font-weight: bold;">Nasıl Üye olabilirim ?</span>
                </p>
                Sitemize ücretsiz üye olabilmeniz için ana sayfamızda bulunan; "Üye Ol" kayıt linkine tıklayınız. Açılan sayfada bulunan kayıt formunu eksiksiz olarak doldurmanız ve en altta bulunan "KAYIT OL" butonunu tıklamanız gerekmektedir.
            </article>
        </div>
        <div id="SiparisOlusturmakDiv">
            <input id="ac-3" name="accordion-1" type="radio" />
            <label for="ac-3">SİPARİŞ OLUŞTURMAK</label>
            <article class="ac-siparis">
                <p>
                    <span style="font-weight: bold;">Hangi Kargo Şirketi Ürünümü getirecek? Kargo Ücretsiz mi ?</span>
                </p>
                Firmamız
                <asp:Label ID="KargoLbl" runat="server"></asp:Label>
                ile çalışmaktadır. Kargo ücreti, siparişinizin tutarına göre değişir. Bireysel Üye Müşterilerimizden
                <asp:Label ID="UcretsizKargoBedeliLbl" runat="server"></asp:Label>
                (KDV HARİÇ) ve üzeri siparişlerde kargo bedeli firmamızca alınmaz. İade kargo bedeli (ayıplı mallar hariç) müşteri tarafından karşılanır.
              <p>
                  <span style="font-weight: bold;">Sitenizden nasıl sipariş verebilirim?</span>
              </p>
                Öncelikle sitemize üye olmanız gerekmektedir. Üyelik işlemlerinizi tamamladıktan sonra bireysel üyelerimiz hemen alışverişe başlayabilir. Satın almak istediğiniz ürünleri, sepetinize ekleyerek alışverişlerini yapabilirler. Ürünleri sepetinize ekledikten sonra, Satın Al butonu ile bir sonraki ekrana geçebilir, teslimat ve fatura adres bilgilerinizi teyit ettikten sonra, ödeme ekranına gelebilirsiniz.
              <p>
                  <span style="font-weight: bold;">Ödeme Seçenekleri Nelerdir ?</span>
              </p>
                Tüm Kredi Kartları ile Tek Çekim Ödeme
                <br />
                Bonus ve World özellikli Tüm Kredi Kartları ile Taksitli Ödeme
                <br />
                Garanti ve Yapı Kredi Bankası ile Havale / Diğer Tüm bankalar dan EFT ödeme
                <br />
                Paypal ile ödeme
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                Kapıda Nakit Ödeme
                <br />
                <br />
                Ödeme ekranında sunulan ödeme seçeneklerinden birisini seçerek ödemenizi yapabilirsiniz.<br />
                Tüm ödeme seçeneklerinin sonunda "siparişi onayla" butonu ile siparişinizi tamamlarsınız. Sistem siparişinizi takip etmeniz için size bir sipariş numarası verir.<br />
                Bu referans numarası ile siparişinizin hangi aşamada olduğunu takip edebilirsiniz.<br />
                <br />
                Bireysel üyelerimiz siparişlerini havale veya eft ile yaparlar ise, MUTLAKA Benim sayfamda, Sipariş Takip bölümde bulunan "Ödeme bildirim Formunu" doldurarak bizi bilgilendirmelidir. Aksi takdirde siparişleri kargolanamayacaktır.<br />
                <br />
                Bireysel üyelerimiz Kapıda Ödeme seçeneği ile alışveriş yaparlar ise öncelikle telefon ile aranır ve sipariş teyidi yapılır. Telefon ile teyit edilmeyen siparişler kargolanmaz.<br />
                <br />
                <p>
                    <span style="font-weight: bold;">Havale siparişi için banka hesap numaralarınız :</span>
                </p>
                <div class="Hakkimizda_Satir">
                    <asp:Repeater ID="BankaRepeater" runat="server">
                        <ItemTemplate>
                            <div class="Hakkimizda_Sol_Satir">
                                <div class="Hakkimizda_Logo">
                                    <img src='<%# Eval("Logo","img/Banka_Hesap/{0}") %>' alt='<%# Eval("BankaAdi")%>' />
                                </div>
                                <div class="Hakkimizda_Yazi">
                                    <div class="Hakkimizda_Baslik">
                                        <asp:Label ID="BankaAdiLbl" runat="server" Text='<%# Eval("BankaAdi") %>'></asp:Label>
                                    </div>
                                    <div class="Hakkimizda_Icerik">
                                        <asp:Label ID="FirmaAdiLbl" runat="server" Text='<%# Eval("FirmaAdi") %>'></asp:Label>

                                        <br />
                                        <asp:Label ID="SubeAdiLbl" runat="server" Text='<%# Eval("SubeAdi") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="HesapNoLbl" runat="server" Text='<%# Eval("HesapNo") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="IBANLbl" runat="server" Text='<%# Eval("IBAN") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <p>
                    <span style="font-weight: bold;">Sepetim Nedir ?</span>
                </p>
                Sepetiniz;<br />
                Almayı düşündüğünüz ürünleri ekleyebildiğiniz (ürünlerin yanında ya da alt tarafında bulunan sepete ekle butonu yardımıyla ürünü sepetinize ekleyebilirsiniz.)<br />
                Ürün ve hediyesi olan ürünlerin eklenip eklenmediğini kontrol edebileceğiniz.<br />
                Ürün adetlerini belirleyebildiğiniz.<br />
                Siparişinizin taksit tutarını görebildiğiniz.<br />
                Almaktan vazgeçtiğiniz ürünleri çıkartabildiğiniz
                <br />
                Vermeyi düşündüğünüz siparişinizin toplam fiyatını görebildiğiniz<br />
                Hangi sayfada olursanız olun sağ üst köşede "Sepetim" linkini tıkladığınızda açılarak bilgi alabileceğiniz ekranımızdır.<br />
                <br />
                <p>
                    <span style="font-weight: bold;">Sipariş Takibimi Nasıl Görüntüleyebilirim ?</span>
                </p>
                Öncelikle siteye üye girişi yapılmalı. Daha sonra "Hesabım" sipariş takibi linkinden verdiğiniz siparişleri takip edebilirsiniz.<br />
                Siparişinizin verilmesi ile siparişlerim sayfasında görüntülenmesi arasından bir süre geçebilir. Sipariş numarası almanız siparişiniz başarılı bir şekilde oluşturulduğu anlamanı gelmektedir.<br />
                Siparişinizin durumunu sipariş takibi ekranından takip edebilirsiniz.<br />
            </article>
        </div>
        <div id="ArizaIslemleriDiv">
            <input id="ac-4" name="accordion-1" type="radio" />
            <label for="ac-4">ARIZA İŞLEMLERİ</label>
            <article class="ac-ariza">
                <p>
                    <span style="font-weight: bold;">Ürün Garantisi</span>
                </p>
                <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>'da satışa sunulan tüm ürünler,
                <asp:Label ID="FirmaAdiLbl2" runat="server"></asp:Label>
                tarafından ambalajlanmış olup, imalatçı veya ithalatçı firmaların garantisi altındadır ve her markanın kendi garanti koşulları geçerlidir.
                <p>
                    <span style="font-weight: bold;">Yeni Aldığım Ürün Arızalı Çıkarsa, Ne Yapmalıyım ?</span>
                </p>
                Ambajından arızalı çıkan yeni aldığınız ürünün değişim işlemleri için, orijinal ambalajında, bütün parçaları tam olarak ve
                <asp:Label ID="FirmaAdiLbl" runat="server"></asp:Label>
                tarafından ürün üzerine yapıştırılmış olan baskılı etiket sökülmemiş ve tahrip edilmemiş şekilde, yani "aldığınız gibi olmak kaydı" ile doğrudan
                <asp:Label ID="WebSitesiLbl2" runat="server"></asp:Label>'a göndermeniz gerekir. Orijinal ambalajında etiket, bant, yazı vb. olmamalıdır. Değişimi talep edilen arızalı ürünlerin mutlaka <span style="font-weight: bold;">BÜTÜN PARÇALARI VE EKSİKSİZ AMBALAJLARI İLE GÖNDERİLMESİ GEREKLİDİR.</span> Aksi takdirde değişim işleminde problemler yaşanabilir.<br />
                <br />
                Ambalajından arızalı çıkan yeni ürünleriniz için size 3 farklı çözüm alternatifi sunuyoruz; onarım, değişim veya iade. Bu nedenle mutlaka ne isteğinizi ifade eden bir not ile birlikte ürünü göndermeniz gerekmektedir.<br />
                Bu kategoriye giren ürünlerin kargo ücretleri
                <asp:Label ID="WebSitesiLbl3" runat="server"></asp:Label>
                tarafından karşılanır.<br />
                Bize ulaşan ürünler, sizin isteğiniz doğrultusunda, işlemin süresi değişim ise firmanın stoklarına bağlı olarak, iade ise yetkili servisin vereceği rapora bağlı olarak, onarım ise yine yetkili servisin onarım süresine bağlı olarak değişmektedir.<br />
                Ürün elimize ulaştığında size e-mail olarak arızalı ürününüzle ilgili bilgilendirme yapılacaktır.<br />
                <br />
                <span style="font-weight: bold;">Tarafımıza yapılacak bütün gönderilerin, mutlaka anlaşmalı kargo firmamız ile yapılması gerekir. Anlaşmalı Kargo Şirketi:
                    <asp:Label ID="KargoLbl2" runat="server"></asp:Label>dur.</span>

            </article>

        </div>
        <div id="IadeIslemleriDiv">
            <input id="ac-5" name="accordion-1" type="radio" />
            <label for="ac-5">İADE İŞLEMLERİ</label>
            <article class="ac-iade">
                <br />
                <br />
                Sitemizden aldığınız tüm ürünler, ilgili üretici firmaların garantisi altındadır.<br />
                <br />
                Almış olduğunuz ürününüzün üzerinde güvenlik amacıyla firmamızın etiketi bulunmaktadır. İade işleminiz için bu etiketlerin ve ürün ambalajının; tahrip edilmemiş, bozulmamış ve ürün ambalajı açılmamış olması gerekmektedir. Ürünü teslim tarihinden itibaren on (10) iş günü içinde teslim aldığınız şekilde iade edebilirsiniz. Ürününüzü; ürün faturasını ve bu sayfa ekinde yer alan iade formunu da doldurarak iade edebilirsiniz.<br />
                <br />
                Taşıma sırasında zarar gördüğünü düşündüğünüz paketleri, teslim aldığınız kargo firma yetkilisi önünde açıp kontrol ediniz. Eğer üründe herhangi bir zarar varsa kargo firmasına tutanak tutturarak ürünü teslim almayınız. Ürün teslim alındıktan sonra, kargo firmasının görevini tam olarak yerine getirdiğini kabul etmiş olduğunuzu hatırlatırız.<br />
                <br />
                Firmamızın etiketi yırtılmış ya da sökülmüş, ambalajı açılmış, kullanılmış, tahrip edilmiş ürünlerin iadesi kabul edilmemektedir. Kutu üzerine kargo etiketi yapıştırılmış ve kargo koli bandı ile bantlanmış ürünler kabul edilmez, kısaca tekrar satılabilirlik özelliğini kaybetmiş, başka bir müşteri tarafından satın alınamayacak durumda olan ürünlerin iadesi kabul edilmemektedir.<br />
                <br />
                Ürünün iade edilmesi halinde, iade edilen ürün tarafımıza yukarıda belirtildiği şekilde kusursuz olarak ulaştığı andan itibaren on (10) gün içerisinde bedeli size iade edilir. Kredi kartına ürün iade bedeli, bankalarca 2-6 hafta arasında yapılmaktadır. Bu sürede firmamızın herhangi bir tasarrufu bulunmamaktadır.<br />
                <br />
                Firmamız, ürün ambalajında ve hologram etiketlerde yırtılma ya da sökülme, herhangi bir açılma, bozulma, kırılma, tahrip, kullanılma ve sair durumları tespit ettiği hallerde ve ürünün müşteriye teslim edildiği andaki hali ile iade edilememesi halinde ürünü iade almayacak ve bedelini iade etmeyecektir.<br />
                <br />
                İade etmek istediğiniz ürün / ürünler ayıplı ise kargo ücreti firmamız tarafından karşılanmaktadır. Bu durumda da sitemizden doldurduğunuz bildirim formunuzla birlikte
                <asp:Label ID="KargoLbl3" runat="server"></asp:Label>
                ile gönderim yapmanız gerekir. Diğer durumlarda ise kargo ücreti size aittir. Ürünün ayıplı olup olmadı ile ilgili öncelikle firmamız ile görüşerek onay almalı ve onay ile kargolamalısınız. Onay alınmadan yollanan ürünler her zaman kabul edilmeyebilir.<br />
                <br />
                Ürün müşteriye ulaştıktan sonra ortaya çıkabilecek arızalar için, üretici firmanın yetkili servislerine başvurulmalıdır.<br />
                <br />
                Yukarıdaki şartlara uygun hallerde iade edilen ürünlerin kargo ücreti müşteri tarafından ödenecektir.. Havale iadeleri 2 iş günü içinde Kredi Kartı iadeleri 3 iş günü içinde yapılacaktır. Bankanız kredi kartı iadelerini aynı gün hesabınıza yansıtmayabilir. Bu durumda bankanızın kredi kartı servisini aramanız gereklidir. Kredi kartına ürün iade bedeli, bankalarca 2-6 hafta arasında yapılabilmektedir. Siparişinizle ilgili "İptal Edildi" uyarısı çıktıktan sonra tüm bedel kredi kartınıza veya havale yaptığınız bankanıza iade edilmektedir. Taksitli satışlarda yapılan iadeler bankanız tarafından kredi kartınıza her ay artı bakiye olarak yansıtılmaktadır.<br />
                <br />
            </article>
        </div>
        <div id="SiparisTakibiDiv">
            <input id="ac-6" name="accordion-1" type="radio" />
            <label for="ac-6">SİPARİŞ TAKİBİ</label>
            <article class="ac-siparisTakip">
                <br />
                <br />
                Normal şartlar altında, İstanbul içi teslimatlarınız kargoya verildikten sonra 24 saat içinde, İstanbul dışı teslimatlarınız ise kargo firmasının bulunduğunuz il ve ilçe'ye kendi sistemi içerisinde taahhüt ettiği teslim süresine göre değişmekle birlikte genelde 2-3 gün içinde gerçekleştirilebilmektedir.
                <br />
                <br />
            </article>
        </div>
        <div id="TeslimatTakibiDiv">
            <input id="ac-7" name="accordion-1" type="radio" />
            <label for="ac-7">TESLİMAT TAKİBİ</label>
            <article class="ac-teslimat">
                <p>
                    <span style="font-weight: bold;">Siparişimin Kargoya Verildiğinde Nasıl Takip Edeceğim ?</span>
                </p>

                Siparişiniz stok ve ödeme bilgilerine göre keşinleştirilir. Hafta içi saat 09:00-16:00 saatlerinde kesinleşen şipariş aynı gün, saat 16:00'dan sonra kesinleşen siparişler ise bir gün sonra kargoya verilir. Cumartesi saat 13:00'a kadar kesinleşen siparişler aynı gün, aaat 13:00'dan sonraki siparişler takip eden ilk Pazartesi günü kargolanır.<br />
                <br />
                Sitemizden vermiş olduğunuz siparişleriniz kargoya teslim edildiklerinde, sistemimizde kayıtlı e-mail adresinize siparişiniz ile ilgili kargo gönderi bilgileri ve numarası otomatik olarak gönderilmektedir. Bu bilgi e-mail'i yardımı ile ürününüzün ya da ürünlerinizin kargoya ne zaman teslim edilmiş olduğunu anlaşmalı kargo şirketimizin web sitesinden öğrenebilmektesiniz. Ayrıca sitemize üyelik bilgilerinizi girdiğinizde, Sepet ve Siparişleriniz sayfasındaki Sipariş Takibi menüsünden de, siparişinizin son durumu ile ilgili bilgileri takip edebilirsiniz.<br />
                <p>
                    <span style="font-weight: bold;">Siparişim Darbeli, Kırık, Tahrip Olmuş Geldi Ne Yapmalıyım ?</span>
                </p>
                <asp:Label ID="WebSitesiLbl4" runat="server"></asp:Label>
                tarafından satılan ürünler, size ulaştırılmak üzere kargo firmasına teslim edilirken, paketlenme anında hasar kontrolünden geçmektedir. Hiçbir ürünün firmamızdan hasarlı olarak gönderimi yapılamaz. Fakat niteliği itibariyle (kırılgan yapıya sahip malzemeler vb.) hassas ürünler, direkt taşıma esnasında düşürülebilen veya kargo yüklemesinden kaynaklanan hasarlar olabilmektedir. Bu tip bir durumda yapmanız gerekenler;<br />
                <br />
                Siparişiniz kargo görevlisi tarafınızdan size ulaştırıldığında teslim almadan önce mutlaka dış pakette hasar kontrolü yapmanız ve herhangi bir hasar durumunda
"Hasar Tespit Tutanağı" hazırlatmanız gerekmektedir. Hasar tespit tutanağı ile ilgili olarak dikkat etmeniz gereken bir diğer husus kargo görevlilerinin tutanakta belirttikleri açıklamalardır.<br />
                <br />
                Örneğin, " Kolide hasar bulunmamaktadır. Ürün hasarlıdır. " gibi bir tutanak, ürünün taşıma esnasında hasar görmediği şeklinde yorumlanacağından, değişim esnasında problem yaratmaktadır. Hasarlı çıkan ürününüz için mutlaka tam ve doğru kelimelerle tutanak tutulması için görevliyi uyarınız.<br />
                <br />
                (Örn: Ürün elime ulaştığında kontrol edilmiş ve hasarlı olduğu görülmüştür.)<br />
                Kargo görevlisine tutanağı hazırlatarak ürünü bize ulaştırmanız sonucunda, değişim işlemleriniz hızlı bir şekilde tamamlanacak ve tarafınıza bilgi verilecektir.<br />
                <br />
                ÖNEMLİ: Elinize hasarlı ulaşan ürününüzü size teslimatı yapan kargo firması ile bize göndermelisiniz, aksi hallerde ürünün kargo tazminleri sırasında problem yaşanmaktadır.
                <p>
                    <span style="font-weight: bold;">Kargo Teslimatı Sırasında Dikkat Edilmesi Gereken Hususlar</span>
                </p>

                Sipariş ettiğiniz ürünler size ulaştığında kargo görevlisi yanınızdayken isterseniz teslim fişini imzaladıktan sonra kargo paketini açıp kontrol edebilirsiniz. Paket içeriğinde herhangi bir yanlışlık ya da eksiklik söz konusu ise kargo tutanağı hazırlatarak bize geri gönderebilir ya da bilgi verebilirsiniz.<br />
                <br />
                Bu gibi durumlarda kargo görevlisi ile herhangi bir sorun yaşarsanız bize hemen bilgi vermenizi rica ederiz. Tarafımızdan gerekli müdahale en kısa sürede yapılacak ve sorununuz çözüme kavuşturulacaktır.<br />
                <br />
                Eğer ürün kutusu size hasarlı olarak ulaştı ise paketi teslim almayarak doğrudan bize geri gönderebilirsiniz. Teslimat sonrası paketin hasarlı olduğunu fark ettiyseniz kargo görevlisine tutanak hazırlatarak bize göndermeniz gerekecektir. Ürünler bize ulaştığında sorununuz kayıtlarımıza işlenecek olup, en kısa sürede yeni ürünleriniz size gönderilecektir.<br />
                <br />
                Bulunduğumuz yerde kargo şirketi yoksa,<br />
                <br />
                Genel olarak anlaşmalı olduğumuz kargo firması, (<asp:Label ID="KargoLbl4" runat="server"></asp:Label>) Türkiye'nin tüm noktalarına ürün teslimatı yapabilmektedir. Eğer bulunduğunuz yerde kargo acentesi mevcut değil ise Mobil Bölge olarak tabir edilir ve haftanın belirli günlerinde size ürün teslimi yapılır.
Kapıda ödeme seçeneği ile yapılan siparişlerde. Teslimat adresi Mobil alan ise teslimat sadece
                <asp:Label ID="KargoLbl5" runat="server"></asp:Label>
                Şubesinden yapılmaktadır.
                <asp:Label ID="KargoLbl6" runat="server"></asp:Label>
                yetkilisi kargonuzun geldiğini bildirir ve sipariş sahibi
                <asp:Label ID="KargoLbl7" runat="server"></asp:Label>
                şubesine giderek ödemeyi yapar ve ürünü teslim alır.
            </article>
        </div>
    </section>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KargoTakibi.aspx.cs" Inherits="KargoTakibi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Kargo Takibi
    </div>
    <div class="Hakkimizda_Baslik">
        Siparişimin Kargoya Verildiğinde Nasıl Takip Edeceğim ?
    </div>
    <div class="Hakkimizda_Icerik">
        Siparişiniz stok ve ödeme bilgilerine göre keşinleştirilir. Hafta içi saat 09:00-16:00 saatlerinde kesinleşen şipariş aynı gün, saat 16:00’dan sonra kesinleşen siparişler ise bir gün sonra kargoya verilir. Cumartesi saat 13:00'a kadar kesinleşen siparişler aynı gün, aaat 13:00'dan sonraki siparişler takip eden ilk Pazartesi günü kargolanır.<br />
        Sitemizden vermiş olduğunuz siparişleriniz kargoya teslim edildiklerinde, sistemimizde kayıtlı e-mail adresinize siparişiniz ile ilgili kargo gönderi bilgileri ve numarası otomatik olarak gönderilmektedir. Bu bilgi e-mail'i yardımı ile ürününüzün ya da ürünlerinizin kargoya ne zaman teslim edilmiş olduğunu anlaşmalı kargo şirketimizin web sitesinden öğrenebilmektesiniz. Ayrıca sitemize üyelik bilgilerinizi girdiğinizde, Sepet ve Siparişleriniz sayfasındaki Sipariş Takibi menüsünden de, siparişinizin son durumu ile ilgili bilgileri takip edebilirsiniz.
    </div>
    <div class="Hakkimizda_Baslik">
        Siparişim Darbeli, Kırık, Tahrip Olmuş Geldi Ne Yapmalıyım ?
    </div>
    <div class="Hakkimizda_Icerik">
        <asp:Label ID="WebSitesiLbl" runat="server"></asp:Label>
        tarafından satılan ürünler, size ulaştırılmak üzere kargo firmasına teslim edilirken, paketlenme anında hasar kontrolünden geçmektedir. Hiçbir ürünün firmamızdan hasarlı olarak gönderimi yapılamaz. Fakat niteliği itibariyle (kırılgan yapıya sahip malzemeler vb.) hassas ürünler, direkt taşıma esnasında düşürülebilen veya kargo yüklemesinden kaynaklanan hasarlar olabilmektedir. Bu tip bir durumda yapmanız gerekenler;<br />
        Siparişiniz kargo görevlisi tarafınızdan size ulaştırıldığında teslim almadan önce mutlaka dış pakette hasar kontrolü yapmanız ve herhangi bir hasar durumunda
"Hasar Tespit Tutanağı" hazırlatmanız gerekmektedir. Hasar tespit tutanağı ile ilgili olarak dikkat etmeniz gereken bir diğer husus kargo görevlilerinin tutanakta belirttikleri açıklamalardır.<br />
        Örneğin, " Kolide hasar bulunmamaktadır. Ürün hasarlıdır. " gibi bir tutanak, ürünün taşıma esnasında hasar görmediği şeklinde yorumlanacağından, değişim esnasında problem yaratmaktadır. Hasarlı çıkan ürününüz için mutlaka tam ve doğru kelimelerle tutanak tutulması için görevliyi uyarınız.<br />
        (Örn: Ürün elime ulaştığında kontrol edilmiş ve hasarlı olduğu görülmüştür.)<br />
        Kargo görevlisine tutanağı hazırlatarak ürünü bize ulaştırmanız sonucunda, değişim işlemleriniz hızlı bir şekilde tamamlanacak ve tarafınıza bilgi verilecektir.<br />
        ÖNEMLİ: Elinize hasarlı ulaşan ürününüzü size teslimatı yapan kargo firması ile bize göndermelisiniz, aksi hallerde ürünün kargo tazminleri sırasında problem yaşanmaktadır.
    </div>
    <div class="Hakkimizda_Baslik">
        Kargo Teslimatı Sırasında Dikkat Edilmesi Gereken Hususlar
    </div>
    <div class="Hakkimizda_Icerik">
        Sipariş ettiğiniz ürünler size ulaştığında kargo görevlisi yanınızdayken isterseniz teslim fişini imzaladıktan sonra kargo paketini açıp kontrol edebilirsiniz. Paket içeriğinde herhangi bir yanlışlık ya da eksiklik söz konusu ise kargo tutanağı hazırlatarak bize geri gönderebilir ya da bilgi verebilirsiniz.
Bu gibi durumlarda kargo görevlisi ile herhangi bir sorun yaşarsanız bize hemen bilgi vermenizi rica ederiz. Tarafımızdan gerekli müdahale en kısa sürede yapılacak ve sorununuz çözüme kavuşturulacaktır.<br />
        Eğer ürün kutusu size hasarlı olarak ulaştı ise paketi teslim almayarak doğrudan bize geri gönderebilirsiniz. Teslimat sonrası paketin hasarlı olduğunu fark ettiyseniz kargo görevlisine tutanak hazırlatarak bize göndermeniz gerekecektir. Ürünler bize ulaştığında sorununuz kayıtlarımıza işlenecek olup, en kısa sürede yeni ürünleriniz size gönderilecektir.<br />
        Bulunduğumuz yerde kargo şirketi yoksa,<br />
        Genel olarak anlaşmalı olduğumuz kargo firması, (<asp:Label ID="KargoLbl" runat="server"></asp:Label>) Türkiye'nin tüm noktalarına ürün teslimatı yapabilmektedir. Eğer bulunduğunuz yerde kargo acentesi mevcut değil ise Mobil Bölge olarak tabir edilir ve haftanın belirli günlerinde size ürün teslimi yapılır.
Kapıda ödeme seçeneği ile yapılan siparişlerde. Teslimat adresi Mobil alan ise teslimat sadece
        <asp:Label ID="KargoLbl2" runat="server"></asp:Label>
        Şubesinden yapılmaktadır.
        <asp:Label ID="KargoLbl3" runat="server"></asp:Label>
        yetkilisi kargonuzun geldiğini bildirir ve sipariş sahibi MNG şubesine giderek ödemeyi yapar ve ürünü teslim alır.
    </div>
</asp:Content>


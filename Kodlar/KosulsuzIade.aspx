<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KosulsuzIade.aspx.cs" Inherits="KosulsuzIade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Hakkimizda_Buyuk_Baslik">
        Koşulsuz İade
    </div>
    <div class="Hakkimizda_Baslik">
        Koşulsuz İade Bilgileri
    </div>
    <div class="Hakkimizda_Icerik">
        Sitemizden aldığınız tüm ürünler, ilgili üretici firmaların garantisi altındadır.<br />
        <br />
        Almış olduğunuz ürününüzün üzerinde güvenlik amacıyla firmamızın hologram etiketi bulunmaktadır. İade işleminiz için bu etiketlerin ve ürün ambalajının; tahrip edilmemiş, bozulmamış ve ürün ambalajı açılmamış, teslim tarihinden itibaren on (10) iş günü içinde teslim aldığınız şekilde iade edebilirsiniz. Ürününüzü; ürün faturasını ve bu sayfa ekinde yer alan iade formunu da doldurarak iade edebilirsiniz.<br />
        <br />
        Taşıma sırasında zarar gördüğünü düşündüğünüz paketleri, teslim aldığınız kargo firma yetkilisi önünde açıp kontrol ediniz. Eğer üründe herhangi bir zarar varsa kargo firmasına tutanak tuttururarak ürünü teslim almayınız. Ürün teslim alındıktan sonra, kargo firmasının görevini tam olarak yerine getirdiğini kabul etmiş olduğunuzu hatırlatırız.<br />
        <br />
        Firmamızın 3 boyutlu hologram etiketi yırtılmış ya da sökülmüş, ambalajı açılmış, kullanılmış, tahrip edilmiş ürünlerin iadesi kabul edilmemektedir. Kutu üzerine kargo etiketi yapıştırılmış ve kargo koli bandı ile bantlanmış ürünler kabul edilmez, kısaca tekrar satılabilirlik özelliğini kaybetmiş, başka bir müşteri tarafından satın alınamayacak durumda olan ürünlerin iadesi kabul edilmemektedir.<br />
        <br />
        Ürünün iade edilmesi halinde, iade edilen ürün tarafımıza yukarıda belirtildiği şekilde kusursuz olarak ulaştığı andan itibaren on (10) gün içerisinde bedeli size iade edilir. Kredi kartına ürün iade bedeli, bankalarca 2-6 hafta arasında yapılmaktadır. Bu sürede firmamızın herhangi bir tasarrufu bulunmamaktadır.<br />
Firmamız, ürün ambalajında ve hologram etiketlerde yırtılma ya da sökülme, herhangi bir açılma, bozulma, kırılma, tahrip, kullanılma ve sair durumları tespit ettiği hallerde ve ürünün müşteriye teslim edildiği andaki hali ile iade edilememesi halinde ürünü iade almayacak ve bedelini iade etmeyecektir.
İade etmek istediğiniz ürün / ürünler ayıplı ise kargo ücreti firmamız tarafından karşılanmaktadır. Bu durumda da sitemizden doldurduğunuz bildirim formunuzla birlikte <asp:Label ID="KargoLbl" runat="server"></asp:Label> ile gönderim yapmanız gerekir. Diğer durumlarda ise kargo ücreti size aittir.<br />
        <br />
        Ürün müşteriye ulaştıktan sonra ortaya çıkabilecek arızalar için, üretici firmanın yetkili servislerine başvurulmalıdır.<br />
        Yukarıdaki şartlara uygun hallerde iade edilen ürünlerin kargo ücreti müşteri tarafından ödenecektir.<br />
        <br />
        Havale ve Kredi Kartı iadeleri iadeleri 10 iş günü yapılacaktır. Bankanız kredi kartı iadelerini aynı gün hesabınıza yansıtmayabilir. Bu durumda bankanızın kredi kartı servisini aramanız gereklidir. Taksitli satışlarda yapılan iadeler bankanız tarafından kredi kartınıza her ay artı bakiye olarak yansıtılmaktadır.
        <br /><br />
        <a href="IadeDegisimFormu.aspx" class="Footer_Link" title="Koşuşsuz İade Formu">İade Formu İçin Tıklayınız</a>
    </div>
</asp:Content>


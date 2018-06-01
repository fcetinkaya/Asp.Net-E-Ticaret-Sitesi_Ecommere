<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayPal_Basarili.aspx.cs" Inherits="PayPal_Basarili" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                        <div class="Basarili">
                        <span class="Hakkimizda_Baslik">Siparişiniz Onaylandı<br />
                            Siparişiniz başarıyla oluşturulmuştur.<br />
                            Sipariş No:
                            <asp:Label ID="SiparisNo_Paypal_Odeme_Lbl" runat="server"></asp:Label>
                            <br />
                            Paypal hesabınızdan çekilen tutar:
                            <br />
                            <asp:Label ID="Odeme_Paypal_TutarLbl" runat="server"></asp:Label>
                        </span>
                        <br />
                        <br />
                    </div>
                    <br />
                    <div class="Hakkimizda_Icerik" style="float: left; width: 970px; height: 350px;">
                        <div style="float: left; width: 970px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Sipariş onaylandıktan sonra e-posta alacaksınız.</li>
                                <li>Ürünlerimizi
                                    <asp:Label ID="KargoAdi_Paypal_OdemeLbl" runat="server"></asp:Label>
                                    &nbsp;ile gönderilecektir.</li>
                                <li>Ürünleriniz kargoya teslim ediltikten sonra tekrar bir e-posta gönderilecektir.</li>
                                <li>E-posta adresinizin servis sağlayıcısı tarafından gönderdiğimiz bilgi mailleri spam/junk/gereksiz klasörlerine düşebilir. Lütfen bu klasörleri kontrol ediniz.</li>
                                <li>Sipariş durumunu Hesabım/Sipariş Takip sayfasından görebilirsiniz.</li>
                            </ul>
                        </div>
                        <br />
                        <div class="Hakkimizda_Baslik">
                            Kargoyu teslim alırken dikkat edilmesi gereken hususlar :
                        </div>
                        <div style="float: left; width: 970px; padding-bottom: 10px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Siparişinizi teslim almadan önce kargo elemanının önünde kutuyu açıp, paket içerisindeki ürünlerin sağlam olup olmadığını kontrol ediniz..</li>
                                <li>Eğer paket içerisindeki ürünlerden biri kırık / arızalı ise hemen kargo elemanına tutanak tutturunuz ve kargoyu teslim almayınız.</li>
                                <li>Tutanak tuturmadığınız durumlarda, kırık / arızalı çıkan ürünler için
                                <asp:Label ID="FirmaAdi_Paypal_Odeme_Lbl" runat="server"></asp:Label>
                                    &nbsp;herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Paypal_OdemeLbl" runat="server"></asp:Label>
                        &nbsp;tercih ettiğiniz için teşekkürler.
                        <br />
                        <br />
                        Alışverişe dönmek için <a href="Default.aspx" title="Anasayfa" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        Sipariş takibe gitmek için <a href="Hesabim.aspx" title="Hesabım" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                    </div>

</asp:Content>


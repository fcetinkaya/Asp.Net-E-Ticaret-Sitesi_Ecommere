<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sepet.aspx.cs" Inherits="Sepet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function GetRDBValue() {
            var list = document.getElementById("ContentPlaceHolder1_OdemeSecenekleri_RadioList");
            var inputs = list.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                //if (inputs[0].checked) {
                //    document.getElementById('KartTek_Div').style.display = 'block';
                //    document.getElementById('Kart_Taksit_Div').style.display = 'none';
                //    document.getElementById('EFT_Havale_Div').style.display = 'none';
                //    document.getElementById('KapidaOdeme_Div').style.display = 'none';
                //    document.getElementById('PaypalIleOdeme_Div').style.display = 'none';
                //}
                //else if (inputs[1].checked) {
                //    document.getElementById('Kart_Taksit_Div').style.display = 'block';
                //    document.getElementById('KartTek_Div').style.display = 'none';
                //    document.getElementById('EFT_Havale_Div').style.display = 'none';
                //    document.getElementById('KapidaOdeme_Div').style.display = 'none';
                //    document.getElementById('PaypalIleOdeme_Div').style.display = 'none';
                //    $("#ContentPlaceHolder1_OdenecekTutarLbl").text("Kredi Kartı Taksit");
                //}
                if (inputs[0].checked) {
                    document.getElementById('EFT_Havale_Div').style.display = 'block';
                    //document.getElementById('Kart_Taksit_Div').style.display = 'none';
                    //document.getElementById('KartTek_Div').style.display = 'none';
                    document.getElementById('KapidaOdeme_Div').style.display = 'none';
                    document.getElementById('PaypalIleOdeme_Div').style.display = 'none';
                }
                else if (inputs[1].checked) {
                    document.getElementById('KapidaOdeme_Div').style.display = 'block';
                    document.getElementById('EFT_Havale_Div').style.display = 'none';
                    //document.getElementById('Kart_Taksit_Div').style.display = 'none';
                    //document.getElementById('KartTek_Div').style.display = 'none';
                    document.getElementById('PaypalIleOdeme_Div').style.display = 'none';
                }
                else {
                    document.getElementById('PaypalIleOdeme_Div').style.display = 'block';
                    document.getElementById('KapidaOdeme_Div').style.display = 'none';
                    document.getElementById('EFT_Havale_Div').style.display = 'none';
                    document.getElementById('Kart_Taksit_Div').style.display = 'none';
                    document.getElementById('KartTek_Div').style.display = 'none';
                }
            }
        }
        function ValidateCheckBox_Havale(sender, args) {
            if (document.getElementById("<%=EftHavale_SatisSozlesmesi_CheckBox.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function ValidateCheckBox_KrediTek(sender, args) {
            if (document.getElementById("<%=KrediKarti_SozlemeOkudumCheckBox.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function ValidateCheckBox_KrediTaksit(sender, args) {
            if (document.getElementById("<%=Kredi_Karti_Taksit_SozlesmeOkudumCheck.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function ValidateCheckBox_Kapida(sender, args) {
            if (document.getElementById("<%=KapidaOdeme_CheckBox.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function ValidateCheckBox_Paypal(sender, args) {
            if (document.getElementById("<%=Paypal_CheckBox.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
    (key == 9) || (key == 13) || (key == 27))
                return true;

                // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;

                // decimal point jump
            else if (dec && (keychar == ".")) {
                myfield.form.elements[dec].focus();
                return false;
            }
            else
                return false;
        }
    </script>
    <script src="Tooltip/jquery.js" type="text/javascript"></script>
    <script src="Tooltip/main.js" type="text/javascript"></script>

    <style type="text/css">
        img {
            border: none;
        }

        #screenshot {
            position: absolute;
            border: 1px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="Hakkimizda_Buyuk_Baslik">
                Sepet ve Ödeme işlemleri
            </div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="SepetView" runat="server">
                    <div id="panelsepet" style="float: left; width: 1000px; height: auto; margin: 20px 0px;" runat="server">
                        <asp:DataList ID="DataList1" runat="server" GridLines="Both" OnItemCommand="DataList1_ItemCommand">
                            <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
                            <HeaderTemplate>
                                <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                    Resim
                                </div>
                                <div style="float: left; height: 20px; width: 280px; text-align: left; padding: 5px;">
                                    Ürün Adı
                                </div>
                                <div style="float: left; height: 20px; width: 120px; text-align: left; padding: 5px;">
                                    Birim Fiyat
                                </div>
                                <div style="float: left; height: 20px; width: 60px; text-align: center; padding: 5px;">
                                    Adet
                                </div>
                                <div style="float: left; height: 20px; width: 150px; text-align: left; padding: 5px;">
                                    Toplam Tutar
                                </div>
                                <div style="float: left; height: 20px; width: 60px; text-align: left; padding: 5px;">
                                </div>
                            </HeaderTemplate>
                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                            <ItemTemplate>
                                <div style="float: left; height: 50px; width: 100px; text-align: left; padding: 5px;">
                                    <a href='<%# Eval("link") %>'>
                                        <asp:Image ID="Resim" runat="server" ImageUrl='<%# Eval("resim") %>' ToolTip='<%# Eval("isim") %>' Height="50" Width="100" /></a>
                                </div>
                                <div style="float: left; height: 40px; width: 270px; text-align: left; padding: 10px;">
                                    <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("isim") %>' ToolTip='<%# Eval("isim") %>' CssClass="Footer_Link"></asp:HyperLink>
                                </div>
                                <div style="float: left; height: 40px; width: 110px; text-align: left; padding: 10px;">
                                    <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("fiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>&nbsp;TL
                                </div>
                                <div style="float: left; height: 40px; width: 50px; text-align: center; padding: 10px;">
                                    <asp:TextBox ID="AdetBox" runat="server" Text='<%# Eval("adet") %>' Width="30px" onkeypress="return numbersonly(this, event)"></asp:TextBox>
                                </div>
                                <div style="float: left; height: 40px; width: 140px; text-align: left; padding: 10px;">
                                    <asp:Label ID="ToplamTutarLbl" runat="server" CssClass="UrunListeItem_YebiFiyatLbl" Text='<%# Eval("toplam") %>'> </asp:Label>&nbsp;TL
                                </div>
                                <div style="float: left; height: 40px; width: 40px; text-align: center; padding: 10px;">
                                    <asp:ImageButton ID="DeleteBtn" runat="server" CommandName="Sil" CommandArgument='<%# Eval("id") %>'
                                        ImageUrl="~/image/delete_32x32.png" />
                                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteBtn"
                                        ConfirmText="Silmek istediğine emin misin?">
                                    </asp:ConfirmButtonExtender>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <div class="SepetAltKisim">
                            <div class="SepetAltKisim_SepetButtonlar">
                                <asp:Button ID="SepetAdetGuncelleBtn" runat="server" CssClass="btn-orange" Text="Sepet Adetleri Güncelle" OnClick="SepetAdetGuncelleBtn_Click" />
                                <asp:Button ID="DevamEtBtn" runat="server" CssClass="btn-Green" Text="Alışverişe Devam Et" PostBackUrl="~/Default.aspx"></asp:Button>
                            </div>
                            <div class="SepetAltKisim_SepetTutarlar">
                                <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Toplam Ücret :</div>
                                <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                    <asp:Label ID="SepetFiyatLbl" runat="server"></asp:Label>
                                </div>
                                <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">KDV :</div>
                                <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                    <asp:Label ID="SepetKDVLbl" runat="server"></asp:Label>
                                </div>
                                <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Kargo Bedeli :</div>
                                <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                    <asp:Label ID="KargoBedeliLbl" runat="server"></asp:Label>
                                </div>
                                <div class="SepetAltKisim_SepetTutarlar_Sol_Satir">Genel Toplam :</div>
                                <div class="SepetAltKisim_SepetTutarlar_Sag_Satir">
                                    <asp:Label ID="GenelToplamLbl" runat="server"></asp:Label>
                                </div>
                                <asp:Button ID="AlisverisiTamamlaBtn" runat="server" CssClass="btn-orange" Text="Alışverişi Tamamla" OnClick="AlisverisiTamamlaBtn_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="SepetYokDiv" class="AnaErrorDivKucuk" runat="server" visible="false">
                        <div style="width: 560px; height: 50px; float: left; padding: 25px 0px; margin-left: 220px;">
                            <span class="Hakkimizda_Baslik">Sepetiniz boş, biraz alışverişe ne dersiniz ?</span>
                            <br />
                            <a href="Default.aspx" class="Footer_Link">Sipariş vermek için dilediğiniz ürünü/ürünleri sepetinize ekleyin.<br />
                                Sepete eklediğiniz ürünler, sipariş vermediğiniz veya silmediğiniz sürece sepetinizde kalır. </a>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="TeslimatOdemeView" runat="server">
                    <div class="Sepet_Sol_Satir">
                        <div class="Hakkimizda_Baslik">
                            Teslimat Bilgileri
                        </div>
                        <div class="form_Elementleri">
                            <asp:TextBox ID="TckimlikNoBox" runat="server" placeholder="Tc Kimlik No" CssClass="TextBox_F" MaxLength="11" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="Tc Kimlik No Yazınız." Display="None" ControlToValidate="TckimlikNoBox"
                                ValidationGroup="adres"></asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                TargetControlID="TckimlikNoBox" FilterType="Custom,Numbers">
                            </asp:FilteredTextBoxExtender>
                            <asp:TextBox ID="EPostaBox" runat="server" placeholder="E-Posta Adresi" CssClass="TextBox_F" /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="E-Posta Adresini Yazınız."
                                Display="None" ControlToValidate="EPostaBox" ValidationGroup="adres"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="EpostaExpressionValidator" runat="server" ErrorMessage="Geçerli bir e-posta adresi yazınız."
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EPostaBox"
                                ValidationGroup="adres" Display="None"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="CepBox" runat="server" placeholder="Cep Telefonu" CssClass="TextBox_F" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ErrorMessage="Cep Telefonunu Yazınız." Display="None" ControlToValidate="CepBox"
                                ValidationGroup="adres"></asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="CepBox"
                                FilterType="Custom,Numbers">
                            </asp:FilteredTextBoxExtender>
                            <asp:TextBox ID="TelefonBox" runat="server" placeholder="Telefon" CssClass="TextBox_F" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ErrorMessage="Ev Telefonu Yazınız." Display="None" ControlToValidate="TelefonBox"
                                ValidationGroup="adres"></asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True"
                                TargetControlID="TelefonBox" FilterType="Custom,Numbers">
                            </asp:FilteredTextBoxExtender>
                            <asp:DropDownList ID="SehirDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true" OnSelectedIndexChanged="SehirDrop_Adres_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Şehir Seçiniz."
                                Display="None" ControlToValidate="SehirDrop" ValidationGroup="adres"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="IlceDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="İlçe Seçiniz."
                                Display="None" ControlToValidate="IlceDrop" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="AdresBox" runat="server" placeholder="Adres" CssClass="TextBox_F" TextMode="MultiLine" Height="100px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                ErrorMessage="Teslimat Adresini Yazınız." Display="None" ControlToValidate="AdresBox" ValidationGroup="adres"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="Sepet_Sag_Satir">
                        <div class="Hakkimizda_Baslik">
                            Fatura Bilgileri
                        </div>
                        <div class="form_Elementleri">
                            <asp:TextBox ID="YetkiliAdSoyadBox" runat="server" placeholder="Yetkili Adı Soyadı" CssClass="TextBox_F" />
                            <asp:TextBox ID="FirmaBox" runat="server" placeholder="Firma Adı" CssClass="TextBox_F" />
                            <asp:TextBox ID="VergiDairesiBox" runat="server" placeholder="Vergi Dairesi" CssClass="TextBox_F" />
                            <asp:TextBox ID="VergiNoBox" runat="server" placeholder="Veri Numarası" CssClass="TextBox_F" />
                            <asp:DropDownList ID="FirmaSehirDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true" OnSelectedIndexChanged="FirmaSehirDrop_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:DropDownList ID="FirmaIlceDrop" runat="server" CssClass="DropDown_F" AppendDataBoundItems="true">
                            </asp:DropDownList>
                            <asp:TextBox ID="FirmaAdresBox" runat="server" placeholder="Notunuz Varsa Lütfen Buraya Yazınız" CssClass="TextBox_F" TextMode="MultiLine" Height="100px" />
                            <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                <asp:CheckBox ID="TeslimatIleFaturaAyniCheck" runat="server" Text="Teslimat Adresi ile Aynı" OnCheckedChanged="TeslimatIleFaturaAyniCheck_CheckedChanged" />
                            </div>
                            <asp:Button ID="GeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="GeriDonBtn_Click" />
                            <asp:Button ID="DevamBtn" runat="server" CssClass="btn-orange" Text="Devam Et  " OnClick="DevamBtn_Click" ValidationGroup="adres" />
                            <asp:ValidationSummary ID="ValidationSummary_Teslimat" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="adres" />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="OdemeSecenekleri_View" runat="server">
                    <div class="Hakkimizda_Baslik">
                        Sepet
                    </div>
                    <asp:DataList ID="ODeme_DataList" runat="server" GridLines="Both">
                        <AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" />
                        <HeaderStyle CssClass="Kampanya_Baslik" BorderStyle="Solid" BorderWidth="1px" BorderColor="#E6E7E5" BackColor="#FBFBF9" />
                        <HeaderTemplate>
                            <div style="float: left; height: 20px; width: 100px; text-align: left; padding: 5px;">
                                Resim
                            </div>
                            <div style="float: left; height: 20px; width: 350px; text-align: left; padding: 5px;">
                                Ürün Adı
                            </div>
                            <div style="float: left; height: 20px; width: 120px; text-align: left; padding: 5px;">
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
                                <a href='<%# Eval("link") %>'>
                                    <asp:Image ID="Resim" runat="server" ImageUrl='<%# Eval("resim") %>' ToolTip='<%# Eval("isim") %>' Height="50" Width="100" /></a>
                            </div>
                            <div style="float: left; height: 40px; width: 340px; text-align: left; padding: 10px;">
                                <asp:HyperLink ID="UrunAdi" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("isim") %>' ToolTip='<%# Eval("isim") %>' CssClass="Footer_Link"></asp:HyperLink>
                            </div>
                            <div style="float: left; height: 40px; width: 110px; text-align: left; padding: 10px;">
                                <asp:Label ID="BirimFiyatLbl" runat="server" Text='<%# Eval("fiyat") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>&nbsp;TL
                            </div>
                            <div style="float: left; height: 40px; width: 50px; text-align: center; padding: 10px;">
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("adet") %>' CssClass="UrunListeItem_YebiFiyatLbl"> </asp:Label>
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
                    <div class="Hakkimizda_Baslik">
                        Ödeme Seçenekleri
                    </div>
                    <div class="ListControl">
                        <%-- <div id="CheckListDiv" style="float: left; width: 490px; padding: 10px 0px; border: 1px solid black;">--%>
                        <asp:RadioButtonList runat="server" ID="OdemeSecenekleri_RadioList" OnClick="GetRDBValue()">
                         <%--   <asp:ListItem Value="0" Selected="True">Tek Çekim Kredi Kartı Ödeme</asp:ListItem>
                            <asp:ListItem Value="1">Taksit ile Kredi Kartı Ödeme</asp:ListItem>--%>
                            <asp:ListItem Value="0" Selected="True">EFT / Havale ile Ödeme</asp:ListItem>
                            <asp:ListItem Value="1">Kapıda Ödeme</asp:ListItem>
                            <asp:ListItem Value="2">Paypal ile Ödeme</asp:ListItem>
                        </asp:RadioButtonList>
                        <%-- </div>
                    <div id="TutarDiv" style="float: left; width: 480px; padding: 100px 0px; border: 1px solid red;">
                            <div class="Hakkimizda_Baslik" style="text-align: center;">
                                Ödenecek Tutar
                            </div>
                            <div class="Hakkimizda_Buyuk_Baslik" style="text-align: center;">
                                <asp:Label ID="OdenecekTutarLbl" runat="server"></asp:Label>
                            </div>
                        </div>--%>
                        <%--</div>--%>
                        <div id="KartTek_Div" style="float: left; width: 980px; padding: 10px 0px; display: none;">
                            <div class="Hakkimizda_Baslik">
                                Kredi Kartı ile Tek Çekim Ödeme
                            </div>
                            <div class="form_Elementleri">
                                <asp:TextBox ID="KrediKarti_Tek_AdSoyadBox" runat="server" placeholder="Kart Üzerindeki Ad Soyad" CssClass="TextBox_F" />
                                <asp:RequiredFieldValidator ID="KKTek_RequiredFieldValidator1" runat="server" ErrorMessage="Ad ve Soyadı Yazınız."
                                    ControlToValidate="KrediKarti_Tek_AdSoyadBox" Display="None" ValidationGroup="KrediTek"></asp:RequiredFieldValidator>
                                <br />
                                <asp:TextBox ID="KrediKarti_Tek_KartNumarasiBox" runat="server" placeholder="Kart Numarası" CssClass="TextBox_F" onkeypress="return numbersonly(this, event)" MaxLength="16" />
                                <asp:RequiredFieldValidator ID="KKTek_RequiredFieldValidator2" runat="server" ErrorMessage="Kart Numaranızı Yazınız."
                                    ControlToValidate="KrediKarti_Tek_KartNumarasiBox" Display="None" ValidationGroup="KrediTek"></asp:RequiredFieldValidator>
                                <br />
                                <div style="width: 1000px; float: left; height: 50px;">
                                    <div style="width: 380px; float: left;">
                                        <asp:TextBox ID="KrediKarti_Tek_GuvenlikKoduBox" runat="server" placeholder="Güvenlik Kodu (CVV2)" CssClass="TextBox_F" />
                                        <asp:RequiredFieldValidator ID="KKTek_RequiredFieldValidator3" runat="server" ErrorMessage="Güvenlik Kodunu Yazınız."
                                            ControlToValidate="KrediKarti_Tek_GuvenlikKoduBox" Display="None" ValidationGroup="KrediTek"></asp:RequiredFieldValidator>
                                    </div>
                                    <div style="width: 570px; padding-top: 20px; float: left; color: black;">
                                        <%-- <a href="#" class="screenshot" rel="Tooltip/cvc2.jpg">Nedir ?</a>--%>
                                    </div>
                                </div>
                                <br />
                                <asp:DropDownList ID="KrediKarti_Tek_Sene" runat="server" CssClass="DropDown_Kucuk_F">
                                    <asp:ListItem Value="0">Son Kullanma (Ay)</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKT_RequiredFieldValidator4" runat="server" ErrorMessage="Kartın Son Kullanma Yılını Seçiniz. "
                                    ControlToValidate="KrediKarti_Tek_Sene" Display="None" ValidationGroup="KrediTek" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="KrediKarti_Tek_AyDrop" runat="server" CssClass="DropDown_Kucuk_F">
                                    <asp:ListItem Value="0">Son Kullanma (Yıl)</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                    <asp:ListItem>2024</asp:ListItem>
                                    <asp:ListItem>2025</asp:ListItem>
                                    <asp:ListItem>2026</asp:ListItem>
                                    <asp:ListItem>2027</asp:ListItem>
                                    <asp:ListItem>2028</asp:ListItem>
                                    <asp:ListItem>2029</asp:ListItem>
                                    <asp:ListItem>2030</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKT_RequiredFieldValidator5" runat="server" ErrorMessage="Kartın Son Kullanma Ayını Seçiniz. "
                                    ControlToValidate="KrediKarti_Tek_AyDrop" Display="None" ValidationGroup="KrediTek" InitialValue="0"></asp:RequiredFieldValidator>
                                <br />
                                <%--  <asp:DropDownList ID="KrediKarti_Tek_Banka" runat="server" CssClass="DropDown_F" AutoPostBack="true" AppendDataBoundItems="true">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="KrediKarti_Tek_NotunuzBox" runat="server" placeholder="Sipariş Notunuz" CssClass="TextBox_F" TextMode="MultiLine" Height="100" MaxLength="240" /><br />
                                <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                    <asp:CheckBox ID="KrediKarti_SozlemeOkudumCheckBox" runat="server" /><a class="Footer_Link" href="SatisSozlesmesi.aspx" target="_blank">Satış Sözleşmesini</a>,okudum kabul ediyorum.<br />
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Sözleşmeyi Kabul Ediniz." ClientValidationFunction="ValidateCheckBox_KrediTek" ValidationGroup="KrediTek" ForeColor="Red"></asp:CustomValidator>
                                </div>
                                <asp:Button ID="KrediKarti_GeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="KrediKarti_GeriDonBtn_Click" />
                                <asp:Button ID="KrediKarti_TamamBtn" runat="server" CssClass="btn-orange" Text="Tamam" OnClick="KrediKarti_TamamBtn_Click" ValidationGroup="KrediTek" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="KrediTek" />
                            </div>
                        </div>
                        <div id="Kart_Taksit_Div" style="float: left; width: 980px; padding: 10px 0px; display: none;">
                            <div class="Hakkimizda_Baslik">
                                Kredi Kartı ile Taksitli Ödeme
                            </div>
                            <p>
                                Anlaşmalı olduğumuz banka kartlarına taksit yapılmaktadır. Bankanız, anlaşmalı banka listesinde yoksa lütfen "Tek Çekim Kredi Kartı Ödeme" seçeneğini seçiniz.
                            </p>
                            <div class="form_Elementleri">
                                <asp:TextBox ID="Kredi_Karti_Taksit_AdSoyadBox" runat="server" placeholder="Kart Üzerindeki Ad Soyad" CssClass="TextBox_F" />
                                <br />
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator1" runat="server" ErrorMessage="Ad ve Soyadı Yazınız."
                                    ControlToValidate="Kredi_Karti_Taksit_AdSoyadBox" Display="None" ValidationGroup="KrediTaksit"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="Kredi_Karti_Taksit_KartNoBox" runat="server" placeholder="Kart Numarası" CssClass="TextBox_F" onkeypress="return numbersonly(this, event)" MaxLength="16" />
                                <br />
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator2" runat="server" ErrorMessage="Kart Numarasını Yazınız."
                                    ControlToValidate="Kredi_Karti_Taksit_KartNoBox" Display="None" ValidationGroup="KrediTaksit"></asp:RequiredFieldValidator>
                                <div style="width: 1000px; float: left; height: 50px;">
                                    <div style="width: 380px; float: left;">
                                        <asp:TextBox ID="Kredi_Karti_Taksit_GuvenlikBox" runat="server" placeholder="Güvenlik Kodu (CVV2)" CssClass="TextBox_F" />
                                        <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator3" runat="server" ErrorMessage="Güvenlik Kodunu Yazınız."
                                            ControlToValidate="Kredi_Karti_Taksit_GuvenlikBox" Display="None" ValidationGroup="KrediTaksit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div style="width: 50px; padding-top: 20px; float: left;">
                                        <%-- <a href="#" class="Footer_Link">Nedir ?</a>--%>
                                    </div>
                                </div>
                                <br />
                                <asp:DropDownList ID="Kredi_Karti_Taksit_SonKullanmaAy" runat="server" CssClass="DropDown_Kucuk_F">
                                    <asp:ListItem Value="0">Son Kullanma (Ay)</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator4" runat="server" ErrorMessage="Kartın Son Kullanma Yılını Seçiniz. "
                                    ControlToValidate="Kredi_Karti_Taksit_SonKullanmaAy" Display="None" ValidationGroup="KrediTaksit" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="Kredi_Karti_Taksit_SonKullanmaSene" runat="server" CssClass="DropDown_Kucuk_F">
                                    <asp:ListItem Value="0">Son Kullanma (Sene)</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                    <asp:ListItem>2024</asp:ListItem>
                                    <asp:ListItem>2025</asp:ListItem>
                                    <asp:ListItem>2026</asp:ListItem>
                                    <asp:ListItem>2027</asp:ListItem>
                                    <asp:ListItem>2028</asp:ListItem>
                                    <asp:ListItem>2029</asp:ListItem>
                                    <asp:ListItem>2030</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator5" runat="server" ErrorMessage="Kartın Son Kullanma Yılını Seçiniz. "
                                    ControlToValidate="Kredi_Karti_Taksit_SonKullanmaSene" Display="None" ValidationGroup="KrediTaksit" InitialValue="0"></asp:RequiredFieldValidator>
                                <br />
                                <asp:DropDownList ID="Kredi_Karti_Taksit_BankaDrop" runat="server" CssClass="DropDown_Kucuk_F" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="Kredi_Karti_Taksit_BankaDrop_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator6" runat="server" ErrorMessage="Banka Seçiniz."
                                    ControlToValidate="Kredi_Karti_Taksit_BankaDrop" Display="None" ValidationGroup="KrediTaksit"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="Kredi_Karti_Taksit_TaksitSayisi_Drop" runat="server" CssClass="DropDown_Kucuk_F" AppendDataBoundItems="true" Enabled="false">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="KKTaksit_RequiredFieldValidator7" runat="server" ErrorMessage="Taksit Seçiniz. "
                                    ControlToValidate="Kredi_Karti_Taksit_TaksitSayisi_Drop" Display="None" ValidationGroup="KrediTaksit"></asp:RequiredFieldValidator>
                                <br />
                                <asp:TextBox ID="Kredi_Karti_Taksit_SiparisNotuBox" runat="server" placeholder="Sipariş Notunuz" CssClass="TextBox_F" TextMode="MultiLine" Height="100" MaxLength="240" /><br />
                                <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                    <asp:CheckBox ID="Kredi_Karti_Taksit_SozlesmeOkudumCheck" runat="server" /><a class="Footer_Link" href="SatisSozlesmesi.aspx" target="_blank">Satış Sözleşmesini</a>,okudum kabul ediyorum.<br />
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Sözleşmeyi Kabul Ediniz." ClientValidationFunction="ValidateCheckBox_KrediTaksit" ValidationGroup="KrediTaksit" ForeColor="Red"></asp:CustomValidator>
                                </div>
                                <asp:Button ID="Kredi_Karti_Taksit_GeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="Kredi_Karti_Taksit_GeriDonBtn_Click" />
                                <asp:Button ID="Kredi_Karti_Taksit_TamamBtn" runat="server" CssClass="btn-orange" Text="Tamam" OnClick="Kredi_Karti_Taksit_TamamBtn_Click" ValidationGroup="KrediTaksit" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="KrediTaksit" />
                            </div>
                        </div>
                        <div id="EFT_Havale_Div" style="float: left; width: 980px; padding: 10px 0px;">
                            <div class="Hakkimizda_Baslik">
                                EFT / Havale ile Ödeme
                            </div>
                            <p>
                                <span style="font-weight: bold; font-size: 14px;">Havale / EFT ile yaptığınız alışverişlerde ödemenin 3 gün içerisinde gerçekleşmesi gerekmektedir. 3 gün içerisinde yapılmayan ödemelerde satın alma işleminiz iptal edilecektir.
                                <br />
                                    EFT / Havale yapılacak banka bilgileri listelenmiştir.<br />
                                    Size uygun olan bankaya havale yaptıktan sonra <a class="Footer_Link" target="_blank" href="OdemeBildirimFormu.aspx">"Ödeme Bildirim Formu"</a> doldurmayı unutmayınız.</span>
                            </p>
                            <br />
                            <br />
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
                           <div style="clear:both;"></div>
                            <asp:TextBox ID="EftHavale_NotuBox" runat="server" placeholder="Sipariş Notunuz" CssClass="TextBox_F" TextMode="MultiLine" Height="100" MaxLength="240" /><br />
                            <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                <asp:CheckBox ID="EftHavale_SatisSozlesmesi_CheckBox" runat="server" /><a class="Footer_Link" href="SatisSozlesmesi.aspx" target="_blank">Satış Sözleşmesini</a>,okudum kabul ediyorum.
                            <br />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Sözleşmeyi Kabul Ediniz." ClientValidationFunction="ValidateCheckBox_Havale" ValidationGroup="EftHavale" ForeColor="Red"></asp:CustomValidator>
                            </div>
                            <asp:Button ID="EftHavaleGeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="EftHavaleGeriDonBtn_Click" />
                            <asp:Button ID="EftHavaleTamamBtn" runat="server" CssClass="btn-orange" Text="Tamam" OnClick="EftHavaleTamamBtn_Click" ValidationGroup="EftHavale" />
                        </div>
                        <div id="KapidaOdeme_Div" style="float: left; width: 980px; padding: 10px 0px; display: none;">
                            <div class="Hakkimizda_Baslik">
                                Kapıda Nakit Ödeme
                            </div>
                            <p>
                                <span style="font-weight: bold; font-size: 14px;">Kapıda Ödeme İle İlgili Şartlar</span>
                            </p>
                            <ul style="list-style-type: circle; font-size: 13px; font-family: Arial;">
                                <li>Türkiye'nin her yerine kapıda ödeme hizmeti bulunmaktadır. Hizmet Bedeli "<asp:Label ID="KapidaOdemeBedeliLbl" runat="server"></asp:Label>
                                    TL" dir.</li>
                                <li>Sadece "Nakit Ödeme" geçerlidir.</li>
                                <li>Müşteri Temsilcimiz kapıda ödeme talebiniz için sizi arayarak onay alıcaktır.</li>
                                <li>Onayı alınmayan siparişler iptal edilir.</li>
                            </ul>
                            <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                <asp:CheckBox ID="KapidaOdeme_CheckBox" runat="server" /><a class="Footer_Link"  href="SatisSozlesmesi.aspx" target="_blank">Satış Sözleşmesini</a>,okudum kabul ediyorum.<br />
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Sözleşmeyi Kabul Ediniz." ClientValidationFunction="ValidateCheckBox_Kapida" ValidationGroup="Kapida" ForeColor="Red"></asp:CustomValidator>
                            </div>
                            <asp:TextBox ID="KapidaOdeme_Notubox" runat="server" placeholder="Sipariş Notunuz" CssClass="TextBox_F" TextMode="MultiLine" Height="100" MaxLength="240" /><br />
                            <asp:Button ID="KapidaOdeme_GeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="KapidaOdeme_GeriDonBtn_Click" />
                            <asp:Button ID="KapidaOdeme_TamamBtn" runat="server" CssClass="btn-orange" Text="Tamam" OnClick="KapidaOdeme_TamamBtn_Click" ValidationGroup="Kapida" />
                        </div>
                        <div id="PaypalIleOdeme_Div" style="float: left; width: 980px; padding: 10px 0px; display: none;">
                            <div class="Hakkimizda_Baslik">
                                Paypal ile Ödeme
                            </div>
                            <p>
                                <span style="font-weight: bold; font-size: 14px;">Paypal ile ödeme yapabilmeniz için aktif hesabınızın olması gerekiyor.</span>
                            </p>
                            <br />
                            <br />
                            <img src="Image/paypal-button.jpg" alt="Paypal ile Ödeme yapabilirsiniz." />
                            <div class="YaziKarekter_Light" style="margin-top: 20px;">
                                <asp:CheckBox ID="Paypal_CheckBox" runat="server" /><a class="Footer_Link"  href="SatisSozlesmesi.aspx" target="_blank">Satış Sözleşmesini</a>,okudum kabul ediyorum.<br />
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Sözleşmeyi Kabul Ediniz." ClientValidationFunction="ValidateCheckBox_Paypal" ValidationGroup="Paypal" ForeColor="Red"></asp:CustomValidator>
                            </div>
                            <asp:TextBox ID="Paypal_NotuBox" runat="server" placeholder="Sipariş Notunuz" CssClass="TextBox_F" TextMode="MultiLine" Height="100" MaxLength="240" /><br />
                            <asp:Button ID="Paypal_GeriDonBtn" runat="server" CssClass="btn-orange" Text="Geri Dön" OnClick="Paypal_GeriDonBtn_Click" />
                            <asp:Button ID="Paypal_TamamBtn" runat="server" CssClass="btn-orange" Text="Tamam" ValidationGroup="Paypal" OnClick="Paypal_TamamBtn_Click" />
                        </div>
                </asp:View>
                <asp:View ID="IslemTamam_Tek_KrediKarti" runat="server">
                    <div class="Basarili">
                        <span class="Hakkimizda_Baslik">Siparişiniz Onaylandı<br />
                            Siparişiniz başarıyla oluşturulmuştur.<br />
                            Sipariş No:
                            <asp:Label ID="SiparisNo_Tek_KrediKarti_Lbl" runat="server"></asp:Label><br />
                            Kredi kartınızdan çekilen tutar:
                            <br />
                            <asp:Label ID="Odeme_Kredi_Karti_Tek_TutarLbl" runat="server"></asp:Label>
                            (Peşin Ödeme)
                        </span>
                        <br />
                        <br />
                    </div>
                    <br />
                    <div class="Hakkimizda_Icerik" style="float: left; width: 970px; height: 370px;">
                        <div style="float: left; width: 970px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Sipariş onaylandıktan sonra e-posta alacaksınız.</li>
                                <li>Ürünlerimizi
                                    <asp:Label ID="KargoAdi_Kredi_Karti_Tek_Lbl" runat="server"></asp:Label>
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
                                <asp:Label ID="FirmaAdi_Kredi_Karti_TekLbl" runat="server"></asp:Label>
                                    &nbsp;herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Kredi_Karti_TekLbl" runat="server"></asp:Label>
                        &nbsp;tercih ettiğiniz için teşekkürler.
                        <br />
                        <br />
                        Alışverişe dönmek için <a href="Default.aspx" title="Anasayfa" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        Sipariş takibe gitmek için <a href="Hesabim.aspx" title="Hesabım" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                </asp:View>
                <asp:View ID="IslemTamam_Taksit_Kredi_Karti" runat="server">
                    <div class="Basarili">
                        <span class="Hakkimizda_Baslik">Siparişiniz Onaylandı<br />
                            Siparişiniz başarıyla oluşturulmuştur.<br />
                            Sipariş No:
                            <asp:Label ID="SiparisNo_Taksit_KrediKarti_Lbl" runat="server"></asp:Label><br />
                            Kredi kartınızdan çekilen tutar:
                            <br />
                            <asp:Label ID="Odeme_Kredi_Karti_Taksit_TutarLbl" runat="server"></asp:Label>
                            (Taksitli Ödeme)
                        </span>
                        <br />
                        <br />
                    </div>
                    <br />
                    <div class="Hakkimizda_Icerik" style="float: left; width: 970px; height: 370px;">
                        <div style="float: left; width: 970px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Sipariş onaylandıktan sonra e-posta alacaksınız.</li>
                                <li>Ürünlerimizi
                                    <asp:Label ID="KargoAdi_Kredi_Karti_Taksit_Lbl" runat="server"></asp:Label>
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
                                <asp:Label ID="FirmaAdi_Kredi_KartiTaksit_Lbl" runat="server"></asp:Label>
                                    &nbsp;herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Kredi_Karti_TaksitLbl" runat="server"></asp:Label>
                        &nbsp;tercih ettiğiniz için teşekkürler.
                        <br />
                        <br />
                        Alışverişe dönmek için <a href="Default.aspx" title="Anasayfa" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        Sipariş takibe gitmek için <a href="Hesabim.aspx" title="Hesabım" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                </asp:View>
                <asp:View ID="IslemTamam_Havale_EFT" runat="server">
                    <div class="Basarili">
                        <span class="Hakkimizda_Baslik">Siparişiniz Onaylandı<br />
                            Siparişiniz başarıyla oluşturulmuştur.<br />
                            Sipariş No:
                            <asp:Label ID="SiparisNo_EFT_Havale_Lbl" runat="server"></asp:Label>
                            <br />
                            Havale / EFT yapmanız gereken tutar:
                            <br />
                            <asp:Label ID="Odeme_Havale_TutarLbl" runat="server"></asp:Label>
                        </span>
                        <br />
                        <br />
                    </div>
                    <br />
                    <div class="Hakkimizda_Icerik" style="float: left; width: 970px; height: 650px;">
                        <div style="float: left; width: 970px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Ödemenizi 3 iş günü içerisinde banka hesaplarımıza yapmanız gerekiyor.</li>
                                <li>Havale / EFT yaparken işlem açıklama kısmına mutlaka sipariş numaranızı yazınız.</li>
                                <li>Sipariş onaylandıktan sonra e-posta alacaksınız.</li>
                                <li>Ürünlerimizi
                                    <asp:Label ID="KargoAdi_Havale_EftLbl" runat="server"></asp:Label>
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
                                <asp:Label ID="FirmaAdi_Havale_EFTLbl" runat="server"></asp:Label>
                                    &nbsp;herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Havale_Eft" runat="server"></asp:Label>
                        &nbsp;tercih ettiğiniz için teşekkürler.
                        <br />
                        <br />
                        Alışverişe dönmek için <a href="Default.aspx" title="Anasayfa" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        Sipariş takibe gitmek için <a href="Hesabim.aspx" title="Hesabım" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        <div class="Hakkimizda_Baslik">
                            Banka Hesap Bilgileri
                        </div>
                        <asp:Repeater ID="Odeme_EFT_Havale_Repeater" runat="server">
                            <ItemTemplate>
                                <div class="Hakkimizda_Sol_Satir">
                                    <div class="Hakkimizda_Logo">
                                        <img src='<%# Eval("Logo","Image/{0}") %>' alt='<%# Eval("BankaAdi")%>' />
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
                </asp:View>
                <asp:View ID="IslemTamam_Kapida_Odeme" runat="server">
                    <div class="Basarili">
                        <span class="Hakkimizda_Baslik">Siparişiniz Onaylandı<br />
                            Siparişiniz başarıyla oluşturulmuştur.<br />
                            Sipariş No:
                            <asp:Label ID="SiparisNo_Kapida_Odeme_Lbl" runat="server"></asp:Label>
                            <br />
                            Kapıda ödeme için yapmanız gereken tutar:
                            <br />
                            <asp:Label ID="Odeme_KapidaOdeme_TutarLbl" runat="server"></asp:Label>
                        </span>
                        <br />
                        <br />
                    </div>
                    <br />
                    <div class="Hakkimizda_Icerik" style="float: left; width: 970px; height: 370px;">
                        <div style="float: left; width: 970px;">
                            <ul class="OdemeSonucu_Ul">
                                <li>Sadece "Nakit Ödeme" geçerlidir.</li>
                                <li>Sipariş onaylandıktan sonra e-posta alacaksınız.</li>
                                <li>Ürünlerimizi
                                    <asp:Label ID="KargoAdi_Kapida_OdemeLbl" runat="server"></asp:Label>
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
                                <asp:Label ID="FirmaAdi_Kapida_Odeme_Lbl" runat="server"></asp:Label>
                                    &nbsp;herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Kapida_OdemeLbl" runat="server"></asp:Label>
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
                </asp:View>
                <asp:View ID="IslemTamam_Paypal_Odeme" runat="server">
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
                                    ile gönderilecektir.</li>
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
                                    herhangi bir sorumluluk kabul etmez.</li>
                            </ul>
                        </div>
                        Alışverişleriniz'de
                        <asp:Label ID="FirmaAdi_Tesekkur_Paypal_OdemeLbl" runat="server"></asp:Label>
                        tercih ettiğiniz için teşekkürler.
                        <br />
                        <br />
                        Alışverişe dönmek için <a href="Default.aspx" title="Anasayfa" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                        Sipariş takibe gitmek için <a href="Hesabim.aspx" title="Hesabım" class="Footer_Link">tıklayın.</a>
                        <br />
                        <br />
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="DataList1" />
            <asp:PostBackTrigger ControlID="SepetAdetGuncelleBtn" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>


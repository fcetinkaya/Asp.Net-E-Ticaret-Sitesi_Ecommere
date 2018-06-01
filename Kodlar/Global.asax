<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add("SiparisDetay", new Route("SiparisDetay-{SiparisNo}.aspx", new PageRouteHandler("~/SiparisDetay.aspx")));
        RouteTable.Routes.Add("KargoDetay", new Route("KargoDetay-{KargoNo}.aspx", new PageRouteHandler("~/KargoDetay.aspx")));
        RouteTable.Routes.Add("UrunDetay", new Route("1294{UrunID}7454-{TlfAdi}-{ModelAdi}-{KateAdi}-cep-telefonu-aksesuarlari-{UrunAdi}.aspx", new PageRouteHandler("~/UrunDetay.aspx")));
        RouteTable.Routes.Add("Kategori", new Route("cep-telefonu-aksesuari-kategorisi-{KatAdi}.aspx", new PageRouteHandler("~/KategoriListe.aspx")));
        RouteTable.Routes.Add("AltKategori", new Route("cep-telefonu-aksesuarlari-kategorisi-{KateAdi}.aspx", new PageRouteHandler("~/KategoriListe_Alt.aspx")));
        RouteTable.Routes.Add("KategoriModel", new Route("{TlfAdi}-{ModelAdi}-cep-telefonu-aksesuari-kategorisi-{KatAdi}.aspx", new PageRouteHandler("~/KategoriModelListe.aspx")));
        RouteTable.Routes.Add("KategoriTelefon", new Route("{TlfAdi}-cep-telefonu-aksesuari-kategorisi-{KatAdi}.aspx", new PageRouteHandler("~/KategoriTelefonListe.aspx")));
        RouteTable.Routes.Add("Model", new Route("{TlfAdi}-{ModelAdi}-cep-telefonu-aksesuarlari.aspx", new PageRouteHandler("~/ModelListe.aspx")));
        RouteTable.Routes.Add("Telefon", new Route("{TlfAdi}-cep-telefonu-aksesuarlari.aspx", new PageRouteHandler("~/TelefonListe.aspx")));

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

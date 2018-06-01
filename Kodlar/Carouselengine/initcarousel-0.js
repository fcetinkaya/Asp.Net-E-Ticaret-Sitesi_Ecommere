jQuery(document).ready(function(){
    var scripts = document.getElementsByTagName("script");
    var jsFolder = "";
    for (var i= 0; i< scripts.length; i++)
    {
        if( scripts[i].src && scripts[i].src.match(/initcarousel-0\.js/i))
            jsFolder = scripts[i].src.substr(0, scripts[i].src.lastIndexOf("/") + 1);
    }
    if ( typeof html5Lightbox === "undefined" )
    {
        html5Lightbox = jQuery(".html5lightbox").html5lightbox({
            skinsfoldername:"",
            jsfolder:jsFolder
        });
    }
    jQuery(".amazingcarousel-0").amazingcarousel({
        jsfolder:jsFolder,
        width:220,
        height:220,
        skinsfoldername:"",
        interval:5000,
        itembottomshadowimagetop:99,
        random:false,
        direction:"horizontal",
        arrowheight:48,
        itembackgroundimagewidth:100,
        skin:"Highlight",
        responsive:true,
        bottomshadowimage:"bottomshadow-110-95-0.png",
        navstyle:"bullets",
        enabletouchswipe:true,
        backgroundimagetop:-40,
        arrowstyle:"always",
        bottomshadowimagetop:95,
        transitionduration:1000,
        hoveroverlayimage:"hoveroverlay-64-64-5.png",
        itembottomshadowimage:"itembottomshadow-100-98-3.png",
        showitembottomshadow:true,
        transitioneasing:"easeOutExpo",
        showitembackgroundimage:false,
        itembackgroundimage:"",
        playvideoimagepos:"center",
        circular:true,
        arrowimage:"arrows-48-48-2.png",
        showbottomshadow:false,
        screenquery:{
	mobile: {
		screenwidth: 225,
		visibleitems: 4
	}
},
        navimage:"bullet-16-16-0.png",
        itembackgroundimagetop:0,
        showbackgroundimage:false,
        showplayvideo:true,
        spacing:5,
        scrollitems:1,
        showhoveroverlay:true,
        scrollmode:"page",
        navdirection:"horizontal",
        itembottomshadowimagewidth:100,
        backgroundimage:"",
        arrowwidth:48,
        pauseonmouseover:true,
        navmode:"page",
        arrowhideonmouseleave:1000,
        navwidth:16,
        navspacing:8,
        playvideoimage:"playvideo-64-64-0.png",
        visibleitems:4,
        navswitchonmouseover:false,
        bottomshadowimagewidth:110,
        autoplay:true,
        backgroundimagewidth:110,
        loop:0,
        navheight:16
    });
});
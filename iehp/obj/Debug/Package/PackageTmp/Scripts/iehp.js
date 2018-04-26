(function ($) {
    $(document).ready(function () {
        $(".eventBlock2").hide();
        $.when(
            //doctor Tab
            $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Tab1=DoctorTab&Qty1=3&Qty2=3&Qty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data1) {
                $(".tabWrapper").html(data1);
            })
        ).then(function () {
            console.log("loading successful");
        });
        
        //Tabs Section
        $("#doctorTab").on("click", function () {
            $(".eventBlock2, #urg, #pharm").hide();
            $('#doc').show();
            $.when(
                $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Tab1=DoctorTab&Qty1=3&Qty2=3&Qty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data1) {
                    $(".tabWrapper").html(data1);
                })
            );
        });

        $("#urgentTab").on("click", function () {
            $(".eventBlock2, #doc, #pharm").hide();
            $('#urg').show();
            $.when(
                $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Tab1=UrgentTab&Qty1=3&Qty2=3&Qty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data1) {
                    $(".tabWrapper").html(data1);
                })
            );
        });

        $("#pharmacyTab").on("click", function () {
            $(".eventBlock2, #doc, #urg").hide();
            $('#pharm').show();
            $.when(
                $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Tab1=PharmacyTab&Qty1=3&Qty2=3&Qty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data1) {
                    $(".tabWrapper").html(data1);
                })
            );
        });
       
        $(document).on("click", ".eventLink1", function () {
            $('.eventLink2').removeClass('active');
            $(".eventBlock1").css('display', 'flex');
            $(".eventBlock2").hide();
        });

        $(document).on("click", ".eventLink2", function () {
            $('.eventLink1').removeClass('active');
            $(".eventBlock2").css('display', 'flex');
            $(".eventBlock1").hide();
        });

        $(document).on("mouseenter", "#mainNavDropLink, #mainNavDropDown", function () {
            $("#mainNavDropDown").show();
        });

        $(document).on("mouseleave", "#mainNavDropLink, #mainNavDropDown", function () {
            $("#mainNavDropDown").hide();
        });

        $(document).on("mouseenter", "#searchLinkWrapper", function () {
            $("#searchLinkWrapper").addClass('open');
        });

        $(document).on("mouseleave", "#searchBox, #searchLinkWrapper", function () {
            $("#searchLinkWrapper").removeClass('open');
        });

        //Mega Nav's
        $(document).on("mouseenter", "#megaNavToggle", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").hide();
            $("#fadMegaNavMenu").css('display', 'block');
        });

        //FAD Mega Nav
        $(document).on("mouseenter", "#megaNavToggle .navMenu li:nth-child(1)", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").hide();
            $("#fadMegaNavMenu").css('display', 'block');
        });

        //FM Mega Nav
        $(document).on("mouseenter", "#megaNavToggle .navMenu li:nth-child(2)", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").hide();
            $("#fmMegaNavMenu").css('display', 'block');
        });

        //FP Mega Nav
        $(document).on("mouseenter", "#megaNavToggle .navMenu li:nth-child(3)", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").hide();
            $("#fpMegaNavMenu").css('display', 'block');
        });

        //FC Mega Nav
        $(document).on("mouseenter", "#megaNavToggle .navMenu li:nth-child(4)", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").hide();
            $("#fcMegaNavMenu").css('display', 'block');
        });

        //Close mega navs
        $(document).on("mouseleave", "#subNavMenuWrapper", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").css('display', 'none');
        });

        $(document).on("mouseleave", "#fadMegaNavMenu", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").css('display', 'none');
        });

        $(document).on("mouseleave", "#fmMegaNavMenu", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").css('display', 'none');
        });

        $(document).on("mouseleave", "#fpMegaNavMenu", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").css('display', 'none');
        });

        $(document).on("mouseleave", "#fcMegaNavMenu", function () {
            $("#fadMegaNavMenu, #fmMegaNavMenu, #fpMegaNavMenu, #fcMegaNavMenu").css('display', 'none');
        });
    });
})(jQuery);


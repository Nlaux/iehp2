(function ($) {
    var docCount, urgCount, pharmCount;
    docCount = 0, urgCount = 0, pharmCount = 0;

    $(document).ready(function () {
        $(".eventBlock2").hide();

        //Menus
        $.when(
            //TopNav Menus
            //$.get('/api/sitecore/Navigation/NavigationCtrl?Guid1=C9D8CBFA-D320-4417-A944-F74064DA1FF3&Guid2=337C22C2-3DCA-4C74-B406-0880EBA15637&Guid3=99DBDCC1-97EF-4E56-A1C3-CE6A3C92174D&Guid4=99DBDCC1-97EF-4E56-A1C3-CE6A3C92174D&Guid5=99DBDCC1-97EF-4E56-A1C3-CE6A3C92174D&Guid6=99DBDCC1-97EF-4E56-A1C3-CE6A3C92174D&Pv=/Views/Shared/MainNavCtrl.cshtml', function (data2) {
            //    $("#mainNavWrapper").html(data2);
            //}),
            //footerNav Menu
            //$.get('/api/sitecore/Navigation/NavigationCtrl?Guid1=6C4754EE-B9F9-47E0-B51B-B9765707AA74&Guid2=163904B8-FA80-4659-9E22-CE7A791B927C&Guid3=9E570B09-3FBF-4495-8805-75B75EA5D94B&Guid4=8C077CF0-7F39-4DF5-8BFC-7E0EE2FCF9ED&Guid5=87DEA43C-0008-4ACC-9364-C0AD2F80A4B6&Guid6=1384B6B0-77A6-44F7-B95F-E5DDAB0B3ED3&Pv=/Views/Shared/_FooterNavCtrl.cshtml', function (data3) {
            //    $("#footerLinks").html(data3);
            //}),
            //doctor Tab
            $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Guid1=CDF3A3AC-7F8A-4742-8CBB-AA8839DDE0B6&Guid2=1E899605-1289-4A48-9C30-DC0C93E16D3A&Guid3=AF97CA61-EE55-47C4-A086-8DC6126F25C0&GuidQty1=3&GuidQty2=3&GuidQty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data4) {
                $(".tabWrapper").html(data4);
            })
        ).then(function () {
            console.log("loading successful");
        });
        
        //Tabs Section
        $("#doctorTab").on("click", function () {
            $(".eventBlock2, #urg, #pharm").hide();
            $('#doc').show();

            if (docCount < 1) {
                $.when(
                    $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Guid1=CDF3A3AC-7F8A-4742-8CBB-AA8839DDE0B6&Guid2=1E899605-1289-4A48-9C30-DC0C93E16D3A&Guid3=AF97CA61-EE55-47C4-A086-8DC6126F25C0&GuidQty1=3&GuidQty2=3&GuidQty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data) {
                        $("#docTab").html(data);
                    })
                );
                docCount++;
            }
        });

        $("#urgentTab").on("click", function () {
            $(".eventBlock2, #doc, #pharm").hide();
            $('#urg').show();

            if (urgCount < 1) {
                $.when(
                    $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Guid1=068BD40E-ECA6-4F46-9EED-351A0AB2B991&Guid2=407CEDA7-2315-4F5F-BE6F-B8DB4A1505B0&Guid3=C1CAFEA0-2F3A-47FA-8102-E5A167EF8886&GuidQty1=3&GuidQty2=3&GuidQty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data) {
                        $("#ucTab").html(data);
                    })
                );
                urgCount++;
            }
        });

        $("#pharmacyTab").on("click", function () {
            $(".eventBlock2, #doc, #urg").hide();
            $('#pharm').show();

            if (pharmCount < 1) {
                $.when(
                    $.get('/api/sitecore/TabWrapper/TabWrapperCtrl?Guid1=FB878BA8-7D65-4DF4-BE8E-42A3D0D05AA1&Guid2=7884BEFE-F22C-45DE-882C-9A0E79145CF3&Guid3=5BF74B8F-CE72-4FD6-8749-413AC6A00A92&GuidQty1=3&GuidQty2=3&GuidQty3=3&pv=/Views/Components/_TabWrapperCtrl.cshtml', function (data) {
                        $("#pharmTab").html(data);
                    })
                );
                pharmCount++;
            }
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

        $(document).on("mouseenter", "#subNavDropLink, #subNavDropDown", function () {
            $("#subNavDropDown").show();
        });

        $(document).on("mouseleave", "#subNavDropLink, #subNavDropDown", function () {
            $("#subNavDropDown").hide();
        });

        $(document).on("mouseenter", "#searchLinkWrapper", function () {
            $(this).addClass('open');
        });

        $(document).on("mouseleave", "#searchBox, #searchLinkWrapper", function () {
            $("#searchLinkWrapper").removeClass('open');
        });

    });
})(jQuery);


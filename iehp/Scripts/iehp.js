(function ($) {
    var docCount, urgCount, pharmCount;
    docCount = 1, urgCount = 0, pharmCount = 0;

    $(document).ready(function () {
        $(".eventBlock2").hide();
        $.when(
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


(function ($) {
    $(document).ready(function () {
        $(".eventBlock2").hide();

        $("#eventCalendarBlockUrgent, #eventCalendarBlockPharmacy, #urgCTA, #urgSearch, #pharmCTA, #pharmSearch").hide();
        $("#eventCalendarBlockDoctor").css('display', 'flex');

        $.ajax({
            type: "GET",
            url: '/api/sitecore/EventCalendar/EventCalendarCtrl',
            contentType: "application/json; charset=utf-8",
            cache: false,
            beforeSend: function () {
                $('#loading').show();
            },
            complete: function () {
                $('#loading').hide();
            },
            success: function (data) {
                $("#eventCalendarBlockDoctor").html(data);
            },
            error: function (request, status, error) {
                console.log(request.responseText);
            }
        });

        $.ajax({
            type: "GET",
            url: '/api/sitecore/FadCalendar/FadCalendarCtrl',
            contentType: "application/json; charset=utf-8",
            cache: false,
            beforeSend: function () {
                $('#loading').show();
            },
            complete: function () {
                $('#loading').hide();
            },
            success: function (data) {
                $("#fadCTA").html(data);
            },
            error: function (request, status, error) {
                console.log(request.responseText);
            }
        });

        $("#doctorTab").on("click", function () {
            $("#eventCalendarBlockUrgent, #eventCalendarBlockPharmacy").hide();
            $("#eventCalendarBlockDoctor").css('display', 'flex');

            $.ajax({
                type: "GET",
                url: '/api/sitecore/EventCalendar/EventCalendarCtrl',
                contentType: "application/json; charset=utf-8",
                cache: false,
                beforeSend: function () {
                    $('#loading').show();
                },
                complete: function () {
                    $('#loading').hide();
                },
                success: function (data) {
                    $("#eventCalendarBlockDoctor").html(data);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });
        });

        $("#urgentTab").on("click", function () {
            $("#eventCalendarBlockDoctor, #eventCalendarBlockPharmacy").hide();
            $("#eventCalendarBlockUrgent").css('display', 'flex');

            $.ajax({
                type: "GET",
                url: '/api/sitecore/EventCalendar/UrgentTabCtrl',
                contentType: "application/json; charset=utf-8",
                cache: false,
                beforeSend: function () {
                    $('#loading').show();
                },
                complete: function () {
                    $('#loading').hide();
                },
                success: function (data) {
                    $("#eventCalendarBlockUrgent").html(data);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });
        });

        $("#pharmacyTab").on("click", function () {
            $("#eventCalendarBlockDoctor, #eventCalendarBlockUrgent").hide();
            $("#eventCalendarBlockPharmacy").css('display', 'flex');

            $.ajax({
                type: "GET",
                url: '/api/sitecore/EventCalendar/PharmacyTabCtrl',
                contentType: "application/json; charset=utf-8",
                cache: false,
                beforeSend: function () {
                    $('#loading').show();
                },
                complete: function () {
                    $('#loading').hide();
                },
                success: function (data) {
                    $("#eventCalendarBlockPharmacy").html(data);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });
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


        $("#subNavDropLink, #subNavDropDown").hover(
            function () {
                $("#subNavDropDown").show();
            },
            function () {
                $("#subNavDropDown").hide();
            }
        );

    });
})(jQuery);


$(document).ready(function () {
    $('.alert-success').delay(10000).fadeOut();
    $('.alert-danger').delay(10000).fadeOut();

    $(".sidebar-menu li").removeClass("active");
    $('.sidebar-menu li a').each(function () {
        if (window.location.pathname.split('?')[0].toLowerCase() == $(this).attr('href').split('?')[0].toLowerCase()) {
            if ($(this).parent().parent().hasClass("sidebar-submenu")) {
                $(this).parent().parent().addClass("show");
            }
            $(this).parent().addClass("active");
        }
    });

    $(".datepicker").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true
    });

    $('.datatable').DataTable({
        "dom": 'Bfrtlip',
        "pagingType": "full_numbers"
    });

    $("#HolidayDate").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true,
        beforeShowDay: $.datepicker.noWeekends
    });

    $("#HolidayDate").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true,
        beforeShowDay: $.datepicker.noWeekends
    });
});

function openNav() {
    if ($("#sidebar").hasClass("open")) {
        document.getElementById("sidebar").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        $("#sidebar").removeClass("open");
    }
    else {
        document.getElementById("sidebar").style.width = "275px";
        document.getElementById("main").style.marginLeft = "275px";
        $("#sidebar").addClass("open");
    }
}

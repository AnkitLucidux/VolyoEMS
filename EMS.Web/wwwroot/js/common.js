$(document).ready(function () {
    $('.alert-success').delay(10000).fadeOut();
    $('.alert-danger').delay(10000).fadeOut();
});

function openNav() {
    if ($("#sidebar").hasClass("open")) {
        document.getElementById("sidebar").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        $("#sidebar").removeClass("open");
    }
    else {
        document.getElementById("sidebar").style.width = "250px";
        document.getElementById("main").style.marginLeft = "250px";
        $("#sidebar").addClass("open");
    }
}


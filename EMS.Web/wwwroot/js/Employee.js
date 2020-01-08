$(document).ready(function () {
    if ($(".custom-file-label").text() != "Choose File...") {
        $(".profile-img-close").css("display", "block");
    }

    $(".custom-file-input").on('change', function () {
        changeProfileImage($(this));
    });

    $(".profile-img img").on('click', function () {
        $(".custom-file-input").trigger("click");
    });

    $(".profile-img-close").on('click', function () {
        $(this).prev().attr("src", "/Images/default_image.jpg");
        $(this).css("display", "none");
        $(".custom-file-input").val("");
    });
});

function changeProfileImage(input) {
    //var fileName = input.val().split("\\").pop();
    //input.next(".custom-file-label").text("Choose File...");
    //if (fileName != "") {
    //input.next(".custom-file-label").text(fileName);

    var reader = new FileReader();
    reader.onload = function (e) {
        $(".profile-img img").attr("src", e.target.result);
        $(".profile-img-close").css("display", "block");
    }
    reader.readAsDataURL(input[0].files[0]);
    //}
}
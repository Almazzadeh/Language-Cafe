$(document).ready(function () {

    // FOOD IMAGE SIZES
    var foodImageWidth = $('.foodimage').css("width");
    $('.foodimage').css('height', foodImageWidth);
    console.log(foodImageWidth);
    

    var categoryCircle = $('#menuPage .col-lg-1 .nav-link').width();
    $('#menuPage .col-lg-1 .nav-link').css('height', categoryCircle);


    // ACCORDION
    $('.collapse').on('shown.bs.collapse', function(){
        $(this).parent().find(".card-header").addClass("activeCard")
    })
    $('.collapse').on('hidden.bs.collapse', function(){
        $(this).parent().find(".activeCard").removeClass("activeCard")
    })

    // MENU PAGE GO TO BY CLICK CATEGORY NAME
    $('#menuPage .nav-link').on("click", function () {
        $('html, body').animate({ scrollTop: 0 }, 300);
    });



    // COPYRIGHT YEAR
    var year = (new Date()).getFullYear()
    $(".copyright span").html(year)
});

window.addEventListener("load", function () {
    $("#preloader").fadeOut();
})
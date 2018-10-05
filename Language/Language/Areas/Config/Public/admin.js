$(function () {

    //INPUT LENGTH CALCULATOR
    $(".form-control").each(function () {
        var input = $(this);

        if (input.data("val-length-max") != null) {
            var maxCount = input.data("val-length-max");
            var countHolder = input.parent().next().children(0);

            countHolder.html(input.val().length + "/" + maxCount);

            input.on("input", function () {
                countHolder.html(input.val().length + "/" + maxCount);

                if (input.val().length > maxCount) {
                    input.addClass("overlap");
                    countHolder.addClass("invalidCount");
                } else {
                    if (input.hasClass("overlap")) {
                        input.removeClass("overlap");
                        countHolder.removeClass("invalidCount");
                    }
                }
            })
        }
    })


    //DELETE FOOD WITH AJAX
    $(document).on("click", ".removeFood", function (e) {
        e.preventDefault();
        var foodId = $(this).data("foodid");
        var foodName = $(this).data("foodname");
        var foodImage = $(this).data("image");
        var folderName = $("#confirmModal img").data("folder")

        $("#confirmModal").find(".modal-body span").text(foodName).end().find(".modal-body img").attr("src", "/Public/images/"+ folderName + "/" + foodImage).end().modal("show");

        $("#foodIdHolder").val(foodId);
        $("#foodNameHolder").val(foodName);

    })

    $(document).on("click", ".confirmbtn", function (e) {
        var foodId = $("#foodIdHolder").val()

        $.ajax({
            url: "/AJAX/DeleteFood",
            dataType: "json",
            type: "GET",
            data: { foodId: foodId },
            success: function (res) {
                if (res.status == 200) {
                    $("#successModal").find(".modal-body span").text($("#foodNameHolder").val()).end().modal("show");
                }
            },
            error: function (res) {
                if (res.status == 404) {
                    $("#errorModal").modal("show");
                }
            }
        })

    })
})
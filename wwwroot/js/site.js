
// JavaScript code to handle the "Remove from favorites" button click
$(".add-remove-favorite-button").on("click", function () {
    var movieId = $(this).val();
    var button = $(this);
    $.ajax({
        url: `/Movie/AddOrRemoveFromFavorite/${movieId}`,
        type: "Post",
        success: function (response) {

            console.log("sucesssss");

            switch (response) {

                case "added":
                    $(button).text("Remove From Favorite");
                    $(button).removeClass("btn-success");
                    $(button).addClass("btn-danger");
                    break;

                case "removed":
                    $(button).text("Add To Favorite");
                    $(button).removeClass("btn-danger");
                    $(button).addClass("btn-success");
                    break;
            }
        },
        error: function () {
        }
    });
});

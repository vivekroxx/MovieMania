
// JavaScript code to handle the "Remove from favorites" button click
$(".remove-from-favorites-button").on("click", function() {
    var movieId = $(this).val();
    $.ajax({
        url: `/Movie/RemoveFromFavorite/${movieId}`,
        type: "Post",
        success: function() {
            console.log("Movie removed from favorites!");
            location.reload();
        },
        error: function() {
            console.log("Error removing movie from favorites.");
        }
    });
});


// JavaScript code to handle the "Add movie to favorites" button click
$(".add-to-favorites-button").on("click", function () {
    var movieId = $(this).val();
    $.ajax({
        url: `/Movie/AddToFavorite/${movieId}`,
        type: "Post",
        success: function () {
            console.log("Movie Added to favorites!");
            location.reload();
        },
        error: function () {
            console.log("Error adding movie to favorites.");
        }
    });
});
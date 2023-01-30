
// JavaScript code to handle the "Remove from favorites" button click
$(".remove-from-favorites-button").on("click", function() {
    var movieId = $(this).val();
    $.ajax({
        url: `/Movie/RemoveFromFavorite/${movieId}`,
        type: "Post",
        success: function() {
            alert("Movie removed from favorites!");
        },
        error: function() {
            alert("Error removing movie from favorites.");
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
            alert("Movie Added to favorites!");
        },
        error: function () {
            alert("Error adding movie to favorites.");
        }
    });
});
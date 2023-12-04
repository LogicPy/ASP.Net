function showAddReviewForm(movieId) {
    document.getElementById("movieId").value = movieId;
    document.getElementById("reviewForm").style.display = 'block';
}

function addReview() {
    var author = document.getElementById("reviewerName").value;
    var content = document.getElementById("content").value;

    // Update the DOM to display the new review
    var reviewsContainer = document.getElementById("reviewsContainer");
    var newReview = document.createElement("div");
    newReview.innerHTML = `<strong>${author}</strong>: ${content}`;
    reviewsContainer.appendChild(newReview);

    // Optionally send data to the server here using AJAX

    // Reset the form fields
    document.getElementById("reviewerName").value = "";
    document.getElementById("content").value = "";
}

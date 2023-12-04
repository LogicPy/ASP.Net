function showAddReviewForm(movieId) {
    document.getElementById("movieId").value = movieId;
    document.getElementById("reviewForm").style.display = 'block';
}

function addReview() {
    var review = {
        MovieId: document.getElementById("movieId").value,
        ReviewerName: document.getElementById("reviewerName").value,
        Content: document.getElementById("content").value,
        Rating: document.getElementById("rating").value
    };

    fetch('/Movies/AddReview', {
        method: 'POST',
        body: JSON.stringify(review),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert("Review added!");
                // Reset form and hide
                document.getElementById("reviewForm").style.display = 'none';
                document.getElementById("reviewerName").value = '';
                document.getElementById("content").value = '';
                document.getElementById("rating").value = '';
            }
        });
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ReviewSystem.Models;

public class MoviesController : Controller
{
    // Temporary in-memory storage
    private static List<Movie> _movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseDate = new DateTime(2010, 7, 16) },
        // Add more movies here
    };

    private static List<Review> _reviews = new List<Review>();

    public ActionResult Index()
    {
        return View(_movies);
    }

    public JsonResult GetReviews(int movieId)
    {
        var reviews = _reviews.Where(r => r.MovieId == movieId).ToList();
        return Json(reviews, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult AddReview(Review review)
    {
        // Add review to the list
        _reviews.Add(review);
        return Json(new { success = true });
    }


}

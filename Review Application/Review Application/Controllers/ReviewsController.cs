using System.Web.Mvc;
using Review_Application.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

public class ReviewsController : Controller
{
    private MovieReviewContext db = new MovieReviewContext();

    // GET: Reviews/Create
    public ActionResult Create()
    {
        // If you have a list of movies, use it to populate a dropdown
        ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
        return View();
    }

    // POST: Reviews/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ReviewId,ReviewerName,Content,Rating,MovieId")] Review review)
    {
        if (ModelState.IsValid)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index", "Movies"); // Redirect to movies list after adding review
        }

        // Re-populate the MovieId dropdown in case of error
        ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", review.MovieId);
        return View(review);
    }

    // Dispose the context when the controller is disposed
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}

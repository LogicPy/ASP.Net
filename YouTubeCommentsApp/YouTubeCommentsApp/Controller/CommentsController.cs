using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YouTubeCommentsApp.Models;

    public class CommentsController : Controller
    {
        private static List<Comment> _comments = new List<Comment>();

        // Action for GET request
        public ActionResult Index()
        {
            var viewModel = new CommentPageViewModel
            {
                Comments = _comments.OrderByDescending(c => c.PostedOn),
                NewComment = new NewCommentViewModel()
            };
            return View(viewModel);
        }

        // Action for POST request
        [HttpPost]
        public ActionResult PostComment(CommentPageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _comments.Add(new Comment
                {
                    Author = viewModel.NewComment.Author,
                    Text = viewModel.NewComment.Text,
                    PostedOn = DateTime.Now
                });

                return RedirectToAction("Index");
            }

            // If model state is not valid, return to the Index view with the current viewModel
            viewModel.Comments = _comments.OrderByDescending(c => c.PostedOn);
            return View("Index", viewModel);
        }
    }


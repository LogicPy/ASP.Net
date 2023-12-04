using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTubeCommentsApp.Models
{
    public class CommentPageViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public NewCommentViewModel NewComment { get; set; }
    }

}
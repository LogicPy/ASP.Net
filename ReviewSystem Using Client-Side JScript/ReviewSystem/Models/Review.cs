using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSystem.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ReviewerName { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }

}
namespace Review_Application.Models
{
	public class Review
	{
		public int ReviewId { get; set; }
		public string ReviewerName { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; } // Assuming a rating out of 5 or 10

		// Foreign key and navigation property for Movie
		public int MovieId { get; set; }
		public virtual Movie Movie { get; set; }
	}
}

namespace Review_Application.Models
{
	public class Movie
	{
		public int MovieId { get; set; }
		public string Title { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }

		// Navigation property for related reviews
		public virtual ICollection<Review> Reviews { get; set; }
	}
}

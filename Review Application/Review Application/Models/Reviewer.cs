namespace Review_Application.Models
{
    public class Reviewer
    {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    // Navigation property for related reviews
    public virtual ICollection<Review> Reviews { get; set; }
	}

}

using Microsoft.EntityFrameworkCore;
using Local_SearchEngine.Models; // This might not be necessary if ApplicationDbContext is already within this namespace

namespace Local_SearchEngine.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities
        public DbSet<SearchModel> SearchTable { get; set; } // Replace 'SearchModel' with your actual model class
    }
}

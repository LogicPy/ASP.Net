using Local_SearchEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Local_SearchEngine.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display search form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Handle search request
        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            var results = await _context.SearchTable
                                        .Where(s => s.Name.Contains(searchString) || s.Title.Contains(searchString))
                                        .ToListAsync();

            return View("Results", results); // Ensure you have a Results view
        }
    }

}

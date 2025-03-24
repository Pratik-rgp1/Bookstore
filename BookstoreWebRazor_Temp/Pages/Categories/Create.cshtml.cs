using BookstoreWebRazor_Temp.Data;
using BookstoreWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] //allows data from HTTP requests (such as form inputs or query parameters) to be automatically mapped to C# objects
        public Category Category { get; set; }
        public  CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            // Code executed when the page is loaded (HTTP GET request)

        }
        public IActionResult OnPost()
        {
            if (_db.Categories.Any(c => c.DisplayOrder == Category.DisplayOrder))
            {
                ModelState.AddModelError("Category.DisplayOrder", "This Display Order is already taken. Please choose another.");
            }
                
                if (!ModelState.IsValid)
            {
                return Page(); // If validation fails, reload the page with errors
            }

            
            // save Category to a database
            TempData["SuccessMessage"] = "Category created successfully!";
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
          

        }
    }
}

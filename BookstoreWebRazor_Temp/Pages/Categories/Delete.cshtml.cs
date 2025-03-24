using BookstoreWebRazor_Temp.Data;
using BookstoreWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreWebRazor_Temp.Pages.Categories
{
    [BindProperties] //allows data from HTTP requests (such as form inputs or query parameters) to be automatically mapped to C# objects
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }

        }
        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();

            // Store success message in TempData
            TempData["SuccessMessage"] = "Category deleted successfully.";

            return RedirectToPage("Index");


        }
    }
}

using BookstoreWebRazor_Temp.Data;
using BookstoreWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreWebRazor_Temp.Pages.Categories
{
        [BindProperties] //allows data from HTTP requests (such as form inputs or query parameters) to be automatically mapped to C# objects
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id!=null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
            
        }
        public IActionResult OnPost()
        {
            if (Category == null)
            {
                ModelState.AddModelError(string.Empty, "Category not found.");
                return Page();  // Stay on the same page if no category is found
            }

            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb == null)
            {
                ModelState.AddModelError(string.Empty, "Category does not exist.");
                return Page();  // Stay on the same page if the category doesn't exist
            }

            // Check if no changes were made (compare old and new values)
            if (categoryFromDb.Name == Category.Name && categoryFromDb.DisplayOrder == Category.DisplayOrder)
            {
                TempData["SuccessMessage"] = "Category not updated.";  // No update was made
                return RedirectToPage("Index");  // Stay on the same page
            }

            if (ModelState.IsValid)
            {
              

                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Category updated successfully.";
                return RedirectToPage("Index");  // Redirect after a successful update
            }

            return Page();  // Stay


        }
    }
}

        

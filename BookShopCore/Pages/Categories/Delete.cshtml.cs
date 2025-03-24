using BookShopCore.Database;
using BookShopCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShopCore.Pages.Categories
{
    [BindProperties]
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
            if (id != null || id != 0)
            {
                Category = _db.Category.FirstOrDefault(u => u.CategoryId == id);
            }
        }

        public IActionResult OnPost()
        {

            if(ModelState.IsValid)
            {
                _db.Category.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Catergory Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

using BookShop.Context;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _db;
        public CategoryController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Category.ToList();
            return View();
        }
    }
}

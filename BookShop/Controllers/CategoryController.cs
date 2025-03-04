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
            return View(objCategoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {

            if(obj.CategoryName==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName","The Order and Category Name cannot be same");
            }

            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

using BookShop.DataAccess.Context;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.BookShopAdmin.Controllers
{
    [Area("BookShopAdmin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CategoryController(IUnitOfWork db)
        {
            _unit = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unit.CategoryRepository.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {

            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "The Order and Category Name cannot be same");
            }

            if (ModelState.IsValid)
            {
                _unit.CategoryRepository.Add(obj);
                _unit.Save();
                TempData["success"] = "Category Created Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = _unit.CategoryRepository.GetFirstOrDefault(u => u.CategoryId == id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost]
        public IActionResult EditCategory(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unit.CategoryRepository.Update(obj);
                _unit.Save();
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = _unit.CategoryRepository.GetFirstOrDefault(u => u.CategoryId == id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unit.CategoryRepository.GetFirstOrDefault(u => u.CategoryId == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unit.CategoryRepository.Remove(obj);
            _unit.Save();
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}

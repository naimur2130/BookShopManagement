using BookShop.DataAccess.Context;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.Areas.BookShopAdmin.Controllers
{
    [Area("BookShopAdmin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unit = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unit.productRepository.GetAll().ToList();
            return View(objProductList);
        }

        //In this part create & update product will work from the same page
        public IActionResult UpsertProduct(int? id)
        {

            ProductViewModel model = new()
            {
                CategoryList = _unit.categoryRepository
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };

            if (id == null || id == 0)
            {
                //For create product
                return View(model);
            }
            else
            {
                //for update product
                model.Product = _unit.productRepository
                    .GetFirstOrDefault(u=>u.ProductId==id);

                return View(model);
            }
            
        }
        [HttpPost]
        public IActionResult UpsertProduct(ProductViewModel model,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\Product");

                    using (var filestream = new FileStream(Path.Combine(productPath,fileName),FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    model.Product.ProductImage = @"\images\Product\" + fileName;
                }
                _unit.productRepository.Add(model.Product);
                _unit.Save();
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                model.CategoryList = _unit.categoryRepository
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                });
                return View(model);
            }
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDB = _unit.productRepository.GetFirstOrDefault(u => u.ProductId == id);

            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unit.productRepository.GetFirstOrDefault(u => u.ProductId == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unit.productRepository.Remove(obj);
            _unit.Save();
            TempData["success"] = "Product Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}

using BookShop.DataAccess.Context;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.Areas.BookShopAdmin.Controllers
{
    [Area("BookShopAdmin")]
    [Authorize(Roles = SD.Admin_role)]
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
            List<Product> objProductList = _unit.productRepository.GetAll(includeProperties: "Category").ToList();
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
                    .GetFirstOrDefault(u => u.ProductId == id);

                return View(model);
            }

        }
        [HttpPost]
        public IActionResult UpsertProduct(ProductViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\Product");

                    if (!string.IsNullOrEmpty(model.Product.ProductImage))
                    {
                        //at first we have to delete the old image path

                        var oldPath = Path.Combine(wwwRootPath,
                            model.Product.ProductImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    model.Product.ProductImage = @"\images\Product\" + fileName;
                }
                if (model.Product.ProductId != 0)
                {
                    _unit.productRepository.Update(model.Product);
                    _unit.Save();
                    TempData["success"] = "Product Updated Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    _unit.productRepository.Add(model.Product);
                    _unit.Save();
                    TempData["success"] = "Product Created Successfully!";
                    return RedirectToAction("Index");
                }

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

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unit.productRepository.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objProductList});
        }

        [HttpDelete]
        public IActionResult DeleteIT(int? id)
        {
            var DeleteProduct = _unit.productRepository.GetFirstOrDefault(u=>u.ProductId==id);

            if(DeleteProduct == null)
            {
                return Json(new {success=false, message = "Error"});
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                DeleteProduct.ProductImage.TrimStart('\\'));

            if(System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unit.productRepository.Remove(DeleteProduct);
            _unit.Save();
            return Json(new { success = true, message = "Deleted Successfully!" });
        }
        #endregion
    }
}

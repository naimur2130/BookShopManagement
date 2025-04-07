using BookShop.DataAccess.Repository;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShop.Areas.BookShopCustomer.Controllers
{
    [Area("BookShopCustomer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unit)
        {
            _logger = logger;
            _unit = unit;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unit.productRepository.GetAll(includeProperties:"Category"); 
            return View(productList);
        }
        public IActionResult Details(int id)
        {
            Product product = _unit.productRepository.GetFirstOrDefault(u=>u.ProductId==id,includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

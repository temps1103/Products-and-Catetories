using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllProducts = _context.Products.OrderBy(l => l.Name).ToList();
            return View();
        }



        [HttpPost("add/product")]
        public IActionResult AddProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else{
                ViewBag.AllProducts = _context.Products.OrderBy(l => l.Name).ToList();
                return View("Index");
            }
        }


        [HttpGet("product/{ProdId}")]
        public IActionResult OneProduct(int ProdId)
        {
            ViewBag.OneProduct = _context.Products.Include(l => l.CategoriesSoldIn).ThenInclude(l => l.Category).FirstOrDefault(l => l.ProductId == ProdId);
            ViewBag.AllCategories = _context.Categories.OrderBy(l => l.Name).ToList();
            return View("One_Product");
        }



        [HttpPost("market/add")]
        public IActionResult AddMarket(Market newMarket, string option)
        {
            Console.WriteLine($"Your option is: {option}");
            _context.Markets.Add(newMarket);
            _context.SaveChanges();
            if(option == "product")
            {
                return Redirect($"/product/{newMarket.ProductId}");
            } else {
                return Redirect($"/category/{newMarket.CategoryId}");
            }
        }




        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = _context.Categories.OrderBy(l => l.Name).ToList();
            return View();
        }



        [HttpPost("add/category")]
        public IActionResult AddCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            } else{
                ViewBag.AllCategories = _context.Categories.OrderBy(l => l.Name).ToList();
                return View("Categories");
            }
        }

        [HttpGet("category/{CatId}")]
        public IActionResult OneCategory(int CatId)
        {
            ViewBag.OneCategory = _context.Categories.Include(l => l.ListOfProducts).ThenInclude(l => l.Product).FirstOrDefault(l => l.CategoryId == CatId);
            ViewBag.AllProducts = _context.Products.OrderBy(l => l.Name).ToList();
            return View("One_Category");
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

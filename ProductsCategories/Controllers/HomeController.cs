using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ProductsCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult AddProductPage()
        {
            ViewBag.AllProducts = dbContext.Products;
            return View("AddProduct");
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product newproduct)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(newproduct);
                dbContext.SaveChanges();
                return RedirectToAction("AddProductPage");
            }
            
            ViewBag.AllProducts = dbContext.Products;
            return View("AddProduct");
        }

        [HttpGet("products/{prodId}")]
        public IActionResult ProductPage(int prodId)
        {
            var SelectProd = dbContext.Products
                .Include(prod => prod.Associations)
                .ThenInclude(ass => ass.Category)
                .FirstOrDefault(prod => prod.ProductId == prodId);
            
            var ExcludedCats = dbContext.Categories
                .Include(c => c.Associations)
                .Where(c => c.Associations.All(a => a.ProductId != prodId));
            
            ViewBag.name = SelectProd.Name;
            ViewBag.excluded = ExcludedCats;
            return View(SelectProd);
        }

        [HttpGet("addcategorypage")]
        public IActionResult AddCategoryPage()
        {
            ViewBag.AllCategories = dbContext.Categories;
            return View("AddCategory");
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(Category newcategory)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(newcategory);
                dbContext.SaveChanges();
                return RedirectToAction("AddCategoryPage");
            }
            ViewBag.AllCategories = dbContext.Categories;
            return View("AddCategory");
        }

        [HttpGet("categories/{catId}")]
        public IActionResult CategoryPage(int catId)
        {
            var SelectCat = dbContext.Categories
                .Include(cat => cat.Associations)
                .ThenInclude(ass => ass.Product)
                .FirstOrDefault(cat => cat.CategoryId == catId);

            var ExcludedProds = dbContext.Products
                .Include(prod => prod.Associations)
                .Where(prod => prod.Associations.All(ass => ass.CategoryId != catId));

            ViewBag.excluded = ExcludedProds;
            return View(SelectCat);
        }

        [HttpPost("productAssociation")]
        public IActionResult AssociateProduct(Association newAss)
        {
            dbContext.Associations.Add(newAss);
            dbContext.SaveChanges();
            return View("ProductPage");
        }

        [HttpPost("categoryAssociation")]
        public IActionResult AssociateCategory(Association newAss)
        {
            dbContext.Associations.Add(newAss);
            dbContext.SaveChanges();
            return View("CategoryPage");
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

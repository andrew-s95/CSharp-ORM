using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefDish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefDish.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();
            ViewBag.chefs = AllChefs;
            return View();
        }

        [HttpGet("dishes")]
        public IActionResult DishPage()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(c => c.Creator).ToList();
            ViewBag.dishes = AllDishes;
            return View("Dishes");
        }

        [HttpGet("dishes/add")]
        public IActionResult AddDishPage()
        {
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.chefs = AllChefs;
            return View("AddDish");
        }

        [HttpPost("createdish")]
        public IActionResult AddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {   
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("DishPage");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chefs.ToList();
                ViewBag.chefs = AllChefs;
                return View("AddDish", dish);
            }
        }

        [HttpGet("chef/addpage")]
        public IActionResult AddChefPage()
        {
            return View("AddChef");
        }

        [HttpPost("createchef")]
        public IActionResult AddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                if(chef.Birthday >= DateTime.Today)
                {
                    ModelState.AddModelError("Birthday", "Date of Birth must be a date before today");
                    return View("AddChef");
                }
                Chef NewChef = chef;
                dbContext.Add(NewChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

    }
}

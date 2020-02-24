using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            ViewBag.allDishes = AllDishes;
            return View();
        }

        [HttpGet("add")]
        public IActionResult AddPage()
        {
            return View("Add");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish dish)
        {
            if(ModelState.IsValid)
            {
                Dish newdish = new Dish
                {
                    Name = dish.Name,
                    Chef = dish.Chef,
                    Tastiness = dish.Tastiness,
                    Calories = dish.Calories,
                    Description = dish.Description,
                };
                dbContext.Add(newdish);
                dbContext.SaveChanges();
                System.Console.WriteLine(newdish);

                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpGet("{Dish_ID}")]
        public IActionResult DishInfo(int Dish_ID)
        {
            List<Dish> SelectDish = dbContext.Dishes.Where(dish => dish.DishId == Dish_ID).ToList();
            ViewBag.DishInfo = SelectDish;
            return View("Info");
        }

        [HttpGet("editpage/{Dish_ID}")]
        public IActionResult EditPage(int Dish_ID)
        {
            Dish SelectDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == Dish_ID);
            ViewBag.EditDish = SelectDish;
            return View("Edit");
        }

        [HttpPost("edit/{Dish_ID}")]
        public IActionResult EditDish(Dish edited, int Dish_ID)
        {
            Dish SelectDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == Dish_ID);
            ViewBag.EditDish = SelectDish;
            if(ModelState.IsValid)
            {
                SelectDish.Name = edited.Name;
                SelectDish.Chef = edited.Chef;
                SelectDish.Description = edited.Description;
                SelectDish.Tastiness = edited.Tastiness;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        [HttpGet("delete/{Dish_ID}")]
        public IActionResult Delete(Dish deleted, int Dish_ID)
        {
            Dish SelectDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == Dish_ID);
            dbContext.Dishes.Remove(SelectDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


    
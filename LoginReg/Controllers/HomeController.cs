using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        //connect MyContext
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        //View Register Page
        public IActionResult Index() 
        {
            return View();
        }

        //Register
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                System.Console.WriteLine("Valid Email");
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User NewUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.FirstName,
                    Email = user.Email,
                    Password = user.Password,
                };
                System.Console.WriteLine("Working!");
                dbContext.Add(NewUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("Logged_UserId", NewUser.UserId);
                int? Logged_UserId = HttpContext.Session.GetInt32("Logged_UserId");
                return RedirectToAction("SuccessPage");
            }
            return View("Index");
        }

        //View Login Page
        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View("Login");
        }

        //Login
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                var DbUser = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
                if(DbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, DbUser.Password, user.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }

                HttpContext.Session.SetInt32("Logged_User", DbUser.UserId);
                int? Logged_User = HttpContext.Session.GetInt32("Logged_User");
                return RedirectToAction("SuccessPage");
            }
            else
            {
                return View("Login");
            }
        }

        //View Success Page
        [HttpGet("success")]
        public IActionResult SuccessPage()
        {
            if (HttpContext.Session.GetInt32("Logged_User") == null)
            {
                return RedirectToAction("Index");
            }
            return View("Success");
        }

        //Logout
        [HttpGet("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

    }
}

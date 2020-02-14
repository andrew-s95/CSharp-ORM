using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
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
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User NewUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.FirstName,
                    Email = user.Email,
                    Password = user.Password,
                };
                dbContext.Add(NewUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("Logged_UserId", NewUser.UserId); //Store logged in User's ID
                HttpContext.Session.SetString("Logged_UserName", NewUser.FirstName + NewUser.LastName); //Store logged in User's Name
                int? Logged_User = HttpContext.Session.GetInt32("Logged_UserId"); 
                return Redirect($"account/{Logged_User}");
            }
            else
            {
                return View("Index");
            }  
        }

        //View Login Page
        [HttpGet("loginpage")]
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

                HttpContext.Session.SetInt32("Logged_UserId", DbUser.UserId); //Store logged in User's ID
                HttpContext.Session.SetString("Logged_UserName", DbUser.FirstName); //Store logged in Users First name
                int? Logged_User = HttpContext.Session.GetInt32("Logged_UserId");

            return Redirect($"account/{Logged_User}");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("account/{UserId}")]
        public IActionResult AccountPage(int UserId)
        {
            if(HttpContext.Session.GetInt32("Logged_UserId") == null)
            {
                return RedirectToAction("Login");
            }
            List<Transaction> AllTrans = dbContext.Transactions.Include(u => u.BankUser).ToList();
            int Logged_User = (int)HttpContext.Session.GetInt32("Logged_UserId"); //storing logged user
            var Current_User = dbContext.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == Logged_User); //comparing the user to user in session

            var trans = Current_User.Transactions; //Using Transactions List from 
            trans.Reverse();
            double balance = 0;

            foreach(var money in trans)
            {
                balance += (double)money.Amount;
            }

            ViewBag.Balance = balance;
            ViewBag.AllTrans = trans;

            return View("Account");
        }

        [HttpPost("transaction")]
        public IActionResult MakeTransaction(Transaction transaction)
        {
            int? Logged_User = HttpContext.Session.GetInt32("Logged_UserId");
            //storing the user who made the transaction
            transaction.UserId = (int)HttpContext.Session.GetInt32("Logged_UserId"); 
            //Creating a variable to check balance is not negative
            double Worth = (double)transaction.Amount * -1;
            int Logged_UserId = (int)HttpContext.Session.GetInt32("Logged_UserId");
            var Current_User = dbContext.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == Logged_User); 
            //Only transactions from currently logged in users can are displayed
            var trans = Current_User.Transactions;
            double balance = 0;
            //looping through current user transactions to be displayed
            foreach(var money in trans)
            {
                balance += (double)money.Amount;
            }
            //create a variable with the balance to replace viewbag - compare with the relative amount
            if (Worth > balance)
            {
                TempData["ErrorMessage"] = "Can not withdraw more than your current balance.";
                return Redirect($"account/{Logged_User}");
            }
            else
            {
                System.Console.WriteLine("Hello");
            }
            dbContext.Add(transaction);
            dbContext.SaveChanges();
            return Redirect($"account/{Logged_User}");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}

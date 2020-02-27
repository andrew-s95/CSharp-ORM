using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private MyContext DbContext;
        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newuser)
        {
            if(ModelState.IsValid)
            {
                var DbUser = DbContext.Users.FirstOrDefault(u => u.Email == newuser.Email);
                if(DbUser != null)
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("RegisterPage");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newuser.Password = Hasher.HashPassword(newuser, newuser.Password);
                DbContext.Users.Add(newuser);
                DbContext.SaveChanges();
                UserSession = newuser.UserId;
                return Redirect("Dashboard");
            }
            return View("RegisterPage");
        }

        [HttpGet("loginpage")]
        public IActionResult LoginPage()
        {
            return View();
        }

        //issues with login
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                var DbUser = DbContext.Users.FirstOrDefault(u => u.Email == user.Email);
                if(DbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalida");
                    return View("LoginPage");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, DbUser.Password, user.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("LoginPage");
                }
                UserSession = DbUser.UserId;
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("LoginPage");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("LoginPage");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(UserSession == null)
                return Redirect("LoginPage");
            
            var AllWeddings = DbContext.Weddings
                .Include(w => w.Associations)
                .OrderByDescending(w => w.Date)
                .ToList();
            
            ViewBag.user = UserSession;
            return View(AllWeddings);
        }

        [HttpGet("{weddingId}")]
        public IActionResult WeddingInfoPage(int weddingId)
        {
            var SelectWedding = DbContext.Weddings
            .Include(w => w.Associations)
            .ThenInclude(r => r.Guest)
            .FirstOrDefault(w => w.WeddingId == weddingId);
            return View(SelectWedding);
        }

        [HttpGet("addweddingpage")]
        public IActionResult AddWeddingPage()
        {
            return View();
        }

        [HttpPost("addwedding")]
        public IActionResult AddWedding(Wedding newwedding)
        {
            if (UserSession == null)
                return RedirectToAction("LoginPage");
            if (ModelState.IsValid)
            {   
                // Create new wedding with UserId set to current session UserId
                newwedding.UserId = (int)UserSession;
                DbContext.Weddings.Add(newwedding);
                DbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("AddWeddingPage");
        }

        [HttpGet("delete")]
        public IActionResult Delete(int weddingId)
        {
            if (UserSession == null)
                return RedirectToAction("LoginPage");

            Wedding DeleteThis = DbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            
            if (DeleteThis == null)
                return RedirectToAction("Dashboard");
            // Redirect to dashboard if user trying to delete isn't the wedding creator
            if (DeleteThis.UserId != UserSession)
                return RedirectToAction("Dashboard");
            
            DbContext.Weddings.Remove(DeleteThis);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            if (UserSession == null)
                return RedirectToAction("LoginPage");

            //Create a new response with the given weddingId and current userId
            Association newAss = new Association()
            {
                WeddingId = weddingId,
                UserId = (int)UserSession
            };
            DbContext.Associations.Add(newAss);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("unrsvp/{weddingId}")]
        public IActionResult UnRSVP(int weddingId)
        {
            if (UserSession == null)
                return RedirectToAction("LoginPage");
            
            // Query to grab the appropriate response to remove
            Association DeleteThis = DbContext.Associations.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == UserSession);
            
            // Redirect to dashboard if no match for response in db
            if (DeleteThis == null)
                return RedirectToAction("Dashboard", "Wedding");

            DbContext.Associations.Remove(DeleteThis);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
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

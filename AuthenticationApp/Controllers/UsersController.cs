using AuthenticationApp.Data;
using AuthenticationApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        private MyIdentityDbContext db;
        private UserManager<User> userManager;
        public UsersController()
        {
            db = new MyIdentityDbContext();
            UserStore<User> userStore = new UserStore<User>(db);
            userManager = new UserManager<User>(userStore);
        }
        public ActionResult List()
        {
            ViewBag.Roles = db.Roles.ToList();
            return View(db.Users.ToList());
        }

     

        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string UserName, string PasswordHash, string PhoneNumber , string Email, string IdentityNumber)
        {
            User user = new User()
            {
                UserName = UserName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                IdentityNumber = IdentityNumber,
            };
            var result = await userManager.CreateAsync(user, PasswordHash);
            if (result.Succeeded)
            {
                ViewBag.Success = "Đăng kí thành công";
                return View("Register");
            }
            else
            {
                ViewBag.Error = "Đăng kí thất bại";
                return View("Register");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string PasswordHash)
        {
           
           
           var account = await userManager.FindAsync(UserName, PasswordHash);
            if (account != null)
            {
            SignInManager<User, string> signInManager = new SignInManager<User, string>(userManager, Request.GetOwinContext().Authentication);
            await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
            return Redirect("/Users/List");
            }
            else
            {
                ViewBag.Message = "Đăng nhập thất bại";
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult AddRole()
        {
            return Redirect("/Home");
        }

    }
}
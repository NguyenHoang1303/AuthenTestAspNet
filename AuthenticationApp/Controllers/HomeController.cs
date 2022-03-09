using AuthenticationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Admin application description page.";
            return View();
        }

        [Authorize(Roles = "EMPLOYEE")]
        public ActionResult Employee()
        {
            ViewBag.Message = "Employee page.";
            return View();
        }

        [Authorize(Roles = "USER")]
        public ActionResult Users()
        {
            ViewBag.Message = "User page.";

            return View();
        }
    }
}
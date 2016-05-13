using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Mooshak2.Controllers;
using Mooshak2.DAL;
using Mooshak2.Models;

namespace Mooshak2.Controllers
{
    public class HomeController : Controller
    {
        private  readonly UserService _userService = new UserService();
        [Authorize]
        public ActionResult Index()
        {
          
            //TODO Implement exeption in case missing role
            var role = _userService.GetUserRoles(User.Identity.GetUserId())[0];
            //Temp fix
            if (role == "Admin") 
            {
                return View("Admin");
            }
            return RedirectToAction("Index", role);
        }


        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}
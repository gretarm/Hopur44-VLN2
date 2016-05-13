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
        [Authorize]
        public ActionResult Index()
        {
            //TODO Implement exeption in case missing role
            UserService redirect = new UserService();
            IList<string> role = redirect.GetUserRoles(User.Identity.GetUserId());

            return RedirectToActionPermanent("Index", role[0]);
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


    }
}
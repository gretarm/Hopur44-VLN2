using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mooshak.Models;

namespace Mooshak.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //TODO Implement exeption in case missing role
            /*UserService redirect = new UserService();
            IList<string> role = redirect.GetUserRoles(User.Identity.GetUserId());

            return RedirectToActionPermanent("Index", role[0]);*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
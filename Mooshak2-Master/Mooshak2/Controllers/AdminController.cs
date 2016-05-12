using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using Mooshak2;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserService _userService = new UserService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            
           return View( _userService.GetAllUserAndRole() );
        }

        public ActionResult Courses()
        {
            IEnumerable<Course> courses = (from c in DatabaseConnection.Db.Courses
                                           orderby c.Title ascending
                                           select c).ToList();
            return View(courses);
        }
    }
}
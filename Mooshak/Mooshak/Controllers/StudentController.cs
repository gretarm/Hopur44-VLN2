using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Mooshak.Models.Entities;
using Mooshak.Controllers;
using Mooshak.DAL;
using Mooshak.Models;
using ApplicationDbContext = Mooshak.DAL.ApplicationDbContext;

namespace Mooshak.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();


        public ActionResult Index()
        {
            IEnumerable<Course> cources = (from item in _db.Courses
                                            orderby item.Title ascending
                                            select item).ToList();

            return View(cources);
        }

        public ActionResult Course(int? title)
        {
            if (title == null)
            {
                return Index();
            }

            Course course = _db.Courses.Find(title);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }
    }
}
 
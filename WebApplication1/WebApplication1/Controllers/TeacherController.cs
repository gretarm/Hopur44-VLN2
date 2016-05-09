using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {

		private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Teacher
        public ActionResult Index()
        {
			IEnumerable<Course> courseList = (from c in db.Courses
											  orderby c.Title ascending
											  select c).ToList();
            return View(courseList);
        }
    }
}
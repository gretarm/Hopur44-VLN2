using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {

		private MooshakContext db = new MooshakContext();
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
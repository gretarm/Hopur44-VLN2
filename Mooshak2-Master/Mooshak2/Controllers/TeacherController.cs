using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {

		
        // GET: Teacher
        public ActionResult Index()
        {
			IEnumerable<Course> courseList = (from c in DatabaseConnection.Db.Courses
											  orderby c.Title ascending
											  select c).ToList();
            return View(courseList);
        }

		[Authorize]
		public ActionResult Course(int? title)
		{
			if (title == null)
			{
				return Index();
			}

			Course course = DatabaseConnection.Db.Courses.Find(title);

			if (course == null)
			{
				return HttpNotFound();
			}

			return View(course);
		}
	}
}
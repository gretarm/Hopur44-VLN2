using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Microsoft.AspNet.Identity;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserServicePro userService;
        CoursesService coursesService;

        public TeacherController() : base()
        {
            userService = new UserServicePro(db);
            coursesService = new CoursesService(db);
        }


        // GET: Teacher
        public ActionResult Index()
        {
            TeacherViewModel model = new TeacherViewModel();
            var userId = User.Identity.GetUserId();
            var user = userService.FindUserByID(userId);

            model.Courses = coursesService.GetCoursesForTeacher(user);
            return View(model);
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
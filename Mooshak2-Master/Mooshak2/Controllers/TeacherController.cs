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
        private readonly UserService _userService = new UserService();
        private readonly CoursesService _coursesService = new CoursesService();

        // GET: Teacher
        public ActionResult Index()
        {
            TeacherViewModel model = new TeacherViewModel();
            var userId = User.Identity.GetUserId();
            var user = _userService.GetUserById(userId);

            model.Courses = _coursesService.GetCoursesForTeacher(user);
            return View(model);
        }

		[Authorize]
		public ActionResult Course(int? title)
		{
			if (title == null)
			{
				return Index();
			}

		    Course course = _coursesService.GetCourseByName(title.ToString());

			if (course == null)
			{
				return HttpNotFound();
			}

			return View(course);
		}
	}
}
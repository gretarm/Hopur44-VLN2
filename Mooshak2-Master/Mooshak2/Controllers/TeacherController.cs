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
using Mooshak2.Exceptions;
using System.IO;

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
            
            if(model.Courses.Count == 0)
            {
                throw new NoAssignedCoursesException();
            }

			return View(model);
        }

		[Authorize]
		public ActionResult Course(int? title)
		{
			if (title == null)
			{
				return Index();
			}

		    var course = _coursesService.GetCourseByName(title.ToString());

			if (course == null)
			{
				throw new NoAssignedCoursesException();
			}

			return View(course);
		}

        public ActionResult Create_Assignment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create_Assignment(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Create_Assignment");
        }
    }
}
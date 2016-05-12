using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Mooshak2.Controllers;
using Microsoft.AspNet.Identity;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserServicePro userService;
        CoursesService coursesService;

        public StudentController() : base()
        {
            userService = new UserServicePro(db);
            coursesService = new CoursesService(db);
        }

        // GET: Student
        public ActionResult Index()
        {
            StudentViewModel model = new StudentViewModel();
            var userId = User.Identity.GetUserId();
            var user = userService.FindUserByID(userId);

            model.Courses = coursesService.GetCoursesForStudent(user);
            return View(model);
        }
    }
}
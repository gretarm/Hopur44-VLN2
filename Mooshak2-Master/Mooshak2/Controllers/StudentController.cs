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

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        CoursesService course_service = new CoursesService();

        // GET: Student
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            //var user = course_service.GetCoursesForUserId(userId);


            IEnumerable<Course> courses = (from c in DatabaseConnection.Db.Courses
                                           orderby c.Title ascending
                                           select c).ToList();
            return View(courses);
        }
    }
}
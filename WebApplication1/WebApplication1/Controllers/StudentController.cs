using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Controllers;
using WebApplication1.Services;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            /*
            string userId = User.Identity.GetUserId();
            IEnumerable<Enrollment> cources = (from item in db.Enrollments
                                           where item.UserID = userId
                                               select item).ToList();
           */
            IEnumerable<Course> courses = (from c in db.Courses
                                           orderby c.Title ascending
                                           select c).ToList();

            return View(courses);
        }
        [Authorize]
        public ActionResult Courses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course cor = (from item in db.Courses
                          where item.CourseID == id.Value
                          select item).SingleOrDefault();

            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }
    }
}
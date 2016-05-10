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
        
        // GET: Student
        public ActionResult Index()
        {
            /*
            string userId = User.Identity.GetUserId();
            IEnumerable<Enrollment> cources = (from item in db.Enrollments
                                           where item.UserID = userId
                                               select item).ToList();
           */
            IEnumerable<Course> courses = (from c in DatabaseConnection.Db.Courses
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

            Course cor = (from item in DatabaseConnection.Db.Courses
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
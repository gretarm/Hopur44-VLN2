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

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Course> cources = (from item in db.Courses
                                           orderby item.Title ascending
                                           select item).ToList();

            return View(cources);
        }
    }
}
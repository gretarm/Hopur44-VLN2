using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
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
        [Authorize]
        public ActionResult Course(int? title)
        {
            if (title == null)
            {
                return Index();
            }

            Course course = db.Courses.Find(title);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }
    }
}
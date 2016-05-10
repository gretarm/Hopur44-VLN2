using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {

		private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Teacher
        public ActionResult Index()
        {
			IEnumerable<Course> courseList = (from c in _db.Courses
											  orderby c.Title ascending
											  select c).ToList();
            return View(courseList);
        }
    }
}
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult ID(int? id)
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
        public ActionResult Assignments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Assignment asi = (from assignment_item in DatabaseConnection.Db.Assignments
                          where assignment_item.CourseID == id.Value
                          select assignment_item).SingleOrDefault();

            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }
    }
}
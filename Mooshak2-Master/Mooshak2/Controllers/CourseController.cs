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

            var asi = (from assignment in DatabaseConnection.Db.Assignments
                       orderby assignment.Title ascending
                       select assignment).ToList();

            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        public ActionResult Grade(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var grad = (from assignmentmile in DatabaseConnection.Db.Milestones
                        join grade in DatabaseConnection.Db.Submissions
                        on assignmentmile.ID equals grade.AssignmentMilestoneID
                        join assignment in DatabaseConnection.Db.Assignments
                        on assignmentmile.AssignmentID equals assignment.ID
                        join assign_course in DatabaseConnection.Db.Courses
                        on assignment.CourseID equals assign_course.CourseID
                        select assignment.Title).ToList();

            if (grad == null)
            {
                return HttpNotFound();
            }
            return View(grad);
        }
        public ActionResult Students(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Enrollment cor = (from item in DatabaseConnection.Db.Enrollments
                              where item.CourseID == id.Value
                              select item).SingleOrDefault();

            return View(cor);
        }
        public ActionResult Teachers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var asi = (from assignment in DatabaseConnection.Db.Assignments
                       orderby assignment.Title ascending
                       select assignment).ToList();

            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

    }
}
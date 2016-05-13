using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    public class CourseController : Controller
    {
        private readonly CoursesService _coursesService = new CoursesService();
        private readonly AssignmentService _assignmentService = new AssignmentService();
        public ActionResult Index()
        {
            var model = _coursesService.GetAllCourses();
            return View(model);
        }
        public ActionResult ID(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course cor = _coursesService.GetCourseById(id.Value);

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
            var asi = _assignmentService.GetAssignmentsInCourse(id.Value);

            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        public ActionResult Grade(int? id)
        {
            /*
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
            */
            return View();
        }
        public ActionResult Students(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courses = _coursesService.GetStudentsInCourse(id.Value);

            return View(courses);
        }
        public ActionResult Teachers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var asi = _coursesService.GetTeachersInCourse(id.Value);

            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }
    }
}
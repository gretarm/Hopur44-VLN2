using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Course> courses = (from c in DatabaseConnection.Db.Courses
                                           orderby c.Title ascending
                                           select c).ToList();
            return View(courses);
        }
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
                       join course in DatabaseConnection.Db.Courses
                       on assignment.CourseID equals course.CourseID
                       where course.CourseID == id.Value
                       select new AssignmentViewModel { Title = assignment }).ToList();

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

            var cor = (from enrollments in DatabaseConnection.Db.Enrollments

                       join course in DatabaseConnection.Db.Courses
                       on enrollments.CourseID equals course.CourseID

                       join users in DatabaseConnection.Db.Users
                       on enrollments.UserID.Id equals users.Id

                       where enrollments.CourseID == 3

                       select new StudentViewModel { ID = enrollments, Title = course, Name = users }).ToList();

            return View(cor);
        }
        public ActionResult Teachers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var asi = (from teachment in DatabaseConnection.Db.Teachments
                       join course in DatabaseConnection.Db.Courses
                       on teachment.CourseID equals course.CourseID
                       join users in DatabaseConnection.Db.Users
                       on teachment.UserID.Id equals users.Id

                       where teachment.CourseID == id.Value
                       select new TeacherViewModel { ID = teachment, Title = course, Name = users }).ToList();


            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }


    }
}
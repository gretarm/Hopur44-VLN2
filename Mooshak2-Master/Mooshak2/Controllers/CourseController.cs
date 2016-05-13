using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using Mooshak2.Exceptions;

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
				throw new MissingIdException();
            }

            Course cor = _coursesService.GetCourseById(id.Value);

            if (cor == null)
            {
                throw new NoCourseFoundException();
            }
            return View(cor);
        }
        
        public ActionResult Assignments(int? id)
        {
            if (id == null)
            {
				throw new MissingIdException();
			}
            var asi = _assignmentService.GetAssignmentsInCourse(id.Value);

            if (asi.Count == 0)
            {
				throw new NoAssignmentsInCourseException();
            }
            return View(asi);
        }


        public ActionResult Students(int? id)
        {
            if (id == null)
            {
				throw new MissingIdException();
            }
            var courses = _coursesService.GetStudentsInCourse(id.Value);

			if (!(courses.Count > 0))
			{
				throw new NoStudentInCourseException();
			}

			return View(courses);
        }

        public ActionResult Teachers(int? id)
        {
            if (id == null)
            {
                throw new MissingIdException();
            }

            var asi = _coursesService.GetTeachersInCourse(id.Value);

            if (asi == null)
            {
                throw new NoTeacherInCourseException();
            }
            return View(asi);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new MissingIdException();
            }
            var course = _coursesService.GetCourseById(id.Value);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseManagementController : Controller
    {
        private readonly CoursesService _coursesService = new CoursesService();
        // GET: CourseManagement
        public ActionResult Index()
        {
            var allusers = _coursesService.GetAllCourses();
            return View(allusers);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = _coursesService.AddNewCourse(course);
                return RedirectToAction("Details", new { id = newCourse.CourseID });
            }
            return View("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = _coursesService.GetCourseById(id.Value);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _coursesService.UpdateCourse(course);

                return RedirectToAction("Details", new {id = course.CourseID});
            }
            return View("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = _coursesService.GetCourseById(id.Value);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = _coursesService.GetCourseById(id.Value);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }
        [HttpPost]
        public ActionResult Delete(Course course)
        {
            if (ModelState.IsValid)
            {
                _coursesService.RemoveCourse(course.CourseID);
            }

            return RedirectToAction("Index");
        }
    }
}
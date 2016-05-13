using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly UserService _userService = new UserService();
        // GET: Users
        public ActionResult Index()
        {
            var allUsers = _userService.GetAllUserAndRole();
            return View(allUsers);
        }
        public ActionResult IndexTeachers()
        {
            var teachers = _userService.GetAllUserInRole("Teacher");
            return View("Index", teachers);
        }
        public ActionResult IndexStudents()
        {
            var students = _userService.GetAllUserInRole("Student");
            return View("Index", students);
        }
        public ActionResult IndexAdmins()
        {
            var admins = _userService.GetAllUserInRole("Admin");
            return View("Index", admins);
        }
        public ActionResult Create()
        {
            return View(_userService.GetRoleModelView());
        }
        [HttpPost]
        public ActionResult Create(UserRoleModelView user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                //return RedirectToAction("Details", new { id = newCourse.CourseID });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(UserRoleModelView user)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(string id)
        {
            throw new NotImplementedException(); ;
        }
        [HttpPost]
        public ActionResult Delete(UserRoleModelView user)
        {
            throw new NotImplementedException();
        }


    }
}
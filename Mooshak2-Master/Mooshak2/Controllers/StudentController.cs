using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mooshak2.DAL;
using Mooshak2.Models.ViewModels;
using Mooshak2.Exceptions;

namespace Mooshak2.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private UserService _userService = new UserService();
        private CoursesService _coursesService = new CoursesService();

        // GET: Student
        public ActionResult Index()
        {
            var curruser = _userService.GetUserById(User.Identity.GetUserId());
            var corses = _coursesService.GetCoursesForStudent(curruser);
            return View(corses);
        }
    }
}
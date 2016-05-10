using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak.Controllers
{
    public class AssignmentsController : Controller
    {
        //private AssignmentService _service = new AssignmentService();
        // GET: Assignments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            //var viewModel = _service.GetAssignmentByID(id);
            return View();
        }
    }
}
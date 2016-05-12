using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.DAL;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AssignmentService _assignmentService = new AssignmentService();
		public ActionResult Index()
		{
		    var model = _assignmentService.GetAllAssignments();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _assignmentService.GetAssignmentByID(id);
            return View(model);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentService _service = new AssignmentService();
		ApplicationDbContext db = new ApplicationDbContext();
		// GET: Assignments
		public ActionResult Index()
        {
			IEnumerable<Assignment> listAllAssignments = (from a in db.Assignments
														  orderby a.Title ascending
														  select a).ToList();

            return View(listAllAssignments);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);
            return View(viewModel);
        }
    }
}
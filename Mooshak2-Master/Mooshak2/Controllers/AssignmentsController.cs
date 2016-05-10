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
        private AssignmentService _service = new AssignmentService();
		public ActionResult Index()
        {
			IEnumerable<Assignment> listAllAssignments = (from a in DatabaseConnection.Db.Assignments
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
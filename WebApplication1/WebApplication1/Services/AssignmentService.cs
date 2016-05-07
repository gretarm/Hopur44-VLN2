using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class AssignmentService
    {

      private MooshakContext _db;
      public AssignmentService()
        {
            _db = new MooshakContext();
        }

      public List<AssignmentViewModel> GetAssignmentsInCourse(int courseID)
        {
            return null;
        }
      public AssignmentViewModel GetAssignmentByID(int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                //todo: KASTA VILLU!
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmentID == assignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentViewModel
            {
                Title = assignment.Title,
                Milestones = milestones

            };
            return viewModel;
        }
    }
}
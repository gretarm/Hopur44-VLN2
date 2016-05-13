using System.Collections.Generic;
using System.Linq;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.DAL
{
    public class AssignmentService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IEnumerable<Assignment> GetAllAssignments()
        {
            IEnumerable<Assignment> listAll = (from a in _dbContext.Assignments
                                                            orderby a.Title ascending
                                                            select a).ToList();
            return listAll;
        }
        public List<AssignmentViewModel> GetAssignmentsInCourse(int courseId)
        {
            var asi = (from assignment in _dbContext.Assignments
                       join course in _dbContext.Courses
                       on assignment.CourseID equals course.CourseID
                       where course.CourseID == courseId
                       select new AssignmentViewModel { Title = assignment }).ToList();
            return asi;
        }
        public AssignmentViewModel GetAssignmentByID(int assignmentID)
        {
            var assignment = _dbContext.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                //todo: KASTA VILLU!
            }

            var milestones = _dbContext.Milestones
                .Where(x => x.AssignmentID == assignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentViewModel
            {
                /*
                Title = assignment.Title,
                Milestones = milestones*/

            };
            return viewModel;
        }
    }
}
using System.Collections.Generic;

namespace Mooshak2.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string Title { get; set; }

        public List<AssignmentMilestoneViewModel> Milestones { get; set; }
    }
}
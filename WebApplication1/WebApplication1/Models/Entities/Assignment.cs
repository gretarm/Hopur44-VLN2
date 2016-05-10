using System.Collections.Generic;

namespace Mooshak2.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AssignmentMilestone> AssignmentMilestones { get; set; }

    }
}
using System.Collections.Generic;

namespace Mooshak2.Models.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Teachment> Teachments { get; set; }
    }
}
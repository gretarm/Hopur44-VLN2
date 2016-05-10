using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak.Models.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
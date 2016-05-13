

namespace Mooshak2.Models.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual ApplicationUser UserID { get; set; }
    }
}
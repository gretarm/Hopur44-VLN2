using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public override IDbSet<ApplicationUser> Users
        {
            get
            {
                return (DbSet<ApplicationUser>)base.Users;
            }
            set
            {
                base.Users = value;
            }
        }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentMilestone> Milestones { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Teachment> Teachments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<SubmissionFile> SubmissionFiles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
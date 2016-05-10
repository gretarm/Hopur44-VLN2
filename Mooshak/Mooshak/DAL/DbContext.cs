using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak.Models;
using Mooshak.Models.Entities;


namespace Mooshak.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public override IDbSet<ApplicationUser> Users
        {
            get { return (DbSet<ApplicationUser>) base.Users; }
            set { base.Users = value; }
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentMilestone> Milestones { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
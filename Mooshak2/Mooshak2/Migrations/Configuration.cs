using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models;
using Mooshak2.Services;
using System.Collections.Generic;

namespace Mooshak2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            UserService _userService = new UserService();
            

            context.Roles.AddOrUpdate(
                new IdentityRole("Student"),
                new IdentityRole("Admin"),
                new IdentityRole("Teacher"),
                new IdentityRole("TeacherAid")
                );


            //Todo implement better errorcheck and refractor this code
            //
            if ( ! _userService.UserExists("student1@ru.is"))
            {
                var students = new List<ApplicationUser>()
                {
                    new ApplicationUser{Email="student1@ru.is",PasswordHash="student1#ru.is"},
                    new ApplicationUser{Email="student2@ru.is",PasswordHash="student2#ru.is"},
                    new ApplicationUser{Email="student3@ru.is",PasswordHash="student3#ru.is"},
                    new ApplicationUser{Email="student4@ru.is",PasswordHash="student4#ru.is"},
                    new ApplicationUser{Email="student5@ru.is",PasswordHash="student5#ru.is"},
                    new ApplicationUser{Email="student6@ru.is",PasswordHash="student6#ru.is"}
                };
                students.ForEach(s => _userService.AddUserToRole(s.Id, "Student"));
                students.ForEach(s => context.Users.Add(s));
                context.SaveChanges();
            }
            if (!_userService.UserExists("admin1@ru.is"))
            {
                var admin = new List<ApplicationUser>()
                {
                    new ApplicationUser{Email="admin1@ru.is",PasswordHash="admin1#ru.is"},
                    new ApplicationUser{Email="admin2@ru.is",PasswordHash="admin2#ru.is"},
                    new ApplicationUser{Email="admin3@ru.is",PasswordHash="admin3#ru.is"},
                    new ApplicationUser{Email="admin4@ru.is",PasswordHash="admin4#ru.is"},
                    new ApplicationUser{Email="admin5@ru.is",PasswordHash="admin5#ru.is"},
                };
                admin.ForEach(a => _userService.AddUserToRole(a.Id, "Admin"));
                admin.ForEach(a => context.Users.Add(a));
                context.SaveChanges();
            }
            if (!_userService.UserExists("teacher1@ru.is"))
            {
                var admin = new List<ApplicationUser>()
                {
                    new ApplicationUser{Email="teacher1@ru.is",PasswordHash="teacher1#ru.is"},
                    new ApplicationUser{Email="teacher2@ru.is",PasswordHash="teacher2#ru.is"},
                    new ApplicationUser{Email="teacher3@ru.is",PasswordHash="teacher3#ru.is"},
                    new ApplicationUser{Email="teacher4@ru.is",PasswordHash="teacher4#ru.is"},
                    new ApplicationUser{Email="teacher5@ru.is",PasswordHash="teacher5#ru.is"},
                };
                admin.ForEach(a => _userService.AddUserToRole(a.Id, "Teacher"));
                admin.ForEach(a => context.Users.Add(a));
                context.SaveChanges();
            }
        }
    }
}

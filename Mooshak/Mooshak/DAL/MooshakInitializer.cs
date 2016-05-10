using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak.Models;

namespace Mooshak.DAL
{
    public class MooshakInitializer
    {
        public void InitRoles()
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            rm.Create(new IdentityRole("Admin"));
            rm.Create(new IdentityRole("Teacher"));
            rm.Create(new IdentityRole("TeacherAid"));
            rm.Create(new IdentityRole("Student"));
        }
    }
}
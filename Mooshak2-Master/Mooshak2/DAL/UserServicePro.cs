using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.DAL
{
    public class UserServicePro
    {
        private ApplicationDbContext _db;
        public UserServicePro(ApplicationDbContext context)
        {
            _db = context;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            try
            {
                var users = _db.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
        public ApplicationUser FindUserByID(string userid)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = (from u in _db.Users where u.Id == userid select u).SingleOrDefault();

            return user;
        }
    }
}
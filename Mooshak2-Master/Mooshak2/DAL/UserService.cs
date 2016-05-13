using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Mooshak2.Models;
using Mooshak2.Models.ViewModels;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models.Entities;


namespace Mooshak2.DAL
{   
    /// <summary>
    /// User service klasinn er að miklu leyti byggður á klasa sem patrekur smíðaði og gaf okkur aðgang að í VEFF
    /// Við tókum okkur það leyfi að nota hann og bæta við og breyta eftir þörfum
    /// </summary>
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        private CoursesService _coursesService = new CoursesService();

        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }
        
        public bool UserIsInRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var result = um.IsInRole(userId, roleName);
            return result;
        }

        public ApplicationUser GetUserByName(string name)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return um.FindByName(name);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            try
            {
                var users = _dbContext.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public IEnumerable<UserRoleModelView> GetAllUserInRole(string role)
        {
            var allUsers = GetAllUserAndRole();
            var userInRole = (from item in allUsers where item.Role == role orderby item.Email select item);

            return userInRole;
        }

        public IList<string> GetUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var result = um.GetRoles(userId);
            return result;
        }

        public IEnumerable<UserRoleModelView> GetAllUserAndRole()
        {
            var allUsers = _dbContext.Users.ToList();
            IEnumerable<UserRoleModelView> userRoles = allUsers.Select(
                    user => new UserRoleModelView {Email = user.Email, Role = GetUserRoles(user.Id)[0], UserID = user.Id}).OrderByDescending(x => x.Role);
            return userRoles;
        }

        public UserRoleModelView GetRoleModelViewByID(string userId)
        {

            var user = new UserRoleModelView
            {
                Email = GetUserById(userId).Email,
                Role = GetUserRoles(userId)[0],
                UserID = userId,
                Password = null,
                AllRoles = GetAllRoles()
            };
            return user;
        }

        public UserRoleModelView GetRoleModelView()
        {

            var user = new UserRoleModelView
            {
                Email = null,
                Role = null,
                UserID = null,
                Password = null,
                AllRoles = GetAllRoles()
            };
            return user;
        }

        public ApplicationUser GetUserById(string userid)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = (from u in _dbContext.Users where u.Id == userid select u).SingleOrDefault();

            return user;
        }

        public StudentViewModel GetStudentViewModel(string userId)
        {
            var stud = GetUserById(userId);
            var corses = _coursesService.GetCoursesForStudent(stud);
            var model = new StudentViewModel {Courses = corses, Name = stud};
            return model;
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllRoles()
        {

            IList<IdentityRole> roles = _dbContext.Roles.ToList();
            var allroles = from r in roles
                            select new System.Web.Mvc.SelectListItem
                            {
                                Text = r.Name,
                                Value = r.Id
                            };
            return allroles;
        }



        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void AddUser(UserRoleModelView user)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            
            var newUser = new ApplicationUser {Email = user.Email,  UserName = user.Email};
            um.Create(newUser, user.Password);
            var rid = (from r in _dbContext.Roles where r.Id == user.Role select r.Name).FirstOrDefault();
            um.AddToRole(GetUserByName(user.Email).Id, rid);


        }

        public void RemoveUser(string userId)
        {
            var usr = (from u in _dbContext.Users
                where u.Id == userId
                select u).FirstOrDefault();
            _dbContext.Users.Remove(usr);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UserRoleModelView user)
        {
            var oldUser = GetUserById(user.UserID);

            oldUser.Email = user.Email;
            oldUser.UserName = GetUserById(user.UserID).UserName;

            var role = (from r in _dbContext.Roles where r.Id == user.Role select r.Name).FirstOrDefault();

            if ( ! UserIsInRole(user.UserID, role))
            {
                ClearUserRoles(user.UserID);
                AddUserToRole(user.UserID, role);
            }
            _dbContext.SaveChanges();
        }

        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                var r = rm.FindById(role.RoleId);
                um.RemoveFromRole(userId, r.Name);
            }
        }
    }
}

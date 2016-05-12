using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Controllers;
using Mooshak2.Models;
using Mooshak2.Models.Entities;

namespace Mooshak2.DAL
{
    public class CoursesService
    {
        private ApplicationDbContext _db;
        public CoursesService(ApplicationDbContext context)
        {
            _db = context;
        }

        public List<Course> GetCoursesForTeacher(ApplicationUser user)
        {
            var cor = (from e in _db.Courses
                       join em in _db.Teachments on e.CourseID equals em.CourseID
                       where em.UserID.Id == user.Id
                       select e).ToList();
            return cor;
        }

        public List<Course> GetCoursesForStudent(ApplicationUser user)
        {
            var cor = (from e in _db.Courses
                       join em in _db.Enrollments on e.CourseID equals em.CourseID
                       where em.UserID.Id == user.Id
                       select e).ToList();
            return cor;
        }
    }
}
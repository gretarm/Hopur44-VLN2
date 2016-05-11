using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Controllers;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using WebApplication1.Models;

namespace Mooshak2.DAL
{
    public class CoursesService
    {
        public IEnumerable<Course> GetCoursesForUserId(ApplicationUser user)
        {
            var cor = (from enrollment  in DatabaseConnection.Db.Enrollments
                          join courses in DatabaseConnection.Db.Courses 
                          on enrollment.UserID equals user
                          select courses);
            return cor;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entities;

namespace Mooshak2.Models.ViewModels
{
    public class StudentViewModel
    {
        public Enrollment ID { get; set; }
        public Course Title { get; set; }
        public ApplicationUser Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
using Mooshak2.Models.Entities;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entities;

namespace Mooshak2.Models.ViewModels
{
    public class TeachersViewModel
    {
        public Teachment ID { get; set; }
        public Course Title { get; set; }
        public ApplicationUser Name { get; set; }
        public List<Course> Courses { get; set; }

    }
}
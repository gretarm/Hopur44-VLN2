﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models;

namespace Mooshak2.Models.Entities
{
    public class Submission
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AssignmentMilestoneID { get; set; }

        public virtual ApplicationUser UserID { get; set; }
        public virtual ICollection<SubmissionFile> SubmissionFiles { get; set; }

    }
}
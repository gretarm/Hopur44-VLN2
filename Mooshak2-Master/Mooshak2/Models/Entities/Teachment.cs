using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Teachment
    {
        public int TeachmentID { get; set; }
        public int CourseID { get; set; }


        public virtual Course Course { get; set; }
        public virtual ApplicationUser UserID { get; set; }
    }
}
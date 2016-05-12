using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class File
    {
        public int FileID { get; set; }
        public string Title { get; set; }
        public string PathToFile { get; set; }

        public virtual ICollection<SubmissionFile> SubmissionFiles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.DAL
{
    public class SubmissionService
    {
        public void Save(string path, string name, HttpPostedFileWrapper file)
        {
            String ext = System.IO.Path.GetExtension(file.FileName);
            file.SaveAs(path + name + ext);
        }

        public void Delete(string path)
        {
            System.IO.File.Delete(path);
        }
    }
}
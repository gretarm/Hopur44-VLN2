using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.WebPages.Html;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mooshak2.Models.ViewModels
{
    public class UserRoleModelView
    {
        public ApplicationUser User { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }

}
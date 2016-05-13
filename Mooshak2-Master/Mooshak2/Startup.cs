using System.Security.Principal;
using System.Web.Security;
using Microsoft.Owin;
using Mooshak2.DAL;
using Owin;
using Mooshak2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(Mooshak2.Startup))]
namespace Mooshak2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}

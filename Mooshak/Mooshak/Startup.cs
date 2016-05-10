using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Mooshak.Models;
using Owin;
using ApplicationDbContext = Mooshak.DAL.ApplicationDbContext;

[assembly: OwinStartupAttribute(typeof(Mooshak.Startup))]
namespace Mooshak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

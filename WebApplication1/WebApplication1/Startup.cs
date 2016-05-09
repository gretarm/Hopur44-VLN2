using Microsoft.Owin;
using Owin;
using WebApplication1.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            IdentityManager roles = new IdentityManager();
            roles.CreateRole("Admin");
            roles.CreateRole("Teacher");
            roles.CreateRole("TeacherAid");
            roles.CreateRole("Student");

        }
    }
}

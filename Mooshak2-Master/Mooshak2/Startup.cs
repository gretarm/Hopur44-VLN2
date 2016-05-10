using Microsoft.Owin;
using Owin;
using Mooshak2.Models;

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

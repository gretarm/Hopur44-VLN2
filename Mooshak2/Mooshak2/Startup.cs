using Microsoft.Owin;
using Mooshak2;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
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

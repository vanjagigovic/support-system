using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SUPORT_SYSTEM.Startup))]
namespace SUPORT_SYSTEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

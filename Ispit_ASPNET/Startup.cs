using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ispit_ASPNET.Startup))]
namespace Ispit_ASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

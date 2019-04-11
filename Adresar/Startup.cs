using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adresar.Startup))]
namespace Adresar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

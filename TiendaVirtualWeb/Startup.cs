using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaVirtualWeb.Startup))]
namespace TiendaVirtualWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

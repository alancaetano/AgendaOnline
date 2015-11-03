using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgendaOnlineWeb.Startup))]
namespace AgendaOnlineWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

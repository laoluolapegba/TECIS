using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TECIS.Web.Startup))]
namespace TECIS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamJStats.Web.Startup))]
namespace TeamJStats.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using System.Web.Mvc;
using System.Web.Routing;
using TeamJStats.Web.Common.Bootstrapper;

namespace TeamJStats.Web.BootstrapTasks
{
    public class ConfigureRoutes : IBootstrapTask
    {
        #region Public Properties

        public int Priority
        {
            get { return 5; }
        }

        #endregion

        #region Public Methods and Operators

        public void Execute()
        {
            Register(RouteTable.Routes);
        }

        public static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }

        #endregion
    }
}
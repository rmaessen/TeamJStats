using System;
using System.Web;
using System.Web.Routing;
using StructureMap.Web.Pipeline;
using TeamJStats.Web.Common.Bootstrapper;


namespace TeamJStats.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }

        protected void Application_Start()
        {
//            IoC.Initialize(webAssembly: typeof(MvcApplication).Assembly);
//            var resolver = new Autofac.Integration.Mvc.AutofacDependencyResolver(IoC.GetLifetimeScope());
//            DependencyResolver.SetResolver(resolver);
//            AreaRegistration.RegisterAllAreas();
//            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
             RouteConfig.RegisterRoutes(RouteTable.Routes);
//            BundleConfig.RegisterBundles(BundleTable.Bundles);
//            Bootstrapper.ConfigureApplication();
        }
    }
}
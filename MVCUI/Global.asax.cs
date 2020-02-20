namespace MVCUI
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using TrackerLibrary;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the database connections
            GlobalConfig.InitializeConnections(DatabaseType.Sql);
        }
    }
}

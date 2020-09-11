using System.Web.Mvc;
using System.Web.Routing;

namespace MenuMaker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "menu", action = "edit", id = 7 }
                //defaults: new { controller = "menu", action = "GenerateBuyList", id = 7 }
           );
        }
    }
}

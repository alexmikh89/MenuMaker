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
                //defaults: new { controller = "RecipeViewModels", action = "Create", id = UrlParameter.Optional }
                defaults: new { controller = "Menu", action = "details", id = 6 }
            );
        }
    }
}

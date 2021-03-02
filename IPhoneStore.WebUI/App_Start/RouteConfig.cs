using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPhoneStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Phone", action = "List", modelCategory = (string)null, page = 1 });

            routes.MapRoute(null, "Page{page}", new { controller = "Phone", action = "List", modelCategory = (string)null });

            routes.MapRoute(null, "{modelCategory}", new { controller = "Phone", action = "List", page = 1 });

            routes.MapRoute(null, "{modelCategory}/Page{page}",
                new { controller = "Phone", action = "List" }, new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");
           
        }
    }
}

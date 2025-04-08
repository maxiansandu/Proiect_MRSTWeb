using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
     name: "Default",
     url: "{controller}/{action}/{id}",
     defaults: new { controller = "LogPage", action = "UserLogPage", id = UrlParameter.Optional },
     namespaces: new[] { "eUseControl.Web.Controllers" } // Modifică cu namespace-ul corect
 );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAppOfHotal
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
            );
            routes.MapRoute(
               name: "Bookings",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Bookings", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Customers",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Customers", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Hostals",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Hostals", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}

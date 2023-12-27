using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineEDUschoolManaementSystemMVC
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
                name: "CustomGetCourseRoute",
                url: "id={ID}",
                defaults: new { controller = "Course", action = "GetCourse" }
            );

            routes.MapRoute(
                name: "CustomPriceIncreasedRoute",
                url: "sort-by=increased",
                defaults: new { controller = "Course", action = "PriceIncreased" }
            );

            routes.MapRoute(
                name: "CustomPriceDecreasedRoute",
                url: "sort-by=decreased",
                defaults: new { controller = "Course", action = "PriceDecreased" }
            );
        }
    }
}

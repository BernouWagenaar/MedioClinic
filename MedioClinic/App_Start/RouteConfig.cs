using Kentico.Web.Mvc;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

using MedioClinic.Config;
using MedioClinic.Utils;
using System.Web.Mvc.Routing.Constraints;

namespace MedioClinic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            CultureInfo defaultCulture = CultureInfo.GetCultureInfo("en-US");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Uses lowercase URLs for consistency and SEO-optimization
            routes.LowercaseUrls = true;

            // Maps routes to Kentico HTTP handlers and features enabled in ApplicationConfig.cs
            // Always map the Kentico routes before adding other routes. Issues may occur if Kentico URLs are matched by a general route, for example images might not be displayed on pages
            routes.Kentico().MapRoutes();

            // Maps a default route with a culture URL prefix
            Route route = routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new {
                    culture = defaultCulture.Name,
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints: new {
                    // Constrains the culture parameter to cultures allowed by the site.
                    culture = new SiteCultureConstraint(AppConfig.Sitename),
                    // Constrains the optional id parameter to the integer data type
                    id = new OptionalRouteConstraint(new IntRouteConstraint())
                }
            );

            // Assigns the custom handler to the route
            // Sets the culture of the current thread based on the 'culture' route parameter
            route.RouteHandler = new MultiCultureMvcRouteHandler();

            // Maps route to doctor detail
            route = routes.MapRoute(
                name: "DoctorWithAlias",
                url: "{culture}/Doctors/Detail/{nodeGuid}/{nodeAlias}",
                defaults: new {
                    action = "Detail",
                    controller = "Doctors",
                    culture = defaultCulture.Name,
                    nodeGuid = string.Empty,
                    nodeAlias = ""
                },
                constraints: new {
                    culture = new SiteCultureConstraint(AppConfig.Sitename),
                    nodeGuid = new GuidRouteConstraint(),
                    nodeAlias = new OptionalRouteConstraint(new AlphaRouteConstraint())
                }
            );

            // Assigns the custom handler to the route
            // Sets the culture of the current thread based on the 'culture' route parameter
            route.RouteHandler = new MultiCultureMvcRouteHandler();
        }
    }
}

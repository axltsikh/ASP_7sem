using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Service
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.EnableCors();
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Home", action = "SetM" }

            );
        }
    }
}

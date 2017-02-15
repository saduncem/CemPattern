using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apicalisma
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
config.Routes.MapHttpRoute( name: "DefaultApi",routeTemplate: "API/{action}/{id}",defaults: new {Controller = "Product", id = RouteParameter.Optional });
        }
    }
}

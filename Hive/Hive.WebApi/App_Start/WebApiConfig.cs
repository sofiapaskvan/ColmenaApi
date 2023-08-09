using Microsoft.Web.Http.Routing;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Hive.WebApi
{
    internal static class WebApiConfig
    {
        internal static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            //VERSIONING PART
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersion", typeof(ApiVersionRouteConstraint));

            // Rotes of the web API
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
               name: "Api.v1",
               routeTemplate: "api/v1/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "Api.v2",
               routeTemplate: "api/v2/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

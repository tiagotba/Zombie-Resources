using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace WebApiZombieResources
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        //    config.Routes.MapHttpRoute(
        //       name: "Api_Get",
        //       routeTemplate: "api/{controller}/{id}",
        //       defaults: new { id = RouteParameter.Optional, action = "Get" },
        //       constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
        //   );

        //    config.Routes.MapHttpRoute(
        //   name: "Api_Post",
        //   routeTemplate: "{controller}/{id}/{action}",
        //   defaults: new { id = RouteParameter.Optional, action = "Post" },
        //   constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
        //);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //formatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            //config.MessageHandlers.Add(new PreflightRequestsHandler());

        }
    }
}

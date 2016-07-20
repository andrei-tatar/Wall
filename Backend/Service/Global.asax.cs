using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Newtonsoft.Json.Serialization;

namespace Service
{
    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                var resolver = new MefDependencyResolver();
                config.DependencyResolver = resolver;

                //the frontend is on a different endpoint. allow cross domain requests
                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                var filters = resolver.Resolve<IFilter>();
                config.Filters.AddRange(filters);

                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                    );

                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            });
        }
    }
}

using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace Service
{
	public class Application : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(config =>
			{
				//the frontend is on a different endpoint. allow cross domain requests
				var cors = new EnableCorsAttribute("*", "*", "*");
				config.EnableCors(cors);

				config.MapHttpAttributeRoutes();

				config.Routes.MapHttpRoute(
						 name: "DefaultApi",
						 routeTemplate: "api/{controller}/{id}",
						 defaults: new { id = RouteParameter.Optional }
					);

				config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});
		}
	}
}

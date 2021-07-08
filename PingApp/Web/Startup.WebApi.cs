using Owin;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
namespace PingApp.Web
{
    public partial class Startup
    {
        public static HttpConfiguration config = new HttpConfiguration();

        public void ConfigureWebApi(IAppBuilder app)
        {
            config.SuppressDefaultHostAuthentication();

            config.MapHttpAttributeRoutes();

            
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
              name: "Paging Api",
              routeTemplate: "api/{controller}/{page}/{per_page}",
              defaults: new { id = RouteParameter.Optional }
          );

            var formatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        }
    }
}

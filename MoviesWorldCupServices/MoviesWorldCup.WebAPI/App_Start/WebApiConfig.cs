using MoviesWorldCup.WebAPI.DI;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace MoviesWorldCup.WebAPI.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(MoviesWorldCupContainer.Current);
        }
    }
}
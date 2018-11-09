using SimpleInjector;
using System;
using System.Web;
using System.Web.Http;
using MoviesWorldCup.WebAPI.Infrastructure.Mapping;
using MoviesWorldCup.WebAPI.DI;
using MoviesWorldCup.WebAPI.App_Start;

namespace MoviesWorldCup.WebAPI
{
    public class Global : HttpApplication
    {
        public IAutoMapperProfileConfiguration AutoMapperProfileConfiguration { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            MoviesWorldCupContainer.Current.Configure();
            MoviesWorldCupContainer.Current.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            MoviesWorldCupContainer.Current.Verify();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            AutoMapperProfileConfiguration = MoviesWorldCupContainer.Current.GetInstance<IAutoMapperProfileConfiguration>();
            AutoMapperProfileConfiguration.InicializarAutoMapperConfig();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Utilizado para quando algum request for OPTIONS não passar pelo AuthorizeAttribute dos controllers
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //Executar o retorno para o client
                HttpContext.Current.Response.Flush();
            }
        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }
}
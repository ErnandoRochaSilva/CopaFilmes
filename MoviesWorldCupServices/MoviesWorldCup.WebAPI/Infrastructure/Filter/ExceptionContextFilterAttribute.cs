using Castle.Core.Logging;
using MoviesWorldCup.Infrastructure.Helpers;
using MoviesWorldCup.WebAPI.DI;
using MoviesWorldCup.WebAPI.Requests;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MoviesWorldCup.WebAPI.Infrastructure.Filter
{
    public class ExceptionContextFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LogException(actionExecutedContext.Exception, actionExecutedContext);
            actionExecutedContext.Response = GenerateResponse();

            base.OnException(actionExecutedContext);
        }

        private void LogException(Exception e, HttpActionExecutedContext context)
        {
            ILogger logger = MoviesWorldCupContainer.Current.GetInstance<ILogger>();
            string msg = ExceptionHelper.AggregateExceptionMessages(e);

            string methodName = string.Empty;

            try
            {
                var controllerName = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName;
                var actionName = context.ActionContext.ActionDescriptor.ActionName;
                methodName = $"{controllerName}.{actionName}";
            }
            catch (Exception)
            {
                methodName = $"{GetType().FullName}.OnException";
            }

            logger.Error(msg);
        }

        private HttpResponseMessage GenerateResponse()
        {
            DefaultApiResponse response = new DefaultApiResponse("Houve um erro ao processar sua solicitacao.");

            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };
        }
    }
}
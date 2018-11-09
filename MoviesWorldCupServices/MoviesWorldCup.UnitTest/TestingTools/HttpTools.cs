using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviesWorldCup.WebAPI.Infrastructure.Controllers;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MoviesWorldCup.UnitTest.TestingTools
{
    /// <summary>
    /// Contem métodos para gerar controles de HTTP para testes
    /// </summary>
    public static class HttpTools
    {
        public static HttpConfiguration GerarHttpConfiguration()
        {
            return new HttpConfiguration();
        }

        public static HttpControllerContext GerarHttpControllerContext()
        {
            return new HttpControllerContext
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration(),
                ControllerDescriptor = GerarHttpControllerDescriptor()
            };
        }
        public static HttpControllerDescriptor GerarHttpControllerDescriptor()
        {
            return new HttpControllerDescriptor(new HttpConfiguration(), "TestController", typeof(BaseApiController));
        }

        public static HttpActionContext GerarHttpActionContext(string userName = null)
        {
            var controllerContext = GerarHttpControllerContext();
            var actionDescriptor = MockHttpActionDescriptor();

            var actionContext = new HttpActionContext(controllerContext, actionDescriptor);


            if (!string.IsNullOrWhiteSpace(userName))
            {
                var identity = new GenericIdentity(userName);
                var principal = new GenericPrincipal(identity, new string[] { "Test" });
                actionContext.RequestContext.Principal = principal;
            }

            return actionContext;
        }
        public static HttpActionDescriptor MockHttpActionDescriptor()
        {
            var moqDescriptor = new Mock<HttpActionDescriptor>();
            moqDescriptor.SetupGet(x => x.ActionName).Returns("TestAction");
            return moqDescriptor.Object;
        }
        public static HttpActionExecutedContext GerarHttpActionExecutedContext(string userName = null)
        {
            var actionContext = GerarHttpActionContext(userName);

            return new HttpActionExecutedContext
            {
                ActionContext = actionContext,
                Exception = ExceptionTools.GerarContextoException(new Exception("Teste de exception"))
            };
        }

        public static void AssertExecuteAsyncResponse(IHttpActionResult actionResult, HttpStatusCode expectedStatusCode)
        {
            var task = actionResult.ExecuteAsync(new CancellationToken());
            task.Wait();

            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsInstanceOfType(task.Result, typeof(HttpResponseMessage));
            Assert.AreEqual(expectedStatusCode, task.Result.StatusCode);
        }
    }
}

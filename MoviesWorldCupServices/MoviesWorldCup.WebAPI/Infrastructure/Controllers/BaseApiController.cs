using MoviesWorldCup.WebAPI.Infrastructure.Filter;
using MoviesWorldCup.WebAPI.Requests;
using System.Net;
using System.Web.Http;

namespace MoviesWorldCup.WebAPI.Infrastructure.Controllers
{
    [ExceptionContextFilter]
    public abstract class BaseApiController : ApiController
    {
        protected IHttpActionResult HttpMessage(string message, HttpStatusCode statusCode, string info = null)
        {
            return Content(statusCode, new DefaultApiResponse(message, info));
        }
    }
}
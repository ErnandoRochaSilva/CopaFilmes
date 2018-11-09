using System.Web.Http;
using MoviesWorldCup.Domain.ViewModel;
using MoviesWorldCup.Domain.Entity.MoviesAggregate;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using MoviesWorldCup.WebAPI.Infrastructure.Controllers;
using MoviesWorldCup.WebAPI.Requests.Filmes;

namespace MoviesWorldCup.WebAPI.Controllers.v1
{
    [RoutePrefix("api/v1/Movies")]
    public class MoviesController: BaseApiController
    {
        private readonly IMoviesQueries _queries;

        public MoviesController(IMoviesQueries queries)
        {
            _queries = queries;
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar([FromUri]MoviesConsultaRequest request)
        {
            if (request == null)
                request = new MoviesConsultaRequest();

            var filtro = Mapper.Map<MoviesViewModel>(request);

            IEnumerable<MoviesViewModel> movies = _queries.ConsultarFilmes(filtro);

            if (movies == null)
                return HttpMessage("Nenhum filme foi encontrado com estes critérios de busca", HttpStatusCode.NotFound);

            var response = Mapper.Map<IEnumerable<MoviesConsultaResponse>>(movies);

            return Json(response);
        }
    }
}
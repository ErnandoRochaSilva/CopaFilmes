using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviesWorldCup.Domain.Entity.MoviesAggregate;
using MoviesWorldCup.Domain.ViewModel;
using MoviesWorldCup.UnitTest.TestingTools;
using MoviesWorldCup.WebAPI.Controllers.v1;
using MoviesWorldCup.WebAPI.Requests.Filmes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesWorldCup.UnitTest.WebAPI
{
    [TestClass]
    public class MoviesWorldCupControllerTest
    {
        [TestMethod]
        public void MoviesWorldCupControler_Consultar_RegistroEncontrado_RetornarOk()
        {
            var movie = EntityTools.GerarMovie("tinc010102");
            MoviesController controller = GerarControllerTesteComMovies(movie);

            var filtro = MontarFiltroPadrao();
            var response = controller.Consultar(filtro);

            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.OK);
        }

        [TestMethod]
        public void MoviesWorldCupControler_Consultar_FiltroNulo_RetornarBadRequest()
        {
            MoviesController controller = GerarControllerTesteComMovies();

            var response = controller.Consultar(null);
            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void MoviesWorldCupControler_Consultar_FiltroVazio_RetornarBadRequest()
        {
            MoviesController controller = GerarControllerTesteComMovies();

            var response = controller.Consultar(new MoviesConsultaRequest());
            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void MoviesWorldCupControler_Consultar_ParametroInvalido_Id_RetornarBadRequest()
        {
            MoviesController controller = GerarControllerTesteComMovies();

            var response = controller.Consultar(new MoviesConsultaRequest { Id = Convert.ToInt16(TestConstants.IdInvalido) });
            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void MoviesWorldCupControler_Consultar_ParametroInvalido_Titulo_RetornarBadRequest()
        {
            MoviesController controller = GerarControllerTesteComMovies();

            var response = controller.Consultar(new MoviesConsultaRequest { Titulo = TestConstants.TituloInvalido.ToString() });
            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void MoviesWorldCupController_Consultar_NenhumRegistroEncontrado_RetornarStatusCodeNotFound()
        {
            MoviesController controller = GerarControllerTesteComMovies();
            
            var filtro = MontarFiltroPadrao();
            var response = controller.Consultar(filtro);

            HttpTools.AssertExecuteAsyncResponse(response, HttpStatusCode.NotFound);
        }

        public IMoviesQueries RetornarMoviesQueries(IEnumerable<MoviesViewModel> movies)
        {
            var queriesMock = new Mock<IMoviesQueries>();
            queriesMock.Setup(x => x.ConsultarFilmes(It.IsAny<MoviesViewModel>())).Returns(movies);

            return queriesMock.Object;
        }

        public MoviesController GerarControllerTeste(IMoviesQueries repositorio)
        {
            return new MoviesController(repositorio)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        public MoviesController GerarControllerTesteComMovies(MoviesViewModel movies = null)
        {
            var queries = RetornarMoviesQueries(null);

            return GerarControllerTeste(queries);
        }

        public MoviesConsultaRequest MontarFiltroPadrao()
        {
            return new MoviesConsultaRequest
            {
                Id = Convert.ToInt16(TestConstants.Id),
                Titulo = TestConstants.Titulo.ToString(),
                Ano = Convert.ToInt16(TestConstants.Ano),
                Nota = Convert.ToDecimal(TestConstants.Nota)
            };
        }
    }
}

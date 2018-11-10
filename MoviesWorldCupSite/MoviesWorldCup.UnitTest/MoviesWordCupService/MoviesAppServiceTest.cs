using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWorldCup.Application.Services;
using MoviesWorldCup.Domain.Models;
using MoviesWorldCup.UnitTest.TestingTools;
using MoviesWorldCupSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesWorldCup.UnitTest.MoviesWordCupService
{
    [TestClass]
    public class MoviesAppServiceTest
    {
        public MoviesAppService MoviesAppService { get; set; }

        public MoviesAppServiceTest()
        {
            this.MoviesAppService = new MoviesAppService();
        }

        [TestMethod]
        public void MoviesAppService_Nao_Foram_Selecionados_Competidores()
        {
            IEnumerable<MoviesModel> listaFilmesVazia = MoqTools.GerarListaMoviesVazia().ToList();

            Assert.IsTrue(!listaFilmesVazia.Any());
        }

        [TestMethod]
        public void MoviesAppService_Processar_Campeonato_Campeao_VingadoresGuerraInfinita()
        {
            bool testeOk = false;

            //Filtros sugeridos pelo problema
            var filterIds = new string[] { "tt7784604", "tt3778644", "tt5463162", "tt3606756", "tt4881806", "tt5164214", "tt4154756", "tt3501632" };

            IEnumerable<MoviesModel> listaFilmes = MoqTools.GerarListaMovies();

            listaFilmes = listaFilmes.Where(c => filterIds.Contains(c.Id));

            IEnumerable<MoviesModel> campeos = MoviesAppService.GerarCampeonato(listaFilmes);

            foreach (var item in campeos)
            {
                if(item.Id == "tt4154756")
                {
                    testeOk = true;
                }
            }

            Assert.IsTrue(testeOk);
        }
    }
}

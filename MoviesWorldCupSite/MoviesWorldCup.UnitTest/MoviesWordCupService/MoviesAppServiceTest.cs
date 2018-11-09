using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWorldCup.Application.Services;
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
            IEnumerable<MoviesViewModel> listaFilmesVazia = MoqTools.GerarListaMoviesVazia().ToList();

            Assert.IsTrue(!listaFilmesVazia.Any());
        }

        [TestMethod]
        public void MoviesAppService_Nao_Conseguiu_Conexao_Com_WebAPI_Externa()
        {

        }

        [TestMethod]
        public void MoviesAppService_Processar_Campeonato_Campeao_VingadoresGuerraInfinita()
        {

        }


    }
}

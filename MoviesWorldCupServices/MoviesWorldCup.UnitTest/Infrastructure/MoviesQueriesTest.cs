using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWorldCup.UnitTest.Infrastructure
{
    [TestClass]
    public class MoviesQueriesTest
    {
        [TestMethod]
        public void RetornarAffinity_FiltroContrato_RetornarAffinityPopulado()
        {
            //var Affinity = EntityTools.GerarAffinity(1);
            //var dbMock = DataBaseTools.MockDbConnectionFirstOrDefault(Affinity);
            //var queries = new AffinityQueries(dbMock, Logger);

            //var filtro = new AffinityFiltroViewModel
            //{
            //    NumeroContrato = TestConstants.Contrato
            //};

            //var resultado = queries.ConsultarUnidade(filtro);
            //Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void RetornarAffinity_FiltroNulo_RetornarException()
        {
            //var dbMock = DataBaseTools.MockDbConnectionFirstOrDefaultWithException();
            //var queries = new AffinityQueries(dbMock, Logger);

            //queries.ConsultarUnidade(null);
        }
    }
}

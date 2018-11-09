using MoviesWorldCupSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWorldCup.UnitTest.TestingTools
{
    public static class MoqTools
    {
        public static MoviesViewModel GerarMovies()
        {
            return new MoviesViewModel
            {
                Id = "",
                Titulo = "",
                Ano = 0,
                Nota = 0.0m,
                Campeao = false
            };
        }

        public static IEnumerable<MoviesViewModel> GerarListaMoviesVazia()
        {
            IEnumerable<MoviesViewModel> lista = new List<MoviesViewModel>();

            return lista;
        }

        public static IEnumerable<MoviesViewModel> GerarListaMovies()
        {
            IEnumerable<MoviesViewModel> lista = new List<MoviesViewModel>();

            return lista;
        }
    }
}

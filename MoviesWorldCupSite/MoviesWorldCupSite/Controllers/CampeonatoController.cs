using MoviesWorldCup.Application.Services;
using MoviesWorldCup.Domain.Models;
using MoviesWorldCupSite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesWorldCupSite.Controllers
{
    public class CampeonatoController : Controller
    {
        private readonly MoviesAppService moviesAppService = new MoviesAppService();

        /// <summary>
        /// Página dos vencedores da competição
        /// </summary>
        /// <param name="movies"></param>
        /// <returns>Retorna página com detalhes do vencedores da competição</returns>
        [HttpPost]
        public ActionResult ProcessarCampeonato(IEnumerable<MoviesModel> movies)
        {
            if (movies == null)
                movies = new List<MoviesModel>();

            IEnumerable<MoviesModel> campeos = moviesAppService.GerarCampeonato(movies);

            return PartialView("~/Views/Campeonato/Competidores/_CompetidoresCampeos.cshtml", campeos);
        }
    }
}
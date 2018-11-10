using MoviesWorldCup.Application.Services;
using MoviesWorldCup.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoviesWorldCupSite.Controllers
{
    public class CampeonatoController : Controller
    {
        private readonly MoviesAppService moviesAppService = new MoviesAppService();
        IEnumerable<MoviesModel> campeos = new List<MoviesModel>();

        /// <summary>
        /// Página dos vencedores da competição (modal)
        /// </summary>
        /// <param name="moviesIds">Id's dos competidores (filmes) selecionados para competição</param>
        /// <returns>Retorna página com detalhes do vencedores da competição</returns>
        [HttpPost]
        public ActionResult ProcessarCampeonato(string[] moviesIds)
        {
            IEnumerable<MoviesModel> competidores = FiltrarSelecionados(moviesIds);

            campeos = moviesAppService.GerarCampeonato(competidores);

            return Json(campeos, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Filtrar lista com competidores selecionados para campeonato
        /// </summary>
        /// <param name="filtro">Id's dos competidores selecionados</param>
        /// <returns>Retorna lista dos competidores selecionados</returns>
        public IEnumerable<MoviesModel> FiltrarSelecionados(string[] filtro)
        {
            IEnumerable<MoviesModel> listaFilmes = moviesAppService.ConsultarTodos();

            string filtroIds = filtro[0].ToString();

            filtroIds = LimpaFiltros(filtroIds);

            listaFilmes = listaFilmes.Where(c => filtroIds.Contains(c.Id));

            return listaFilmes;
        }

        /// <summary>
        /// Limpar string de filtro para de competidores do campeonato
        /// </summary>
        /// <param name="filtro">retorna string pronta para filtro</param>
        /// <returns></returns>
        public string LimpaFiltros(string filtro)
        {
            var filtroLimpo = filtro.Replace("[", "").Replace("]", "");
            filtroLimpo = filtroLimpo.Replace("{", "").Replace("{", "");
            filtroLimpo = filtroLimpo.Replace(@"\", "");

            return filtroLimpo;
        }
    }
}
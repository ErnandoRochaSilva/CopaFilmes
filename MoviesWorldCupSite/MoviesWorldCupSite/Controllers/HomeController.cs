using AutoMapper;
using MoviesWorldCup.Application.Services;
using MoviesWorldCup.Domain.Models;
using MoviesWorldCupSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoviesWorldCupSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesAppService _moviesApp = new MoviesAppService();

        /// <summary>
        /// Página principal do projeto
        /// </summary>
        /// <returns>Retorna página principal</returns>
        public ActionResult Index()
        {
            try
            {
                var moviesViewModel = Mapper.Map<IEnumerable<MoviesModel>, IEnumerable<MoviesViewModel>>
                        (_moviesApp.ConsultarTodos());

                return View(moviesViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro:" + ex.InnerException.InnerException.Message.ToString(), ex.InnerException);
            }
        }

        /// <summary>
        /// Página com detalhes da aplicação
        /// </summary>
        /// <returns>Retorna página com detalhes do projeto</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Movies World Cup";

            return View();
        }

        /// <summary>
        /// Página de contatos com dados pessoais
        /// </summary>
        /// <returns>Retorna página com contatos</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Dados Pessois:";

            return View();
        }
    }
}
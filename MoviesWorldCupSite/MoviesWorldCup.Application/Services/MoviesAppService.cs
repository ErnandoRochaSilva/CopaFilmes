using MoviesWorldCup.Domain.Models;
using MoviesWorldCup.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesWorldCup.Application.Services
{
    public class MoviesAppService
    {
        private readonly MoviesRepository _repository = new MoviesRepository();

        /// <summary>
        /// Consultar lista de filmes da api externa
        /// </summary>
        /// <returns>Retorna lista de filmes</returns>
        public IEnumerable<MoviesModel> ConsultarTodos()
        {
            try
            {
                return _repository.ConsultarTodos()
                    .OrderBy(s => s.Titulo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro:" + ex.InnerException.InnerException.Message.ToString(), ex.InnerException);
            }

        }

        /// <summary>
        /// Metodo para retornar vencedores do campeonato 1º e 2º lugar
        /// </summary>
        /// <param name="moviesSelect">Lista de filmes selecionados</param>
        /// <returns>Retorna competidores vencedores (1º e 2º) colocados</returns>
        public IEnumerable<MoviesModel> GerarCampeonato(IEnumerable<MoviesModel> moviesSelect)
        {
            List<MoviesModel> champions = new List<MoviesModel>();

            if (!moviesSelect.Any())
            {
                return champions;
            }

            champions.AddRange(ProcessarCampeonato(moviesSelect.ToList()));

            return champions;
        }

        /// <summary>
        /// Metodo para processar cada fase do campeonato e retornar vencedores do campeonato 1º e 2º colocados
        /// </summary>
        /// <param name="competidores">lista de competidores selecionados</param>
        /// <returns>Retorna competidores vencedores (1º e 2º) colocados</returns>
        public static IEnumerable<MoviesModel> ProcessarCampeonato(List<MoviesModel> competidores)
        {
            IList<MoviesModel> champions = new List<MoviesModel>();
            MoviesModel campeaoDaPartida = null;
            bool ultimaPartida = false;

            if (!competidores.Any())
            {
                return champions;
            }

            foreach (var item in competidores.ToList())
            {
                var competidor1 = competidores.First();
                var competidor2 = competidores.Last();

                campeaoDaPartida = IniciarPartida(competidor1, competidor2);

                champions.Add(campeaoDaPartida);

                //Removendo competidores da partida anterior a não ser que for a ultima partida
                if (!ultimaPartida)
                {
                    competidores.Remove(competidor1);
                    competidores.Remove(competidor2);
                }
                else
                {
                    campeaoDaPartida.Campeao = true;
                    break;
                }

                if (!competidores.Any())
                {
                    competidores.AddRange(champions);
                    champions.Clear();

                    if (competidores.Count == 2)
                    {
                        ultimaPartida = true;
                    }
                }
            }

            return competidores;
        }

        /// <summary>
        /// Metódo para iniciar partida validando ganhador de cada partida
        /// </summary>
        /// <param name="competidor1">Competidor numero 1</param>
        /// <param name="competidor2">Competidor numero 2</param>
        /// <returns>Retorna competidor ganhador</returns>
        public static MoviesModel IniciarPartida(MoviesModel competidor1, MoviesModel competidor2)
        {
            MoviesModel campeao = null;

            //Regra 1: Critério por nota
            if (competidor1.Nota > competidor2.Nota)
            {
                campeao = competidor1;
            }
            else if (competidor2.Nota > competidor1.Nota)
            {
                campeao = competidor2;
            }
            //Regra 2: Desempate por ordem de título
            else if (competidor1.Nota == competidor2.Nota)
            {
                campeao = Desempate(competidor1, competidor2);
            }

            return campeao;
        }

        /// <summary>
        /// Metodo de desempate para retornar competidor ganhador, baseado na ordem alfabetica dos nomes
        /// </summary>
        /// <param name="competidor1">Competidor numero 1</param>
        /// <param name="competidor2">Competidor numero 1</param>
        /// <returns>Retorna competidor vencedor</returns>
        public static MoviesModel Desempate(MoviesModel competidor1, MoviesModel competidor2)
        {
            List<MoviesModel> competidores = new List<MoviesModel>
            {
                competidor1,
                competidor2
            };

            return competidores.OrderBy(o => o.Titulo).First();
        }
    }
}

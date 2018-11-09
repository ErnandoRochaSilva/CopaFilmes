using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MoviesWorldCup
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintLog("Lendo arquivo json:");

            //Teste de unidade
            var filterIds = new string[] { "tt7784604", "tt3778644", "tt5463162", "tt3606756", "tt4881806", "tt5164214", "tt4154756", "tt3501632" };
            //filterIds = null;

            IEnumerable<MoviesModel> movies = LoadJson(@"C:\dataMovies.json", null).OrderBy(s => s.Titulo);

            PrintLog("Dados do arquivo json ordenado pelo título:");
            foreach (var item in movies)
            {
                PrintLog(item.Id + " - " + item.Titulo + " - " + item.Ano + " - Nota: " + item.Nota, false);
            }
            PrintLog("");

            if (filterIds == null)
            {
                movies = movies.Take(8).ToList();
            }

            PrintLog("Gerando campeonato dos competidores (filmes) selecionados:");
            IEnumerable<MoviesModel> champions = ProcessarCampeonato(movies.ToList());

            champions = champions.OrderBy(o => o.Titulo).ThenBy(o => o.Nota);

            PrintLog("1º e 2º colocados:");
            foreach (var item in champions)
            {
                if (item.Campeao)
                {
                    PrintLog("Primeiro colocado: " + item.Titulo + " - Nota: " + item.Nota, false);
                }
                else
                {
                    PrintLog("Segundo colocado: " + item.Titulo + " - Nota: " + item.Nota, false);
                }
            }

            PrintLog("");

            Console.ReadKey();
        }

        /// <summary>
        /// Metodo para retornar vencedores do campeonato 1º e 2º lugar
        /// </summary>
        /// <param name="moviesSelect">Lista de filmes selecionados</param>
        /// <returns>Retorna competidores vencedores (1º e 2º) colocados</returns>
        public static IEnumerable<MoviesModel> GerarCampeonato(IEnumerable<MoviesModel> moviesSelect)
        {
            List<MoviesModel> champions = new List<MoviesModel>();

            if (!moviesSelect.Any())
            {
                PrintLog("Não foram selecionados competidores!");
                return champions;
            }

            foreach (var item in moviesSelect)
            {
                PrintLog(item.Id + " - " + item.Titulo + " - " + item.Ano + " - " + item.Nota, false);
            }
            PrintLog("");

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
            int nroPartida = 1;

            if (!competidores.Any())
            {
                PrintLog("Não foram selecionados competidores!");
                return champions;
            }

            foreach (var item in competidores)
            {
                PrintLog(item.Id + " - " + item.Titulo + " - " + item.Ano + " - " + item.Nota, false);
            }
            PrintLog("");

            foreach (var item in competidores.ToList())
            {
                PrintLog("Partida: " + nroPartida++);

                var competidor1 = competidores.First();
                var competidor2 = competidores.Last();

                PrintLog(competidor1.Titulo + " - Nota:" + competidor1.Nota + " === X === " + competidor2.Titulo + " - Nota:" + competidor2.Nota, false);

                campeaoDaPartida = IniciarPartida(competidor1, competidor2);

                PrintLog("Vencedor: " + campeaoDaPartida.Titulo + " - Nota:" + campeaoDaPartida.Nota);

                champions.Add(campeaoDaPartida);

                //Removendo competidores da partida anterior a não ser que for a ultima partida
                if (!ultimaPartida){
                    competidores.Remove(competidor1);
                    competidores.Remove(competidor2);
                } else {
                    campeaoDaPartida.Campeao = true;
                    break;
                }

                if (!competidores.Any())
                {
                    competidores.AddRange(champions);
                    champions.Clear();
                    
                    if(competidores.Count == 2)
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
            else if (competidor2.Nota > competidor1.Nota) {
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

        public static IEnumerable<MoviesModel> LoadJson(string path, string[] filterIds = null)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                IEnumerable<MoviesModel> jsonList = JsonConvert.DeserializeObject<IEnumerable<MoviesModel>>(json);

                if (filterIds != null)
                {
                    var filtro = "";

                    for (int i = 0; i < filterIds.Length; i++)
                    {
                        var item = filterIds[i];

                        if (filtro == "")
                        {
                            filtro = item.ToString();
                        }
                        else
                        {
                            filtro = filtro + "," + item.ToString();
                        }
                    }

                    PrintLog("Filtros:" + filtro);

                    jsonList = jsonList.Where(c => filterIds.Contains(c.Id));
                }

                return jsonList;
            }
        }

        public static void PrintLog(string log, bool pularLinha = true)
        {
            Console.WriteLine(log);
            if(pularLinha)
                Console.WriteLine("");
        }

        public class MoviesModel
        {
            public String Id { get; set; }
            public String Titulo { get; set; }
            public int Ano { get; set; }
            public Decimal Nota { get; set; }
            public bool Campeao { get; set; }
        }
    }

    
}

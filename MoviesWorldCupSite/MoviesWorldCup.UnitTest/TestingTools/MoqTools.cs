using MoviesWorldCup.Domain.Models;
using MoviesWorldCupSite.Models;
using System.Collections.Generic;

namespace MoviesWorldCup.UnitTest.TestingTools
{
    public static class MoqTools
    {
        public static MoviesModel GerarMovies()
        {
            return new MoviesModel
            {
                Id = "",
                Titulo = "",
                Ano = 0,
                Nota = 0.0m,
                Campeao = false
            };
        }

        public static IEnumerable<MoviesModel> GerarListaMoviesVazia()
        {
            IEnumerable<MoviesModel> lista = new List<MoviesModel>();

            return lista;
        }

        public static IEnumerable<MoviesModel> GerarListaMovies()
        {
            var lista = new List<MoviesModel>(){
                new MoviesModel {
                    Id = "tt3606756",
                    Titulo = "Os Incríveis 2",
                    Ano = 2018,
                    Nota = 8.5m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = 6.7m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt5164214",
                    Titulo = "Oito Mulheres e um Segredo",
                    Ano = 2018,
                    Nota = 6.3m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt7784604",
                    Titulo = "Hereditário",
                    Ano = 2018,
                    Nota = 7.8m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt4154756",
                    Titulo = "Vingadores: Guerra Infinita",
                    Ano = 2018,
                    Nota = 8.8m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = 8.1m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt3778644",
                    Titulo = "Han Solo: Uma História Star Wars",
                    Ano = 2018,
                    Nota = 7.2m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt3501632",
                    Titulo = "Thor: Ragnarok",
                    Ano = 2017,
                    Nota = 7.9m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt2854926",
                    Titulo = "Te Peguei!",
                    Ano = 2017,
                    Nota = 7.1m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt0317705",
                    Titulo = "Os Incríveis",
                    Ano = 2004,
                    Nota = 8.0m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt3799232",
                    Titulo = "A Barraca do Beijo",
                    Ano = 2018,
                    Nota = 6.4m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt1365519",
                    Titulo = "Tomb Raider: A Origem",
                    Ano = 2018,
                    Nota = 6.5m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt1825683",
                    Titulo = "Pantera Negra",
                    Ano = 2018,
                    Nota = 7.5m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt5834262",
                    Titulo = "Hotel Artemis",
                    Ano = 2018,
                    Nota = 6.3m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt7690670",
                    Titulo = "Superfly",
                    Ano = 2018,
                    Nota = 5.1m,
                    Campeao = false
                },
                new MoviesModel {
                    Id = "tt6499752",
                    Titulo = "Upgrade",
                    Ano = 2018,
                    Nota = 7.8m,
                    Campeao = false
                },
            };

            return lista;
        }
    }
}

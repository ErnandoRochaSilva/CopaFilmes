using MoviesWorldCup.Domain.Entity.MoviesAggregate;
using MoviesWorldCup.Domain.ViewModel;
using MoviesWorldCup.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MoviesWorldCup.Infrastructure.Queries
{
    public class MoviesQueries : IMoviesQueries
    {
        public static string UriFilmes => ConfigurationManager.AppSettings["URLMicroService"];

        public IEnumerable<MoviesViewModel> ConsultarFilmes(MoviesViewModel filtro)
        {
            IEnumerable<MoviesViewModel> listaFilmes = new List<MoviesViewModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri(UriFilmes);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //GET
                    var response = client.GetAsync("");
                    response.Wait();
                    var result = response.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var movies = result.Content.ReadAsAsync<IList<MoviesViewModel>>();
                        movies.Wait();

                        listaFilmes = movies.Result;
                    }
                }
                return listaFilmes;
            }
            catch (Exception e)
            {
                var ex = new InfrastructureException(e);
                throw ex;
            }
        }
    }
}

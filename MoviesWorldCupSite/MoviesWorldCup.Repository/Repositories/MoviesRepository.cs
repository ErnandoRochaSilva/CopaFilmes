using MoviesWorldCup.Domain.Infrastructure;
using MoviesWorldCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MoviesWorldCup.Repository.Repositories
{
    public class MoviesRepository: IRepositoryBase<MoviesModel>
    {
        public static string UriFilmes => ConfigurationManager.AppSettings["URLMicroService"];

        public IEnumerable<MoviesModel> ConsultarTodos()
        {
            IEnumerable<MoviesModel> listaFilmes = new List<MoviesModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UriFilmes);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //GET
                    var response = client.GetAsync("");
                    response.Wait();
                    var result = response.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var movies = result.Content.ReadAsAsync<IEnumerable<MoviesModel>>();
                        movies.Wait();

                        listaFilmes = movies.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro:" + ex.InnerException.InnerException.Message.ToString(), ex.InnerException);
            }

            return listaFilmes;
        }
    }
}

using System;

namespace MoviesWorldCup.WebAPI.Requests.Filmes
{
    public class MoviesConsultaResponse
    {
        public String Id { get; set; }
        public String Titulo { get; set; }
        public int Ano { get; set; }
        public Decimal Nota { get; set; }
    }
}
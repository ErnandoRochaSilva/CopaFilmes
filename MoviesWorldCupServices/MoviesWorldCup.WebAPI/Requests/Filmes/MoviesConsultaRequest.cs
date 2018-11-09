namespace MoviesWorldCup.WebAPI.Requests.Filmes
{
    public class MoviesConsultaRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }
}
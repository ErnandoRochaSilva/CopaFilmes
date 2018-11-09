using MoviesWorldCup.Domain.ViewModel;

namespace MoviesWorldCup.UnitTest.TestingTools
{
    public static class EntityTools
    {
        public static MoviesViewModel GerarMovie(string id)
        {
            return new MoviesViewModel
            {
                Id = id,
                Titulo = "Incredibles 2",
                Ano = 2018,
                Nota = 9.5m
            };
        }
    }
}

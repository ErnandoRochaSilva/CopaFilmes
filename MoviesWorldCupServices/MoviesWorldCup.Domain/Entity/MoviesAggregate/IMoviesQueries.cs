using MoviesWorldCup.Domain.ViewModel;
using System.Collections.Generic;

namespace MoviesWorldCup.Domain.Entity.MoviesAggregate
{
    public interface IMoviesQueries
    {
        IEnumerable<MoviesViewModel> ConsultarFilmes(MoviesViewModel filtro);
    }
}

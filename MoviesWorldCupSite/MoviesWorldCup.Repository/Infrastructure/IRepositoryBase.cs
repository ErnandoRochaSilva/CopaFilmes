using System.Collections.Generic;

namespace MoviesWorldCup.Domain.Infrastructure
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ConsultarTodos();
    }
}

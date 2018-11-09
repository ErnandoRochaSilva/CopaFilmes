using SimpleInjector;
using SimpleInjector.Lifestyles;
using MoviesWorldCup.Domain.Entity.MoviesAggregate;
using MoviesWorldCup.Infrastructure.Queries;
using MoviesWorldCup.WebAPI.Infrastructure.Mapping;

namespace MoviesWorldCup.WebAPI.DI
{
    public class MoviesWorldCupContainer : Container
    {
        private static MoviesWorldCupContainer _current;
        public static MoviesWorldCupContainer Current
        {
            get
            {
                if (_current == null)
                    _current = new MoviesWorldCupContainer();

                return _current;
            }
        }

        private MoviesWorldCupContainer()
        {
            Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public void Configure()
        {
            //Configurações gerais
            Register<IAutoMapperProfileConfiguration, AutoMapperProfileConfiguration>();

            Register<IMoviesQueries, MoviesQueries>(Lifestyle.Transient);
        }
    }
}
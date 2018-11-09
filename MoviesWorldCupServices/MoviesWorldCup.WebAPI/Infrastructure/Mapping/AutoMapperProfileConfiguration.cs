using AutoMapper;
using MoviesWorldCup.Domain.ViewModel;
using MoviesWorldCup.WebAPI.Requests.Filmes;

namespace MoviesWorldCup.WebAPI.Infrastructure.Mapping
{
    public class AutoMapperProfileConfiguration : IAutoMapperProfileConfiguration
    {
        public void InicializarAutoMapperConfig()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<MoviesConsultaRequest, MoviesViewModel>();
                config.CreateMap<MoviesViewModel, MoviesConsultaRequest>();
            });
        }
    }
}
using AutoMapper;
using MoviesWorldCup.Domain.Models;
using MoviesWorldCupSite.Models;

namespace MoviesWorldCupSite.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MoviesModel, MoviesViewModel>();
        }
    }
}
using AutoMapper;
using MoviesWorldCup.Domain.Models;
using MoviesWorldCupSite.Models;

namespace MoviesWorldCupSite.AutoMapper
{
    public partial class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MoviesViewModel, MoviesModel>();
        }
    }
}
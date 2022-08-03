using AutoMapper;
using GameZone.Application.Developers.Queries.GetDeveloperById;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<Developer, DeveloperDto>();
        }
    }
}

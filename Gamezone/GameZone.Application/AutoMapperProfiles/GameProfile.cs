using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.Developers, opt => opt.MapFrom(y => y.Developers.Select(z => z.Developer)));

            CreateMap<GameDto, Game>();
            CreateMap<SimpleGameDto, Game>();
            CreateMap<Game, SimpleGameDto>();
        }
    }
}

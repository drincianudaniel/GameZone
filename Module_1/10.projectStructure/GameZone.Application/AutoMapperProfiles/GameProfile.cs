using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
        }
    }
}

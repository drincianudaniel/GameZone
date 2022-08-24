using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<SimpleGameDto,Game>();
            CreateMap<Game, SimpleGameDto>();
        }
    }
}

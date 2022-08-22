using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Application.AutoMapperProfiles
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

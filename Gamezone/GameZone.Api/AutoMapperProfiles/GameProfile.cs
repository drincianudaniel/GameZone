using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Application.Dtos;
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
            CreateMap<Game, AutoCompleteGameDto>();
            CreateMap<Game, GamePatchDto>();
            CreateMap<GamePatchDto, Game>();
            CreateMap<GamesWithUserFavoritesDTO, GamesWithFavoritesDto>();
            CreateMap<GamesWithFavoritesDto, GamesWithUserFavoritesDTO>();
        }
    }
}

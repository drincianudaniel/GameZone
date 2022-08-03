using AutoMapper;
using GameZone.Application.Games.Queries.GetGameById;
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

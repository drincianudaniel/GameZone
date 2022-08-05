using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}

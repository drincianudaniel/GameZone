using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}

using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

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

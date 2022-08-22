using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

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

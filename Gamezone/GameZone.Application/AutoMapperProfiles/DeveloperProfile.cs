using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;
using GameZoneModels;

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

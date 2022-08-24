using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<Developer, DeveloperDto>();
        }
    }
}

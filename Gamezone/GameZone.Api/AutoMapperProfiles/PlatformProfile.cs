using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDto>();
        }
    }
}

﻿using AutoMapper;
using GameZone.Application.DTOs;
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

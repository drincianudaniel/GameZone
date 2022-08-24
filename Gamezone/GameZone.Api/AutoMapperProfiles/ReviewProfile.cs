﻿using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    internal class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(c => c.Username, opt => opt.MapFrom(s => s.User.Username))
                .ForMember(c => c.Gamename, opt => opt.MapFrom(s => s.Game.Name));
            CreateMap<ReviewDto, Review>();
        }
    }
}

﻿using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<Reply, ReplyDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(s => s.User.UserName));
        }
    }
}

using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Application.AutoMapperProfiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<Reply, ReplyDto>()
                .ForMember(c => c.Username, opt => opt.MapFrom(s => s.User.Username));
        }
    }
}

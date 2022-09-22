using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
            .ForMember(c => c.UserName, opt => opt.MapFrom(s => s.User.UserName))
            .ForMember(c => c.Gamename, opt => opt.MapFrom(s => s.Game.Name));

            CreateMap<CommentDto, Comment>();
        }
    }
}

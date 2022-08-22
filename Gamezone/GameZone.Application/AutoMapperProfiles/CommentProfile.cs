using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Application.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
            .ForMember(c => c.Username, opt => opt.MapFrom(s => s.User.Username))
            .ForMember(c => c.Gamename, opt => opt.MapFrom(s => s.Game.Name));

            CreateMap<CommentDto, Comment>();
        }
    }
}

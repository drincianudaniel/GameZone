using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}

using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(s => s.User.UserName))
                .ForMember(c => c.Gamename, opt => opt.MapFrom(s => s.Game.Name))
                .ForMember(c => c.UserProfileImage, opt => opt.MapFrom(s => s.User.ProfileImageSrc));

            CreateMap<ReviewDto, Review>();
        }
    }
}

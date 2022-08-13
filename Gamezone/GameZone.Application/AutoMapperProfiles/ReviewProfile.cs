using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;

namespace GameZone.Application.AutoMapperProfiles
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

using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}

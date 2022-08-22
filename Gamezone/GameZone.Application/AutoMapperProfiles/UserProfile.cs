using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;

namespace GameZone.Application.AutoMapperProfiles
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

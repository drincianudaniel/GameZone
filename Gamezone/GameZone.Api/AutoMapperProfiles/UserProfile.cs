using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Application.Dtos;
using GameZone.Domain.Models;

namespace GameZone.Api.AutoMapperProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, ProfileUserDto>();
            CreateMap<ProfileUserDto, User>();

            CreateMap<UserWithRolesApiDto, UserWithRolesDto>();
            CreateMap<UserWithRolesDto, UserWithRolesApiDto>();

            CreateMap<User, UserPatchDto>();
            CreateMap<UserPatchDto, User>();

            CreateMap<User, AutoCompleteUserDto>()
                .ForMember(user => user.Id, opt => opt.MapFrom(s => s.UserName))
                .ForMember(user => user.Name, opt => opt.MapFrom(s => s.UserName));
        }
    }
}

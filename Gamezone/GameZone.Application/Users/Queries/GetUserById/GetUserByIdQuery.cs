using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}

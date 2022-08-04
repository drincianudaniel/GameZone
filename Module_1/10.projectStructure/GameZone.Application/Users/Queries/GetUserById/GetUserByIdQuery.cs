using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}

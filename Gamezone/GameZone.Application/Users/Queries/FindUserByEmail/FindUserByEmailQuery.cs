using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Users.Queries.FindUserByEmail
{
    public class FindUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}

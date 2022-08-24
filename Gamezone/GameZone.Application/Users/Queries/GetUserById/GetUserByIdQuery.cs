using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}

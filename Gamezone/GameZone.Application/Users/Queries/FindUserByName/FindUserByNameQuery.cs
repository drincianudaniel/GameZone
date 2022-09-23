using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.FindUserByName
{
    public class FindUserByNameQuery : IRequest<User>
    {
        public string UserName { get; set; }
    }
}

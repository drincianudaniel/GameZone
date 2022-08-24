using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<IEnumerable<User>>
    {
    }
}

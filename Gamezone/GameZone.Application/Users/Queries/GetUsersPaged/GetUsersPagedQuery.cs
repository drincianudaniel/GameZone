using GameZone.Application.Dtos;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersPaged
{
    public class GetUsersPagedQuery : IRequest<IEnumerable<UserWithRolesDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
    }
}

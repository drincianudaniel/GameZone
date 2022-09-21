using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersPaged
{
    public class GetDevelopersPagedQuery : IRequest<IEnumerable<Developer>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
    }
}

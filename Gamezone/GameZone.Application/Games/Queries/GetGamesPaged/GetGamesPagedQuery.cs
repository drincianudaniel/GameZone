using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesPaged
{
    public class GetGamesPagedQuery : IRequest<IEnumerable<Game>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

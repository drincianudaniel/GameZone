using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesTop
{
    public class GetGamesTopQuery : IRequest<IEnumerable<Game>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.SearchGames
{
    public class SearchGamesQuery : IRequest<IEnumerable<Game>>
    {
        public string searchString { get; set; } = string.Empty;
    }
}

using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.SearchGames
{
    public class SearchGamesQuery : IRequest<IEnumerable<SimpleGameDto>>
    {
        public string searchString { get; set; } = string.Empty;
    }
}

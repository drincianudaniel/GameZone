
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetNumberOfGames
{
    public class GetNumberOfGamesQuery : IRequest<IEnumerable<Game>>
    {
        public int Number { get; set; }
        public string SortOrder { get; set; }
    }
}

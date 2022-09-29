using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Users.Queries.GetFavoriteGames
{
    public class GetFavoriteGamesQuery : IRequest<IEnumerable<Game>>
    {
        public string UserName { get; set; }
    }
}

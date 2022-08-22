using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesPaged
{
    public class GetGamesPagedQuery : IRequest<IEnumerable<GameDto>>
    {
        public int Page { get; set; }
    }
}

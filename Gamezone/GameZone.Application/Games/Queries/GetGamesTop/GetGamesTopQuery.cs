using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesTop
{
    public class GetGamesTopQuery : IRequest<IEnumerable<SimpleGameDto>>
    {
    }
}

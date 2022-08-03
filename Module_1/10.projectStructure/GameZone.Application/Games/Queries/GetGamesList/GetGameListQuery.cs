using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQuery : IRequest<IEnumerable<GameDto>>
    {
    }
}

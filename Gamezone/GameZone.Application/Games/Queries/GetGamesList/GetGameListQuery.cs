using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQuery : IRequest<IEnumerable<Game>>
    {
    }
}

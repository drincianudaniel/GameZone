using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQuery : IRequest<IEnumerable<Platform>>
    {
    }
}

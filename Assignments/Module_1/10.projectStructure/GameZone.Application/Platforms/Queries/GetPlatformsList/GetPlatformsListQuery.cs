using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQuery : IRequest<IEnumerable<PlatformDto>>
    {

    }
}

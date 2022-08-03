
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Platforms.Queries.GetPlatformById
{
    internal class GetPlatformByIdQuery : IRequest<PlatformDto>
    {
        public int Id { get; set; }
    }
}

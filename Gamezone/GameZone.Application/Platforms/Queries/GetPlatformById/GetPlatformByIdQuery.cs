using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQuery : IRequest<Platform>
    {
        public Guid Id { get; set; }
    }
}

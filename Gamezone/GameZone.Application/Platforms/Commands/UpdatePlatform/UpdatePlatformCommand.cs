using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommand : IRequest<Platform>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

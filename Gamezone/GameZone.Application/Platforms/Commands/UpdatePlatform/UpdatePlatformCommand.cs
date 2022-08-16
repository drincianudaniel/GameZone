using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommand : IRequest<PlatformDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

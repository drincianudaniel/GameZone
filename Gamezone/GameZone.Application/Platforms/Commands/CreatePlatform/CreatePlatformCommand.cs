using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<PlatformDto>
    {
        public string Name { get; set; } = string.Empty;
    }
}

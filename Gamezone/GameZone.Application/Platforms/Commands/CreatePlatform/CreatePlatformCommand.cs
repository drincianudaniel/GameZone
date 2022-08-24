using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<Platform>
    {
        public string Name { get; set; } = string.Empty;
    }
}

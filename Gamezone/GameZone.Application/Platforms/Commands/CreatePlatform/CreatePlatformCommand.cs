using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}

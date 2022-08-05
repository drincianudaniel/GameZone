using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}

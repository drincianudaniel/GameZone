using MediatR;

namespace GameZone.Application.Games.Commands.AddPlatform
{
    public class AddPlatformCommand : IRequest<bool>
    {
        public Guid GameId { get; set; }
        public Guid PlatformId { get; set; }
    }
}

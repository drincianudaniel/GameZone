using MediatR;

namespace GameZone.Application.Games.Commands.RemovePlatform
{
    public class RemovePlatformCommand : IRequest<bool>
    {
        public Guid GameId { get; set; }
        public Guid PlatformId { get; set; }
    }
}

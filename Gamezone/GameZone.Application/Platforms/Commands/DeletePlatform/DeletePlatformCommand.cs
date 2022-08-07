using MediatR;

namespace GameZone.Application.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}

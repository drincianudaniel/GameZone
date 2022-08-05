using MediatR;

namespace GameZone.Application.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

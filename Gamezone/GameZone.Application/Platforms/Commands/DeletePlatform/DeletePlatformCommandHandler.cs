using MediatR;

namespace GameZone.Application.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, Guid>
    {
        private readonly IPlatformRepository _platformRepository;
        public DeletePlatformCommandHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        public async Task<Guid> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = await _platformRepository.ReturnByIdAsync(request.Id);
            await _platformRepository.DeleteAsync(platform);
            return platform.Id;
        }
    }
}

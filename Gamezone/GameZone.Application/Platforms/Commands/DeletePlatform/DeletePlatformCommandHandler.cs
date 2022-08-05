using MediatR;

namespace GameZone.Application.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, int>
    {
        private readonly IPlatformRepository _platformRepository;
        public DeletePlatformCommandHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        public Task<int> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = _platformRepository.ReturnById(request.Id);
            _platformRepository.Delete(platform.Id);
            return Task.FromResult(platform.Id);
        }
    }
}

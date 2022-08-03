using GameZoneModels;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, int>
    {
        private readonly IPlatformRepository _platformRepository;
        public CreatePlatformCommandHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        public Task<int> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform(request.Name);
            _platformRepository.Create(platform);

            return Task.FromResult(platform.Id);
        }
    }
}

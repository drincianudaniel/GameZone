using GameZoneModels;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, Guid>
    {
        private readonly IPlatformRepository _platformRepository;
        public CreatePlatformCommandHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        public Task<Guid> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform { Name = request.Name };
            _platformRepository.Create(platform);

            return Task.FromResult(platform.Id);
        }
    }
}

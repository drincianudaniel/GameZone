using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, Platform>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePlatformCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Platform> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform { Name = request.Name };

            await _unitOfWork.PlatformRepository.CreateAsync(platform);
            await _unitOfWork.SaveAsync();

            return platform;
        }
    }
}

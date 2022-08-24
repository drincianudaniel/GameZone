using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, Platform>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePlatformCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Platform> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platformToUpdate = new Platform();
            platformToUpdate.Id = request.Id;
            platformToUpdate.Name = request.Name;

            await _unitOfWork.PlatformRepository.UpdateAsync(platformToUpdate);
            await _unitOfWork.SaveAsync();

            return platformToUpdate;
        }
    }
}

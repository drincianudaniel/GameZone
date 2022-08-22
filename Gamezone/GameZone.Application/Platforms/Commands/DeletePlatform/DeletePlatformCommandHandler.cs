using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePlatformCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = await _unitOfWork.PlatformRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.PlatformRepository.DeleteAsync(platform);
            await _unitOfWork.SaveAsync();

            return platform.Id;
        }
    }
}

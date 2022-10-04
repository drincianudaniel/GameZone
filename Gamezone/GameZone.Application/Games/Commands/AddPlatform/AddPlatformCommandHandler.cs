using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Commands.AddPlatform
{
    public class AddPlatformCommandHandler : IRequestHandler<AddPlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPlatformCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(AddPlatformCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var platform = await _unitOfWork.PlatformRepository.ReturnByIdAsync(request.PlatformId);
            await _unitOfWork.GameRepository.AddPlatformAsync(game, platform);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}

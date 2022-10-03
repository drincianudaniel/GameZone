using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Games.Commands.RemovePlatform
{
    public class RemovePlatformCommandHandler : IRequestHandler<RemovePlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePlatformCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(RemovePlatformCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var platform = await _unitOfWork.PlatformRepository.ReturnByIdAsync(request.PlatformId);
            await _unitOfWork.GameRepository.RemovePlatformAsync(game, platform);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}

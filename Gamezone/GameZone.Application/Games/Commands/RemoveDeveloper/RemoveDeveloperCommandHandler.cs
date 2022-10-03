using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Games.Commands.RemoveDeveloper
{
    public class RemoveDeveloperCommandHandler : IRequestHandler<RemoveDeveloperCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveDeveloperCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(RemoveDeveloperCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var developer = await _unitOfWork.DeveloperRepository.ReturnByIdAsync(request.DeveloperId);
            await _unitOfWork.GameRepository.RemoveDeveloperAsync(game, developer);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}

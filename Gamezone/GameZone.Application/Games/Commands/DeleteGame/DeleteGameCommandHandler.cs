using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.GameRepository.DeleteAsync(game);
            await _unitOfWork.SaveAsync();

            return game.Id;
        }
    }
}

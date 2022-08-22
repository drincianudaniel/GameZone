using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Users.Commands.RemoveFavoriteGame
{
    public class RemoveFavoriteGameCommandHandler : IRequestHandler<RemoveFavoriteGameCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveFavoriteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Guid> Handle(RemoveFavoriteGameCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.ReturnByIdAsync(request.UserId);
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);

            await _unitOfWork.UserRepository.RemoveGameFromFavorites(user, game);
            await _unitOfWork.SaveAsync();

            return game.Id;
        }
    }
}

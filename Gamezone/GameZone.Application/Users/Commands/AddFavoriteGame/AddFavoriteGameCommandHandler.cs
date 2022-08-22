using AutoMapper;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommandHandler : IRequestHandler<AddFavoriteGameCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFavoriteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Guid> Handle(AddFavoriteGameCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.ReturnByIdAsync(request.IdUser);
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.IdGame);

            await _unitOfWork.UserRepository.AddGameToFavorite(user, game);
            await _unitOfWork.SaveAsync();

            return game.Id;
        }
    }
}

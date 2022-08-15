using AutoMapper;
using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommandHandler : IRequestHandler<AddFavoriteGameCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public AddFavoriteGameCommandHandler(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }
        public async Task<Guid> Handle(AddFavoriteGameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReturnByIdAsync(request.IdUser);
            var game = await _gameRepository.ReturnByIdAsync(request.IdGame);
            await _userRepository.AddGameToFavorite(user, game);
            return game.Id;
        }
    }
}

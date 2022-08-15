using MediatR;


namespace GameZone.Application.Users.Commands.RemoveFavoriteGame
{
    public class RemoveFavoriteGameCommandHandler : IRequestHandler<RemoveFavoriteGameCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public RemoveFavoriteGameCommandHandler(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }
        public async Task<Guid> Handle(RemoveFavoriteGameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReturnByIdAsync(request.UserId);
            var game = await _gameRepository.ReturnByIdAsync(request.GameId);
            await _userRepository.RemoveGameFromFavorites(user, game);
            return game.Id;
        }
    }
}

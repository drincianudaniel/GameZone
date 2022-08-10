using MediatR;

namespace GameZone.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Guid>
    {
        private readonly IGameRepository _gameRepository;
        public DeleteGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Guid> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.ReturnByIdAsync(request.Id);
            await _gameRepository.DeleteAsync(game);
            return game.Id;
        }
    }
}

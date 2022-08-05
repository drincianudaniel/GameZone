using MediatR;

namespace GameZone.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, int>
    {
        private readonly IGameRepository _gameRepository;
        public DeleteGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<int> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = _gameRepository.ReturnById(request.Id);
            _gameRepository.Delete(game.Id);
            return Task.FromResult(game.Id);
        }
    }
}

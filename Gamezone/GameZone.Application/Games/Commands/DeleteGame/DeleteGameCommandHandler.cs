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

        public Task<Guid> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = _gameRepository.ReturnById(request.Id);
            _gameRepository.Delete(game.Id);
            return Task.FromResult(game.Id);
        }
    }
}

using GameZoneModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.Name, request.ReleaseDate, request.GameDetails);
            _gameRepository.Create(game);

            return Task.FromResult(game.Id);
        }
    }
}

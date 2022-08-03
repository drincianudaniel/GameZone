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
            var developers = request.Developers.Select(developerDto => new Developer(developerDto.Name, developerDto.Headquarters));
            var genres = request.Genres.Select(genreDto => new Genre(genreDto.Name));
            var platforms = request.Platforms.Select(platformDto => new Platform(platformDto.Name));
            var game = new Game(request.Name, request.ReleaseDate, request.GameDetails, developers.ToList(), genres.ToList(), platforms.ToList());
            _gameRepository.Create(game);

            return Task.FromResult(game.Id);
        }
    }
}

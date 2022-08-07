using GameZoneModels;
using MediatR;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var developers = request.Developers.Select(developerDto => new Developer { Name = developerDto.Name, Headquarters = developerDto.Headquarters });
            var genres = request.Genres.Select(genreDto => new Genre{Name = genreDto.Name});
            var platforms = request.Platforms.Select(platformDto => new Platform { Name = platformDto.Name });
            var game = new Game { Name = request.Name, ReleaseDate = request.ReleaseDate, GameDetails = request.GameDetails, Developers = developers.ToList(), Genres = genres.ToList(), Platforms = platforms.ToList()};
            _gameRepository.Create(game);

            return Task.FromResult(game.Id);
        }
    }
}

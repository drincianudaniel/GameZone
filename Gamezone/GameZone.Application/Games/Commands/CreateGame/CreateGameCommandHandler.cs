using AutoMapper;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPlatformRepository _platformRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository, IDeveloperRepository developerRepository, IGenreRepository genreRepository, IPlatformRepository platformRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository=developerRepository;
            _genreRepository=genreRepository;
            _platformRepository=platformRepository;
        }
        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            
            var game = new Game { Name = request.Name, ReleaseDate = request.ReleaseDate, GameDetails = request.GameDetails};
            await _gameRepository.CreateAsync(game);
            var gameToAdd = await _gameRepository.ReturnByIdAsync(game.Id);

            if (request.DeveloperList.Count != 0)
            {
                var developerList = new List<Developer>();
                foreach(var id in request.DeveloperList)
                {
                    var developerId = await _developerRepository.ReturnByIdAsync(id);
                    developerList.Add(developerId);     
                }
                await _gameRepository.AddDeveloperListAsync(gameToAdd, developerList);
            }

            if (request.GenreList.Count != 0)
            {
                var genreList = new List<Genre>();
                foreach (var id in request.GenreList)
                {
                    var genreId = await _genreRepository.ReturnByIdAsync(id);
                    genreList.Add(genreId);
                }
                await _gameRepository.AddGenreListAsync(gameToAdd, genreList);
            }

            if (request.PlatformList.Count != 0)
            {
                var platformList = new List<Platform>();
                foreach (var id in request.PlatformList)
                {
                    var platformId = await _platformRepository.ReturnByIdAsync(id);
                    platformList.Add(platformId);
                }
                await _gameRepository.AddPlatformListAsync(gameToAdd, platformList);
            }

            return game.Id;
        }
    }
}

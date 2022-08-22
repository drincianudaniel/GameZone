using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IGameRepository gameRepository, IDeveloperRepository developerRepository,
            IGenreRepository genreRepository, IPlatformRepository platformRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _developerRepository=developerRepository;
            _genreRepository=genreRepository;
            _platformRepository=platformRepository;
            _mapper=mapper;
        }
        public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var gameToAdd = new Game 
            {
                Name = request.Name,
                ReleaseDate = request.ReleaseDate,
                ImageSrc = request.ImageSrc,
                GameDetails = request.GameDetails
            };

            var createdGame = await _gameRepository.CreateAsync(gameToAdd);

            // var gameToAdd = await _gameRepository.ReturnByIdAsync(game.Id);

            if (request.DeveloperList.Any())
            {
                foreach(var id in request.DeveloperList)
                {
                    var dev = await _developerRepository.ReturnByIdAsync(id);

                    if (dev != null)
                    {
                        var gameDev = new GameDeveloper { GameId = createdGame.Id, DeveloperId = dev.Id };
                        await _gameRepository.AddDeveloper(gameDev);
                    }
                }
            }

            /*
            if (request.DeveloperList.Count != 0)
            {
                var developerList = new List<Developer>();
                foreach(var id in request.DeveloperList)
                {
                    var developerId = await _developerRepository.ReturnByIdAsync(id);
                    developerList.Add(developerId);     
                }
                await _gameRepository.AddDeveloperListAsync(gameToAdd, developerList);
            }*/

            if (request.GenreList.Count != 0)
            {
                var genreList = new List<Genre>();
                foreach (var id in request.GenreList)
                {
                    var genreId = await _genreRepository.ReturnByIdAsync(id);
                    genreList.Add(genreId);
                }
                await _gameRepository.AddGenreListAsync(createdGame, genreList);
            }

            if (request.PlatformList.Count != 0)
            {
                var platformList = new List<Platform>();
                foreach (var id in request.PlatformList)
                {
                    var platformId = await _platformRepository.ReturnByIdAsync(id);
                    platformList.Add(platformId);
                }
                await _gameRepository.AddPlatformListAsync(createdGame, platformList);
            }

            var gameDto = _mapper.Map<GameDto>(gameToAdd);
            return gameDto;
        }
    }
}

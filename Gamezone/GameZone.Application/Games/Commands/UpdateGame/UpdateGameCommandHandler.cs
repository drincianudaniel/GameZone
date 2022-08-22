using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IGameRepository gameRepository, IDeveloperRepository developerRepository,
            IGenreRepository genreRepository, IPlatformRepository platformRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _developerRepository=developerRepository;
            _genreRepository=genreRepository;
            _platformRepository=platformRepository;
            _mapper=mapper;
        }

        public async Task<GameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameToUpdate = new Game();
            gameToUpdate.Id = request.Id;
            gameToUpdate.Name = request.Name;
            gameToUpdate.ReleaseDate = request.ReleaseDate;
            gameToUpdate.ImageSrc = request.ImageSrc;
            gameToUpdate.GameDetails = request.ImageSrc;

/*            if (request.DeveloperList.Count != 0)
            {
                var developerList = new List<Developer>();
                foreach (var id in request.DeveloperList)
                {
                    var developerId = await _developerRepository.ReturnByIdAsync(id);
                    developerList.Add(developerId);
                }
                await _gameRepository.AddDeveloperListAsync(gameToUpdate, developerList);
            }*/

            if (request.GenreList.Count != 0)
            {
                var genreList = new List<Genre>();
                foreach (var id in request.GenreList)
                {
                    var genreId = await _genreRepository.ReturnByIdAsync(id);
                    genreList.Add(genreId);
                }
                await _gameRepository.AddGenreListAsync(gameToUpdate, genreList);
            }

            if (request.PlatformList.Count != 0)
            {
                var platformList = new List<Platform>();
                foreach (var id in request.PlatformList)
                {
                    var platformId = await _platformRepository.ReturnByIdAsync(id);
                    platformList.Add(platformId);
                }
                await _gameRepository.AddPlatformListAsync(gameToUpdate, platformList);
            }

            await _gameRepository.UpdateAsync(gameToUpdate);
            var gameDto = _mapper.Map<GameDto>(gameToUpdate);
            return gameDto;
        }
    }
}

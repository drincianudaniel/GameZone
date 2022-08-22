using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper =mapper;
        }
        public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            
            var game = new Game { Name = request.Name, ReleaseDate = request.ReleaseDate, ImageSrc = request.ImageSrc, GameDetails = request.GameDetails, Developers=new List<Developer>(), Genres = new List<Genre>(), Platforms = new List<Platform>()};

            await _unitOfWork.GameRepository.CreateAsync(game);

            if (request.DeveloperList.Count != 0)
            {
                var developerList = new List<Developer>();
                foreach(var id in request.DeveloperList)
                {
                    var developerId = await _unitOfWork.DeveloperRepository.ReturnByIdAsync(id);
                    developerList.Add(developerId);     
                }
                await _unitOfWork.GameRepository.AddDeveloperListAsync(game, developerList);
            }

            if (request.GenreList.Count != 0)
            {
                var genreList = new List<Genre>();
                foreach (var id in request.GenreList)
                {
                    var genreId = await _unitOfWork.GenreRepository.ReturnByIdAsync(id);
                    genreList.Add(genreId);
                }
                await _unitOfWork.GameRepository.AddGenreListAsync(game, genreList);
            }

            if (request.PlatformList.Count != 0)
            {
                var platformList = new List<Platform>();
                foreach (var id in request.PlatformList)
                {
                    var platformId = await _unitOfWork.PlatformRepository.ReturnByIdAsync(id);
                    platformList.Add(platformId);
                }
                await _unitOfWork.GameRepository.AddPlatformListAsync(game, platformList);
            }
            await _unitOfWork.SaveAsync();

            var gameToAdd = await _unitOfWork.GameRepository.ReturnByIdAsync(game.Id);
            var gameDto = _mapper.Map<GameDto>(gameToAdd);
            return gameDto;
        }
    }
}

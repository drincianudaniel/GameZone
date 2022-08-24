using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Game>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Game> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameToUpdate = new Game();
            gameToUpdate.Id = request.Id;
            gameToUpdate.Name = request.Name;
            gameToUpdate.ReleaseDate = request.ReleaseDate;
            gameToUpdate.ImageSrc = request.ImageSrc;
            gameToUpdate.GameDetails = request.GameDetails;

            /*
            if (request.DeveloperList.Count != 0)
            {
                var developerList = new List<Developer>();
                foreach (var id in request.DeveloperList)
                {
                    var developerId = await _developerRepository.ReturnByIdAsync(id);
                    developerList.Add(developerId);
                }
                await _gameRepository.AddDeveloperListAsync(gameToUpdate, developerList);
            }

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
            }*/

            await _unitOfWork.GameRepository.UpdateAsync(gameToUpdate);
            await _unitOfWork.SaveAsync();

            return gameToUpdate;
        }
    }
}

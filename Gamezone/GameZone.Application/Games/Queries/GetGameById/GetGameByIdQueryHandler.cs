using GameZone.Application.Dtos;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameWithUserFavoriteDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GameWithUserFavoriteDTO> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GameRepository.ReturnByIdAsync(request.Id);
            await _unitOfWork.GameRepository.CalculateTotalRatingAsync(result);
            await _unitOfWork.SaveAsync();


            var gameWithFavorite = new GameWithUserFavoriteDTO
            {
                Id = result.Id,
                Name = result.Name,
                GameDetails = result.GameDetails,
                ImageSrc = result.ImageSrc,
                ReleaseDate = result.ReleaseDate,
                TotalRating = result.TotalRating,
                Developers = result.Developers,
                Genres = result.Genres,
                Platforms = result.Platforms,
                IsFavorite = false,
            };


            if (request.UserName != null)
            {
                var userfavorites = await _unitOfWork.UserRepository.GetUserFavoriteGames(request.UserName);
                var userReviews = await _unitOfWork.UserRepository.GetUserReviews(request.UserName);
                foreach (var favorite in userfavorites)
                {
                    if (favorite.Id == result.Id)
                    {
                        gameWithFavorite.IsFavorite = true;
                    }
                }

                if (userReviews.Count() != 0)
                {
                    if(userReviews.FirstOrDefault().GameId == result.Id)
                    {
                        gameWithFavorite.Review = userReviews.FirstOrDefault();
                    }
                }
            }

            return gameWithFavorite;
        }
    }
}


using GameZone.Application.Dtos;
using GameZone.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGamesWithUserFavorites
{
    internal class GetGamesWithUserFavoritesQueryHandler : IRequestHandler<GetGamesWithUserFavoritesQuery, IEnumerable<GamesWithUserFavoritesDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetGamesWithUserFavoritesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GamesWithUserFavoritesDTO>> Handle(GetGamesWithUserFavoritesQuery request, CancellationToken cancellationToken)
        {
            var userfavorites = await _unitOfWork.UserRepository.GetUserFavoriteGames(request.UserName);
            var games = await _unitOfWork.GameRepository.ReturnPagedAsync(request.Page, request.PageSize, request.Filter);

            var gamesWithUserFavorites = new List<GamesWithUserFavoritesDTO>();

            foreach(var game in games)
            {
                var gameToAdd = new GamesWithUserFavoritesDTO
                {
                    Id= game.Id,
                    Name = game.Name,
                    ImageSrc = game.ImageSrc,
                    IsFavorite = false
                };

                gamesWithUserFavorites.Add(gameToAdd);

                foreach (var favorite in userfavorites)
                {
                    if (favorite.Id == game.Id)
                    {
                        gameToAdd.IsFavorite =true;
                    }
                }
            }
          
            return gamesWithUserFavorites;
        }
    }
}

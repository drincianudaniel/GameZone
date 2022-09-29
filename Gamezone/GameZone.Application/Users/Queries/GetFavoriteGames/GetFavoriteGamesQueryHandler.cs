using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.GetFavoriteGames
{
    public class GetFavoriteGamesQueryHandler : IRequestHandler<GetFavoriteGamesQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFavoriteGamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Game>> Handle(GetFavoriteGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _unitOfWork.UserRepository.GetUserFavoriteGames(request.UserName);
            return games;
        }
    }
}

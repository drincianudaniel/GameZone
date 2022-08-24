using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.SearchGames
{
    public class SearchGamesQueryHandler : IRequestHandler<SearchGamesQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchGamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Game>> Handle(SearchGamesQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.SearchGameAsync(request.searchString);
            return query;
        }
    }
}

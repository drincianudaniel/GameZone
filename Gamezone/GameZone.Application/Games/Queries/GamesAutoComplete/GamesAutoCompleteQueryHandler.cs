using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GamesAutoComplete
{
    public class GamesAutoCompleteQueryHandler : IRequestHandler<GamesAutoCompleteQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesAutoCompleteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Game>> Handle(GamesAutoCompleteQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.SearchGameAsync(request.searchString);
            return query;
        }
    }
}

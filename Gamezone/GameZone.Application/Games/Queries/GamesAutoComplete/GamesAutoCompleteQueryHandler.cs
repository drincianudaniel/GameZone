using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GamesAutoComplete
{
    public class GamesAutoCompleteQueryHandler : IRequestHandler<GamesAutoCompleteQuery, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesAutoCompleteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<string>> Handle(GamesAutoCompleteQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.SearchGameAsync(request.searchString);
            return query.Select(x => x.Name);
        }
    }
}



using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetNumberOfGames
{
    public class GetNumberOfGamesQueryHandler : IRequestHandler<GetNumberOfGamesQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNumberOfGamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public Task<IEnumerable<Game>> Handle(GetNumberOfGamesQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.GameRepository.GetNumberOfGames(request.Number, request.SortOrder);
            return query;
        }
    }
}

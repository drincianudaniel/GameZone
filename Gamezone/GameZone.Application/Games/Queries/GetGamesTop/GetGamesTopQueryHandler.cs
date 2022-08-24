using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesTop
{
    public class GetGamesTopQueryHandler : IRequestHandler<GetGamesTopQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGamesTopQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Game>> Handle(GetGamesTopQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.GenerateTopList();

            return query;
        }
    }
}

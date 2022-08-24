using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQueryHandler : IRequestHandler<GetGameListQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetGameListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Game>> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.ReturnAllAsync();

            return query;
        }        
    }
}

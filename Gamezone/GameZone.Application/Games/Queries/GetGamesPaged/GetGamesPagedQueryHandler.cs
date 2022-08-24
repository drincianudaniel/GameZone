using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGamesPaged
{
    public class GetGamesPagedQueryHandler : IRequestHandler<GetGamesPagedQuery, IEnumerable<Game>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetGamesPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Game>> Handle(GetGamesPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.ReturnPagedAsync(request.Page);
            return query;
        }
    }
}

using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.GameRepository.ReturnByIdAsync(id);
            await _unitOfWork.GameRepository.CalculateTotalRatingAsync(result);
            await _unitOfWork.SaveAsync();
            var result2 = await _unitOfWork.GameRepository.ReturnByIdAsync(id);
            return result2;
        }
    }
}


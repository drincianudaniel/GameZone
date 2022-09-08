using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Reviews.Queries.CountAsyncGameReviews
{
    public class CountAsyncGameReviewsQueryHandler : IRequestHandler<CountAsyncGameReviewsQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAsyncGameReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CountAsyncGameReviewsQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var count = await _unitOfWork.ReviewRepository.CountAsync(game);
            return count;
        }
    }
}

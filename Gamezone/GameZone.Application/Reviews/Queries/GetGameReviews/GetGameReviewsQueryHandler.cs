using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetGameReviews
{
    public class GetGameReviewsQueryHandler : IRequestHandler<GetGameReviewsQuery, IEnumerable<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Review>> Handle(GetGameReviewsQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var reviews = await _unitOfWork.ReviewRepository.ReturnGameReviews(game, request.Page, request.PageSize);

            return reviews;
        }
    }
}

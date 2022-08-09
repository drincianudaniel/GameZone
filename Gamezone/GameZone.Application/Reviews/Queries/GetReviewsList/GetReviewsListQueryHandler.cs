using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, IEnumerable<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewsListQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository=reviewRepository;
        }

        public Task<IEnumerable<ReviewDto>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var result = _reviewRepository.ReturnAll().Select(review => new ReviewDto
            {
                Id = review.Id,
                User = review.User,
                Game = review.Game,
                Rating = review.Rating,
                Content = review.Content,
            });

            return Task.FromResult(result);
        }
    }
}

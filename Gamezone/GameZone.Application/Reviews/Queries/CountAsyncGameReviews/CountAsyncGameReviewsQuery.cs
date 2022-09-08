using MediatR;

namespace GameZone.Application.Reviews.Queries.CountAsyncGameReviews
{
    public class CountAsyncGameReviewsQuery : IRequest<int>
    {
        public Guid GameId { get; set; }
    }
}

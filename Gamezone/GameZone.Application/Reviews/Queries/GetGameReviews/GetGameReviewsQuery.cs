using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetGameReviews
{
    public class GetGameReviewsQuery : IRequest<IEnumerable<Review>>
    {
        public Guid GameId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQuery : IRequest<IEnumerable<ReviewDto>>
    {
    }
}

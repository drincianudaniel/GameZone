using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQuery : IRequest<IEnumerable<Review>>
    {
    }
}

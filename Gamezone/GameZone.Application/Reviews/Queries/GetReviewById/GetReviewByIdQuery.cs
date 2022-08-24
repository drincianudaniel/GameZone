using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<Review>
    {
        public Guid Id { get; set; }
    }
}

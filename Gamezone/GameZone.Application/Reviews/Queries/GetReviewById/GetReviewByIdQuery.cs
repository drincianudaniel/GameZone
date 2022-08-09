using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewDto>
    {
        public Guid Id { get; set; }
    }
}

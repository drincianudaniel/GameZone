using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Review>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
    }
}

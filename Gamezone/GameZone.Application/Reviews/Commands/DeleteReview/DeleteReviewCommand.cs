using MediatR;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}

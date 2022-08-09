using MediatR;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}

using MediatR;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Guid>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<Guid> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            _reviewRepository.Delete(request.Id);
            return Task.FromResult(request.Id);
        }
    }
}

using MediatR;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Guid>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IGameRepository _gameRepository;
        public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IGameRepository gameRepository)
        {
            _reviewRepository = reviewRepository;
            _gameRepository=gameRepository;
        }

        public async Task<Guid> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.ReturnByIdAsync(request.Id);
            var game = await _gameRepository.ReturnByIdAsync(review.GameId);
            await _reviewRepository.DeleteAsync(review);
            await _gameRepository.CalculateTotalRatingAsync(game);
            return review.Id;
        }
    }
}

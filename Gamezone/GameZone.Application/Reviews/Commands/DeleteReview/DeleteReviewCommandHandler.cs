using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {

            var review = await _unitOfWork.ReviewRepository.ReturnByIdAsync(request.Id);
            await _unitOfWork.ReviewRepository.DeleteAsync(review);
            await _unitOfWork.SaveAsync();

            //not a very good practice
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(review.GameId);
            await _unitOfWork.GameRepository.CalculateTotalRatingAsync(game);
            await _unitOfWork.SaveAsync();

            return review.Id;
        }
    }
}

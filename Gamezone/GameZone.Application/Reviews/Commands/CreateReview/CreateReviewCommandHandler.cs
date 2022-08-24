using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review { UserId = request.UserId, GameId = request.GameId, Content = request.Content, Rating = request.Rating };
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            await _unitOfWork.ReviewRepository.CreateAsync(review);
            await _unitOfWork.GameRepository.CalculateTotalRatingAsync(game);
            await _unitOfWork.SaveAsync();
            return review;
        }
    }
}

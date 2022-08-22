using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review { UserId = request.UserId, GameId = request.GameId, Content = request.Content, Rating = request.Rating };
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            await _unitOfWork.ReviewRepository.CreateAsync(review);
            await _unitOfWork.GameRepository.CalculateTotalRatingAsync(game);

            await _unitOfWork.SaveAsync();

            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }
    }
}

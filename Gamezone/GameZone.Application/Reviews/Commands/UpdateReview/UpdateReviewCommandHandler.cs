using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Review> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = new Review();
            reviewToUpdate.Id = request.Id;
            reviewToUpdate.Content = request.Content;
            reviewToUpdate.Rating = request.Rating;
            reviewToUpdate.GameId = request.GameId;
            reviewToUpdate.UserId = request.UserId;

            await _unitOfWork.ReviewRepository.UpdateAsync(reviewToUpdate);
            await _unitOfWork.SaveAsync();

            return reviewToUpdate;
        }
    }
}

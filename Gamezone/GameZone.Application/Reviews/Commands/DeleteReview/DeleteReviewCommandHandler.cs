using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager=userManager;
        }

        public async Task<string> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {

            var review = await _unitOfWork.ReviewRepository.ReturnByIdAsync(request.Id);
            var user = await _unitOfWork.UserRepository.ReturnByIdAsync(request.UserId);

            if (((request.UserId == review.UserId) == true) || ((await _userManager.IsInRoleAsync(user, "Admin")) == true)) 
            {
                await _unitOfWork.ReviewRepository.DeleteAsync(review);
                await _unitOfWork.SaveAsync();
                return "Review deleted";
            }

            return "Not authorized";          
        }
    }
}

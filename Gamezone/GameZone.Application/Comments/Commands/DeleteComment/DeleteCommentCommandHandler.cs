using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager=userManager;
        }

        public async Task<string> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.ReturnByIdAsync(request.Id);
            var user = await _unitOfWork.UserRepository.ReturnByIdAsync(request.UserId);

            if (((request.UserId == comment.UserId) == true) || ((await _userManager.IsInRoleAsync(user, "Admin")) == true))
            {
                await _unitOfWork.CommentRepository.DeleteAsync(comment);
                await _unitOfWork.SaveAsync();
                return "Comment deleted";
            }

            return "Not authorized";
        }
    }
}

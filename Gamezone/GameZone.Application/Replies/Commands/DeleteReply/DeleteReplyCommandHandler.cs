using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Replies.Commands.DeleteReply
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;


        public DeleteReplyCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork=unitOfWork;
            _userManager=userManager;
        }

        public async Task<string> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _unitOfWork.ReplyRepository.ReturnByIdAsync(request.Id);
            var user = await _unitOfWork.UserRepository.ReturnSimplyByIdAsync(request.UserId);

            if (((request.UserId == reply.UserId) == true) || ((await _userManager.IsInRoleAsync(user, "Admin")) == true))
            {
                await _unitOfWork.ReplyRepository.DeleteAsync(reply);
                await _unitOfWork.SaveAsync();
                return "Reply deleted";
            }
            return "Not authorized";
        }
    }
}

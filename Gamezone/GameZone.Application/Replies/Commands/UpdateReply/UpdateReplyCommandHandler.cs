using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Commands.UpdateReply
{
    public class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommand, Reply>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Reply> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
        {
            var replyToUpdate = new Reply();
            replyToUpdate.Id = request.Id;
            replyToUpdate.Content = request.Content;
            replyToUpdate.CommentId = request.CommentId;
            replyToUpdate.UserId = request.UserId;

            await _unitOfWork.ReplyRepository.UpdateAsync(replyToUpdate);
            await _unitOfWork.SaveAsync();

            return replyToUpdate;
        }
    }
}

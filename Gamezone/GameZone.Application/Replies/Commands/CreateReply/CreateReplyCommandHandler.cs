using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Reply>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Reply> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = new Reply { UserId = request.UserId, CommentId = request.CommentId, Content = request.Content };

            await _unitOfWork.ReplyRepository.CreateAsync(reply);
            await _unitOfWork.SaveAsync();

            var replyToReturn = await _unitOfWork.ReplyRepository.ReturnByIdAsync(reply.Id);
            return replyToReturn;
        }
    }
}

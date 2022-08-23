using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Replies.Commands.DeleteReply
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Guid> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _unitOfWork.ReplyRepository.ReturnByIdAsync(request.Id);
            await _unitOfWork.ReplyRepository.DeleteAsync(reply);
            await _unitOfWork.SaveAsync();
            return reply.Id;
        }
    }
}

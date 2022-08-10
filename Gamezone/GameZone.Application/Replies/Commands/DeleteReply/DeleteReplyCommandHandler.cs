using MediatR;

namespace GameZone.Application.Replies.Commands.DeleteReply
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, Guid>
    {
        private readonly IReplyRepository _replyRepository;

        public DeleteReplyCommandHandler(IReplyRepository replyRepository)
        {
            _replyRepository=replyRepository;
        }

        public async Task<Guid> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _replyRepository.ReturnByIdAsync(request.Id);
            await _replyRepository.DeleteAsync(reply);
            return reply.Id;
        }
    }
}

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

        public Task<Guid> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            _replyRepository.Delete(request.Id);
            return Task.FromResult(request.Id);
        }
    }
}

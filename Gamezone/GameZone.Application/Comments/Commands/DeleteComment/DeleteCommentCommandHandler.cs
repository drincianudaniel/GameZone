using MediatR;

namespace GameZone.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Guid>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<Guid> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _commentRepository.Delete(request.Id);
            return Task.FromResult(request.Id);
        }
    }
}

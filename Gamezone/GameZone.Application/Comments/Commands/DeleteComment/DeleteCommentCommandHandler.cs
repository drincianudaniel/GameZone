using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.CommentRepository.DeleteAsync(comment);
            await _unitOfWork.SaveAsync();

            return request.Id;
        }
    }
}

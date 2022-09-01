using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToUpdate = new Comment();
            commentToUpdate.Id = request.Id;
            commentToUpdate.Content = request.Content;
            commentToUpdate.GameId = request.GameId;
            commentToUpdate.UserId = request.UserId;

            await _unitOfWork.CommentRepository.UpdateAsync(commentToUpdate);
            await _unitOfWork.SaveAsync();

            return commentToUpdate;
        }
    }
}

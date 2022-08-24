using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.CommentRepository.ReturnByIdAsync(id);

            return result;
        }
    }
}

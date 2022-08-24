using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetCommentsList
{
    public class GetCommentsListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<Comment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentsListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Comment>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.CommentRepository.ReturnAllAsync();

            return query;
        }
    }
}

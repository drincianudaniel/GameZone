using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Replies.Queries.GetCommentReplies
{
    public class GetCommentRepliesQueryHandler : IRequestHandler<GetCommentRepliesQuery, IEnumerable<Reply>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentRepliesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Reply>> Handle(GetCommentRepliesQuery request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.ReturnByIdAsync(request.CommentId);
            var reviews = await _unitOfWork.ReplyRepository.ReturnCommentReplies(comment, request.Page, request.PageSize);

            return reviews;
        }
    }
}

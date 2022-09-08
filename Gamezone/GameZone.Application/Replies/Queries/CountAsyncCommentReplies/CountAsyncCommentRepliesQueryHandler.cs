using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Replies.Queries.CountAsyncCommentReviews
{
    public class CountAsyncCommentRepliesQueryHandler : IRequestHandler<CountAsyncCommentRepliesQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAsyncCommentRepliesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CountAsyncCommentRepliesQuery request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.ReturnByIdAsync(request.CommentId);
            var count = await _unitOfWork.ReplyRepository.CountAsync(comment);
            return count;
        }
    }
}

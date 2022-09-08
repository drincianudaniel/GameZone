using MediatR;

namespace GameZone.Application.Replies.Queries.CountAsyncCommentReviews
{
    public class CountAsyncCommentRepliesQuery : IRequest<int>
    {
        public Guid CommentId { get; set; }
    }
}

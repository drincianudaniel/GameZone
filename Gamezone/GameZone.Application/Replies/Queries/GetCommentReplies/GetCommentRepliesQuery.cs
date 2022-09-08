using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetCommentReplies
{
    public class GetCommentRepliesQuery : IRequest<IEnumerable<Reply>>
    {
        public Guid CommentId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

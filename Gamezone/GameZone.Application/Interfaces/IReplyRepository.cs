using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IReplyRepository : IBaseRepository<Reply>
    {
        Task<int> CountAsync(Comment comment);
        Task<IEnumerable<Reply>> ReturnCommentReplies(Comment comment, int? page, int pageSize);
    }
}

using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<int> CountAsync(Game game);
        Task<IEnumerable<Comment>> ReturnGameComments(Game game, int? page, int pageSize);
    }
}

using GameZoneModels;

namespace GameZone.Application
{
    public interface ICommentRepository
    {
        Task CreateAsync(Comment comment);
        Task DeleteAsync(Comment comment);
        Task<IEnumerable<Comment>> ReturnAllAsync();
        Task<Comment> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Comment comment);
    }
}

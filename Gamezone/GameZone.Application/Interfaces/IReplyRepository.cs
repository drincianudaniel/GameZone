using GameZoneModels;

namespace GameZone.Application
{
    public interface IReplyRepository
    {
        Task CreateAsync(Reply reply);
        Task DeleteAsync(Reply reply);
        Task<IEnumerable<Reply>> ReturnAllAsync();
        Task<Reply> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Reply reply);
    }
}

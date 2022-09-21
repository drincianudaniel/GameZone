using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IPlatformRepository : IBaseRepository<Platform>
    {
        Task<int> CountAsync();
        Task<IEnumerable<Platform>> ReturnPagedAsync(int? page, int pageSize, string searchString);
    }
}

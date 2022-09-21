using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IPlatformRepository : IBaseRepository<Platform>
    {
        Task<int> CountAsync(string searchString);
        Task<IEnumerable<Platform>> ReturnPagedAsync(int? page, int pageSize, string searchString);
    }
}

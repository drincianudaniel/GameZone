using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IDeveloperRepository : IBaseRepository<Developer>
    {
        Task<int> CountAsync();
        Task<IEnumerable<Developer>> ReturnPagedAsync(int? page, int pageSize);
    }
}

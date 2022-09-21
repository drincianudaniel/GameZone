using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IDeveloperRepository : IBaseRepository<Developer>
    {
        Task<int> CountAsync(string searchString);
        Task<IEnumerable<Developer>> ReturnPagedAsync(int? page, int pageSize, string searchString);
    }
}

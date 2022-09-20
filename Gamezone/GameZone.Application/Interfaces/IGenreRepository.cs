using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<int> CountAsync();
        Task<IEnumerable<Genre>> ReturnPagedAsync(int? page, int pageSize);
    }
}

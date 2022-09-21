using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<int> CountAsync(string searchString);
        Task<IEnumerable<Genre>> ReturnPagedAsync(int? page, int pageSize, string searchString);
    }
}

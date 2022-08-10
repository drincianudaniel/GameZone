using GameZoneModels;

namespace GameZone.Application
{
    public interface IGenreRepository
    {
        Task CreateAsync(Genre Genre);
        Task DeleteAsync(Genre genre);
        Task<IEnumerable<Genre>> ReturnAllAsync();
        Task<Genre> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Genre genre);
    }
}

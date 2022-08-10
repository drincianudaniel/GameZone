using GameZoneModels;

namespace GameZone.Application
{
    public interface IDeveloperRepository
    {
        Task CreateAsync(Developer Developer);
        Task DeleteAsync(Developer developer);
        Task<IEnumerable<Developer>> ReturnAllAsync();
        Task<Developer> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Developer developer);
    }
}

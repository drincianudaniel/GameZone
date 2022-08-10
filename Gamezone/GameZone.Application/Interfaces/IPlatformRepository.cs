using GameZoneModels;

namespace GameZone.Application
{
    public interface IPlatformRepository
    {
        Task CreateAsync(Platform platform);
        Task DeleteAsync(Platform platform);
        Task<IEnumerable<Platform>> ReturnAllAsync();
        Task<Platform> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Platform platform);
    }
}

using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository
    {
        void CalculateTotalRating(Game game);
        Task CreateAsync(Game game);
        Task DeleteAsync(Game game);
        Task<IEnumerable<Game>> ReturnAllAsync();
        Task<Game> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Game game);
    }
}

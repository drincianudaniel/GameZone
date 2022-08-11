using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository
    {
        void AddDeveloper(Game game, Developer developer);
        Task AddDeveloperListAsync(Game game, List<Developer> developers);
        Task AddGenreAsync(Game game, Genre genre);
        Task AddGenreListAsync(Game game, List<Genre> genres);
        Task AddPlatformAsync(Game game, Platform platform);
        Task AddPlatformListAsync(Game game, List<Platform> platforms);
        void CalculateTotalRating(Game game);
        Task CreateAsync(Game game);
        Task DeleteAsync(Game game);
        Task<IEnumerable<Game>> ReturnAllAsync();
        Task<Game> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Game game);
    }
}

using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        void AddDeveloper(Game game, Developer developer);
        Task AddDeveloperListAsync(Game game, List<Developer> developers);
        Task AddGenreAsync(Game game, Genre genre);
        Task AddGenreListAsync(Game game, List<Genre> genres);
        Task AddPlatformAsync(Game game, Platform platform);
        Task AddPlatformListAsync(Game game, List<Platform> platforms);
        Task CalculateTotalRatingAsync(Game game);
        Task<IEnumerable<Game>> GenerateTopList();
    }
}

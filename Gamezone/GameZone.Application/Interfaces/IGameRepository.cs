using GameZone.Domain.Models;
using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task AddDeveloper(GameDeveloper gameDev);

        Task AddGenreAsync(Game game, Genre genre);
        Task AddGenreListAsync(Game game, List<Genre> genres);
        Task AddPlatformAsync(Game game, Platform platform);
        Task AddPlatformListAsync(Game game, List<Platform> platforms);
        Task CalculateTotalRatingAsync(Game game);
        Task<IEnumerable<Game>> GenerateTopList();
        Task RemoveGenreAsync(Game game, Genre genre);
        Task RemovePlatformAsync(Game game, Platform platform);
        Task<IEnumerable<Game>> SearchGameAsync(string searchString);
    }
}

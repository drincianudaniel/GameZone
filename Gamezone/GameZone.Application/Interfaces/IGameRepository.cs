using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository
    {
        void AddDeveloper(Guid gameId, Developer developer);
        void AddGenre(Guid gameId, Genre genre);
        void AddPlatform(Guid gameId, Platform platform);
        void CalculateTotalRating(Game game);
        void Create(Game game);
        void Delete(Guid id);
        IEnumerable<Game> GenerateTopList();
        IEnumerable<Game> ReturnAll();
        Game ReturnById(Guid id);
        void Update(Game game);
    }
}

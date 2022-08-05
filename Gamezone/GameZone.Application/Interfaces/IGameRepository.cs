using GameZoneModels;

namespace GameZone.Application
{
    public interface IGameRepository
    {
        void AddDeveloper(int gameId, Developer developer);
        void AddGenre(int gameId, Genre genre);
        void AddPlatform(int gameId, Platform platform);
        void CalculateTotalRating(Game game);
        void Create(Game game);
        void Delete(int id);
        IEnumerable<Game> GenerateTopList();
        IEnumerable<Game> ReturnAll();
        Game ReturnById(int id);
        void Update(int id, Game game);
    }
}

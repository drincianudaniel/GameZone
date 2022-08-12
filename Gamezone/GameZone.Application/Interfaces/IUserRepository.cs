using GameZoneModels;

namespace GameZone.Application
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task AddGameToFavorite(User user, Game favoriteGame);
    }
}

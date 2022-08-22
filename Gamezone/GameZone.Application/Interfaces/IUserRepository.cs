using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task AddGameToFavorite(User user, Game favoriteGame);
        Task RemoveGameFromFavorites(User user, Game favoriteGame);
    }
}

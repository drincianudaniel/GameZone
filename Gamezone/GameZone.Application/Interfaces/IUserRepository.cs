using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IUserRepository
    {
        Task AddGameToFavorite(User user, Game favoriteGame);
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        Task<IEnumerable<Game>> GetUserFavoriteGames(Guid id);
        Task RemoveGameFromFavorites(User user, Game favoriteGame);
        Task<IEnumerable<User>> ReturnAllAsync();
        Task<User> ReturnByIdAsync(Guid id);
        Task UpdateAsync(User user);
    }
}

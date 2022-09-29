using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IUserRepository
    {
        Task AddGameToFavorite(User user, Game favoriteGame);
        Task<int> CountAsync(string searchString);
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        Task<IEnumerable<Game>> GetUserFavoriteGames(string username);
        Task RemoveGameFromFavorites(User user, Game favoriteGame);
        Task<IEnumerable<User>> ReturnAllAsync();
        Task<User> ReturnByIdAsync(Guid id);
        Task<IEnumerable<User>> ReturnPagedAsync(int? page, int pageSize, string searchString);
        Task UpdateAsync(User user);
    }
}

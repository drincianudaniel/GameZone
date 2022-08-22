using GameZone.Application;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameZoneContext _context;
        public UserRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ReturnByIdAsync(Guid id)
        {
            var userToReturn = await _context.Users
                .Where(user => user.Id == id)
                .Include(x => x.Games)
                .Include(x => x.Comments).ThenInclude(x => x.Game)
                .Include(x => x.Replies)
                .Include(x => x.Reviews).ThenInclude(x => x.Game)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (userToReturn == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return userToReturn;
        }

        public async Task<IEnumerable<User>> ReturnAllAsync()
        {
            return await _context.Users
                .Include(x => x.Games)
                .Include(x => x.Comments).ThenInclude(x => x.Game)
                .Include(x => x.Replies)
                .Include(x => x.Reviews).ThenInclude(x => x.Game)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task AddGameToFavorite(User user, Game favoriteGame)
        {
            user.Games.Add(favoriteGame);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveGameFromFavorites(User user, Game favoriteGame)
        {
            user.Games.Remove(favoriteGame);
            await _context.SaveChangesAsync();
        }
    }
}

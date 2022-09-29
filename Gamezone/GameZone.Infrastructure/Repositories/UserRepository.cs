using GameZone.Application;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
        }

        public async Task<User> ReturnByIdAsync(Guid id)
        {
            var userToReturn = await _context.Users
                .Where(user => user.Id == id)
                .Include(x => x.Games)
                .Include(x => x.Comments).ThenInclude(x => x.Game)
                .Include(x => x.Replies)
                .Include(x => x.Reviews).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync();

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
        public async Task<IEnumerable<User>> ReturnPagedAsync(int? page, int pageSize, string searchString)
        {
            int pageNumber = (page ?? 1);

            var users = from g in _context.Users select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(p => p.UserName!.Contains(searchString));
            }

            return await users
                .AsNoTracking()
                .OrderByDescending(user => user.UserName)
                .ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<int> CountAsync(string searchString)
        {
            var users = from p in _context.Users select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(p => p.UserName!.Contains(searchString));
            }

            return await users.CountAsync();
        }

        public async Task<IEnumerable<Game>> GetUserFavoriteGames(Guid id)
        {
            return await _context.Users.Include(x => x.Games).Where(x => x.Id == id).FirstOrDefault().Games.ToListAsync();
        } 

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }
        public async Task AddGameToFavorite(User user, Game favoriteGame)
        {
            user.Games.Add(favoriteGame);
        }

        public async Task RemoveGameFromFavorites(User user, Game favoriteGame)
        {
            user.Games.Remove(favoriteGame);
        }
    }
}

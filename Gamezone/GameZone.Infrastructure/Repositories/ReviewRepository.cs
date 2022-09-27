using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace GameZone.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GameZoneContext _context;

        public ReviewRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
        }
      
        public async Task<Review> ReturnByIdAsync(Guid id)
        {
            var reviewToReturn = await _context.Reviews
                .Include(x => x.Game)
                .Include(x => x.User)
                .Where(review => review.Id == id)
                .FirstOrDefaultAsync();

            return reviewToReturn;
        }

        public async Task<IEnumerable<Review>> ReturnAllAsync()
        {
            return await _context.Reviews
                .Include(x => x.Game)
                .Include(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> ReturnGameReviews(Game game, int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);

            return await _context.Reviews
                .Where(id => id.GameId == game.Id)
                .Include(x => x.User)
                .Include(x => x.Game)
                .AsNoTracking()
                .OrderByDescending(date => date.CreatedAt)
                .ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<int> CountAsync(Game game)
        {
            return await _context.Reviews.Where(id => id.GameId == game.Id).CountAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Update(review);
        }
        public async Task DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
        }
    }
}

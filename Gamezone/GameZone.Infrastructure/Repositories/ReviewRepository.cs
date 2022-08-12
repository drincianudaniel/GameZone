using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

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
            await _context.SaveChangesAsync();
        }
      
        public async Task<Review> ReturnByIdAsync(Guid id)
        {
            var reviewToReturn = await _context.Reviews
                .Include(x => x.Game)
                .Include(x => x.User)
                .Where(review => review.Id == id)
                .FirstOrDefaultAsync();
            if (reviewToReturn == null)
            {
                throw new KeyNotFoundException("Review not found");
            }
            return reviewToReturn;
        }

        public async Task<IEnumerable<Review>> ReturnAllAsync()
        {
            return await _context.Reviews
                .Include(x => x.Game)
                .Include(x => x.User)
                .ToListAsync();
        }
        public async Task UpdateAsync(Review review)
        {
            _context.Update(review);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}

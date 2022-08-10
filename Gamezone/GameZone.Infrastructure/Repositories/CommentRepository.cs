using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GameZoneContext _context;

        public CommentRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> ReturnByIdAsync(Guid id)
        {
            var commentToReturn = _context.Comments.Where(comment => comment.Id == id).FirstOrDefaultAsync();
            if (commentToReturn == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }
            return await commentToReturn;
        }

        public async Task<IEnumerable<Comment>> ReturnAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
        
        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
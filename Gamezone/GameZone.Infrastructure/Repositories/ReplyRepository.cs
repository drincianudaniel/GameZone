using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly GameZoneContext _context;

        public ReplyRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Reply reply)
        {
            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task<Reply> ReturnByIdAsync(Guid id)
        {
            var replyToReturn = await _context.Replies.Where(reply => reply.Id == id).FirstOrDefaultAsync();
            if (replyToReturn == null)
            {
                throw new KeyNotFoundException("Reply not found");
            }
            return replyToReturn;
        }

        public async Task<IEnumerable<Reply>> ReturnAllAsync()
        {
            return await _context.Replies.ToListAsync();
        }

        public async Task UpdateAsync(Reply reply)
        {
            _context.Replies.Update(reply);
            await _context.SaveChangesAsync();
        }
   

        public async Task DeleteAsync(Reply reply)
        {
            _context.Replies.Remove(reply);
            await _context.SaveChangesAsync();
        }
    }
}

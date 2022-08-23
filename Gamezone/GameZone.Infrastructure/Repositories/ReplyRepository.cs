using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
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
        }

        public async Task<Reply> ReturnByIdAsync(Guid id)
        {
            var replyToReturn = await _context.Replies.Where(reply => reply.Id == id).Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return replyToReturn;
        }

        public async Task<IEnumerable<Reply>> ReturnAllAsync()
        {
            return await _context.Replies.Include(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Reply reply)
        {
            _context.Replies.Update(reply);
        }
   

        public async Task DeleteAsync(Reply reply)
        {
            _context.Replies.Remove(reply);
        }
    }
}

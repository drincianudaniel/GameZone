using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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

        public async Task<IEnumerable<Reply>> ReturnCommentReplies(Comment comment, int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);

            return await _context.Replies
                .Where(id => id.CommentId == comment.Id)
                .Include(x => x.User)
                .AsNoTracking()
                .OrderByDescending(date => date.CreatedAt)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync(Comment comment)
        {
            return await _context.Replies.Where(id => id.CommentId == comment.Id).CountAsync();
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

﻿using GameZone.Application;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
        }

        public async Task<Comment> ReturnByIdAsync(Guid id)
        {
            var commentToReturn = await _context.Comments
                .Where(comment => comment.Id == id)
                .Include(x => x.Replies).ThenInclude(x => x.User)
                .Include(x => x.User)
                .Include(x => x.Game)
                .FirstOrDefaultAsync();

            return commentToReturn;
        }

        public async Task<IEnumerable<Comment>> ReturnAllAsync()
        {
            return await _context.Comments
                .Include(x => x.Replies).ThenInclude(x => x.User)
                .Include(x => x.User)
                .Include(x => x.Game)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Comment>> ReturnGameComments(Game game, int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);

            return await _context.Comments
                .Where(id => id.GameId == game.Id)
                .Include(x => x.Replies).ThenInclude(x => x.User)
                .Include(x => x.User)
                .Include(x => x.Game)
                .AsNoTracking()
                .OrderByDescending(date => date.CreatedAt)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync(Game game)
        {
            return await _context.Comments.Where(id => id.GameId == game.Id).CountAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
        }
        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}
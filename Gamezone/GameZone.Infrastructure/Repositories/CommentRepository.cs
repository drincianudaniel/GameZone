using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GameZoneContext _context;

        public CommentRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Comment ReturnById(Guid id)
        {
            var commentToReturn = _context.Comments.Where(comment => comment.Id == id).FirstOrDefault();
            if (commentToReturn == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }
            return commentToReturn;
        }

        public IEnumerable<Comment> ReturnAll()
        {
            return _context.Comments;
        }
        
        public void Update(Comment comment)
        {
            var commentAux = _context.Comments.Where(genre => genre.Id == genre.Id).FirstOrDefault();
            if (commentAux == null)
            {
                throw new NullReferenceException("Comment doesnt exist");
            }
            _context.Comments.Remove(commentAux);
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var commentToBeRemoved = ReturnById(id);
            _context.Comments.Remove(commentToBeRemoved);
            _context.SaveChanges();
        }
    }
}
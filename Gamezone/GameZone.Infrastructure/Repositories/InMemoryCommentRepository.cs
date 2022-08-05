using GameZone.Application;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryCommentRepository : ICommentRepository
    {
        private readonly List<Comment> _comments;
        public InMemoryCommentRepository()
        {
            _comments = new List<Comment>();
        }
        public void Create(Comment comment)
        {
            _comments.Add(comment);
        }

        public Comment ReturnById(int id)
        {
            var commentToReturn = _comments.Find(comment => comment.Id == id);
            if (commentToReturn == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }
            return commentToReturn;
        }

        public IEnumerable<Comment> ReturnAll()
        {
            if (_comments.Count() == 0)
            {
                throw new NullReferenceException("Comments list is null");
            }
            return _comments;
        }
        
        public void Update(int id, Comment comment)
        {
            var commmentToBeEdited = ReturnById(id);
            commmentToBeEdited.Content = comment.Content;
        }
        public void Delete(int id)
        {
            var commentToBeRemoved = ReturnById(id);
            _comments.Remove(commentToBeRemoved);
        }
    }
}
using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private List<Comment> Comments { get; set; }
        public CommentRepository()
        {
            Comments = new List<Comment>();
        }
        public void Create(Comment comment)
        {
            Comments.Add(comment);
        }

        public Comment ReturnById(int id)
        {
            var commentToReturn = Comments.Find(review => review.Id == id);
            if (commentToReturn == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }
            return commentToReturn;
        }

        public List<Comment> ReturnAll()
        {
            return Comments;
        }
        
        public void Update(int id, Comment comment)
        {
            var commmentToBeEdited = ReturnById(id);
            commmentToBeEdited.Content = comment.Content;
        }
        public void Delete(int id)
        {
            var commentToBeRemoved = ReturnById(id);
            Comments.Remove(commentToBeRemoved);
        }
    }
}

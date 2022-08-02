using GameZone.Application;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryReplyRepository : IReplyRepository
    {
        private readonly List<Reply> Replies;
        public InMemoryReplyRepository()
        {
            Replies = new List<Reply>();
        }
        public void Create(Reply reply)
        {
            Replies.Add(reply);
        }

        public Reply ReturnById(int id)
        {
            var replyToReturn = Replies.Find(review => review.Id == id);
            if (replyToReturn == null)
            {
                throw new KeyNotFoundException("Reply not found");
            }
            return replyToReturn;
        }

        public void Update(int id, Reply reply)
        {
            var replyToBeEdited = ReturnById(id);
            replyToBeEdited.Content = reply.Content;
        }
        public IEnumerable<Reply> ReturnAll()
        {
            if (Replies.Count() == 0)
            {
                throw new NullReferenceException("Replies list is null");
            }
            return Replies;
        }

        public void Delete(int id)
        {
            var replyToBeRemoved = ReturnById(id);
            Replies.Remove(replyToBeRemoved);
        }
    }
}

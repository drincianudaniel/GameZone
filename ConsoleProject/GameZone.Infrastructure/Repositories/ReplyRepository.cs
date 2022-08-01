using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private List<Reply> Replies { get; set; }
        public ReplyRepository()
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
        public List<Reply> ReturnAll()
        {
            return Replies;
        }

        public void Delete(int id)
        {
            var replyToBeRemoved = ReturnById(id);
            Replies.Remove(replyToBeRemoved);
        }
    }
}

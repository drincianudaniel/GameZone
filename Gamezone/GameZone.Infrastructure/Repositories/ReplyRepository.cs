using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly GameZoneContext _context;

        public ReplyRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Reply reply)
        {
            _context.Replies.Add(reply);
            _context.SaveChanges();
        }

        public Reply ReturnById(Guid id)
        {
            var replyToReturn = _context.Replies.Where(reply => reply.Id == id).FirstOrDefault();
            if (replyToReturn == null)
            {
                throw new KeyNotFoundException("Reply not found");
            }
            return replyToReturn;
        }

        public IEnumerable<Reply> ReturnAll()
        {
            return _context.Replies;
        }

        public void Update(Reply reply)
        {
            var replyAux = _context.Replies.Where(reply => reply.Id == reply.Id).FirstOrDefault();
            if (replyAux == null)
            {
                throw new NullReferenceException("Reply doesnt exist");
            }
            _context.Replies.Remove(replyAux);
            _context.Replies.Add(reply);
            _context.SaveChanges();
        }
   

        public void Delete(Guid id)
        {
            var replyToBeRemoved = ReturnById(id);
            _context.Replies.Remove(replyToBeRemoved);
            _context.SaveChanges();
        }
    }
}

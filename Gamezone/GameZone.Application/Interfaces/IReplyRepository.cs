using GameZoneModels;

namespace GameZone.Application
{
    public interface IReplyRepository
    {
        void Create(Reply reply);
        void Delete(Guid id);
        IEnumerable<Reply> ReturnAll();
        Reply ReturnById(Guid id);
        void Update(Guid id, Reply reply);
    }
}

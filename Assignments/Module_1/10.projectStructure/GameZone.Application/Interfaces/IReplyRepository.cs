using GameZoneModels;

namespace GameZone.Application
{
    public interface IReplyRepository
    {
        void Create(Reply reply);
        void Delete(int id);
        IEnumerable<Reply> ReturnAll();
        Reply ReturnById(int id);
        void Update(int id, Reply reply);
    }
}

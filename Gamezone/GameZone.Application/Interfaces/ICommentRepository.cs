using GameZoneModels;

namespace GameZone.Application
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        void Delete(int id);
        IEnumerable<Comment> ReturnAll();
        Comment ReturnById(int id);
        void Update(int id, Comment comment);
    }
}

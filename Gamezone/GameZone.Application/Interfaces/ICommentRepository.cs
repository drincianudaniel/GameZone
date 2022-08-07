using GameZoneModels;

namespace GameZone.Application
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        void Delete(Guid id);
        IEnumerable<Comment> ReturnAll();
        Comment ReturnById(Guid id);
        void Update(Guid id, Comment comment);
    }
}

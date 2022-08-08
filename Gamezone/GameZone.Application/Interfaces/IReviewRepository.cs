using GameZoneModels;

namespace GameZone.Application
{
    public interface IReviewRepository
    {
        void Create(Review review);
        void Delete(Guid id);
        IEnumerable<Review> ReturnAll();
        Review ReturnById(Guid id);
        void Update(Review review);
    }
}

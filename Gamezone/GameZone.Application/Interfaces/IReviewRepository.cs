using GameZoneModels;

namespace GameZone.Application
{
    public interface IReviewRepository
    {
        void Create(Review review);
        void Delete(int id);
        IEnumerable<Review> ReturnAll();
        Review ReturnById(int id);
        void Update(int id, Review review);
    }
}

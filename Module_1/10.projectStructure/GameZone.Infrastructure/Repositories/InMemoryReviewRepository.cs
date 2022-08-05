using GameZone.Application;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryReviewRepository : IReviewRepository
    {
        private readonly List<Review> Reviews;

        public InMemoryReviewRepository()
        {
            Reviews = new List<Review>();
        }

        public void Create(Review review)
        {
            Reviews.Add(review);
        }
        public void Update(int id, Review review)
        {
            var reviewToBeEdited = ReturnById(id);
            reviewToBeEdited.Content = review.Content;
            reviewToBeEdited.Rating = review.Rating;
        }
        public Review ReturnById(int id)
        {
            var reviewToReturn = Reviews.Find(review => review.Id == id);
            if (reviewToReturn == null)
            {
                throw new KeyNotFoundException("Review not found");
            }
            return reviewToReturn;
        }

        public IEnumerable<Review> ReturnAll()
        {
            if (Reviews.Count() == 0)
            {
                throw new NullReferenceException("Reviews list is null");
            }
            return Reviews;
        }

        public void Delete(int id)
        {
            var reviewToBeRemoved = ReturnById(id);
            Reviews.Remove(reviewToBeRemoved);
        }
    }
}

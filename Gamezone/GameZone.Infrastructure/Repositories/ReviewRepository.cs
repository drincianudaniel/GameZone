using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GameZoneContext _context;

        public ReviewRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
      
        public Review ReturnById(Guid id)
        {
            var reviewToReturn = _context.Reviews.Where(review => review.Id == id).FirstOrDefault();
            if (reviewToReturn == null)
            {
                throw new KeyNotFoundException("Review not found");
            }
            return reviewToReturn;
        }

        public IEnumerable<Review> ReturnAll()
        {
            return _context.Reviews;
        }
        public void Update(Review review)
        {
            var reviewAux = _context.Reviews.Where(review => review.Id == review.Id).FirstOrDefault();
            if (reviewAux == null)
            {
                throw new NullReferenceException("Review doesnt exist");
            }
            _context.Reviews.Remove(reviewAux);
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var reviewToBeRemoved = ReturnById(id);
            _context.Reviews.Remove(reviewToBeRemoved);
            _context.SaveChanges();
        }
    }
}

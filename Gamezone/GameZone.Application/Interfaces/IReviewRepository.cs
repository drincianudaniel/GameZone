using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<int> CountAsync(Game game);
        Task<IEnumerable<Review>> ReturnGameReviews(Game game, int? page, int pageSize);
    }
}

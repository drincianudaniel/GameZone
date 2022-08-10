using GameZoneModels;

namespace GameZone.Application
{
    public interface IReviewRepository
    {
        Task CreateAsync(Review review);
        Task DeleteAsync(Review review);
        Task<IEnumerable<Review>> ReturnAllAsync();
        Task<Review> ReturnByIdAsync(Guid id);
        Task UpdateAsync(Review review);
    }
}

using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> ReturnByIdAsync(Guid id);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> ReturnAllAsync();
    }
}

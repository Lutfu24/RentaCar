using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract;

public interface IAsyncRepository<T> where T : class, IEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}

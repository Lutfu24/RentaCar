using RentaCar.Entities.Concrete;
using System.Linq.Expressions;

namespace RentaCar.DataAccessLayer.Abstract;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync(Expression<Func<Car, bool>> expression=null, string[] includes=null,bool tracking=true, CancellationToken cancellationToken=default);
    Task<Car> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);
    Task<Car> AddAsync(Car car, CancellationToken cancellationToken=default);
    Task<Car> DeleteAsync(Car car, CancellationToken cancellationToken = default);
    Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken = default);
    Task<bool> IsExistAsync(Expression<Func<Car, bool>> expression, CancellationToken cancellationToken = default);
}

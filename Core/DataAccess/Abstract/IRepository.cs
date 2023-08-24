using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract;

public interface IRepository<T> where T : class, IEntity, new()
{
    List<T> GetAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool tracking = true);
    T Get(Expression<Func<T, bool>> expression, string[] includes = null, bool tracking = true);
    T Add(T entity);
    T Delete(T entity);
    T Update(T entity);
    bool IsExist(Expression<Func<T, bool>> expression);
}

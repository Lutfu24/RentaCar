using Microsoft.EntityFrameworkCore;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.Entities.Concrete;
using System.Linq.Expressions;

namespace RentaCar.DataAccessLayer.Concrete;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Car> AddAsync(Car car, CancellationToken cancellationToken = default)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync(cancellationToken);
        return car;
    }

    public async Task<Car> DeleteAsync(Car car, CancellationToken cancellationToken = default)
    {
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync(cancellationToken);
        return car;
    }
    public async Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken = default)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync(cancellationToken);
        return car;
    }

    public async Task<List<Car>> GetAllAsync(Expression<Func<Car, bool>> expression = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Car> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();
        return expression != null
            ? await query.Where(expression).ToListAsync(cancellationToken)
            : await query.ToListAsync(cancellationToken);
    }
    
    public async Task<Car> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Car> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(cancellationToken);

    }

    public async Task<bool> IsExistAsync(Expression<Func<Car, bool>> expression, CancellationToken cancellationToken = default)
    {
        IQueryable<Car> query = GetQuery();
        return await query.AnyAsync(cancellationToken);
    }
    private DbSet<Car> GetQuery()
    {
       return _context.Set<Car>();
    }

    private static IQueryable<Car> AddIncludesToQuery(string[] includes, IQueryable<Car> query)
    {
        foreach (string include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}

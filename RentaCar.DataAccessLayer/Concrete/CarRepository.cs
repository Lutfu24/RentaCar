using Core.Utilities.DataAccess.Concrete.EfCore;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Concrete;

public class CarRepository : EfBaseRepository<Car, AppDbContext>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}

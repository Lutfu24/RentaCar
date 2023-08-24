using Core.DataAccess.Concrete.EfCore;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Concrete;

public class ColorRepository : EfBaseRepository<Color, AppDbContext>, IColorRepository
{
    public ColorRepository(AppDbContext context) : base(context)
    {
    }
}

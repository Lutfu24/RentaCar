using Core.DataAccess.Concrete.EfCore;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Concrete;

public class BrandRepository : EfBaseRepository<Brand, AppDbContext>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context)
    {
    }
}

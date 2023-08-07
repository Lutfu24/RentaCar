using Core.Utilities.DataAccess.Concrete.EfCore;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Concrete;

public class ImageRepository : EfBaseRepository<Image, AppDbContext>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }
}

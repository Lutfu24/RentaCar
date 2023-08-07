using Core.Utilities.DataAccess.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Abstract;

public interface IBrandRepository : IRepository<Brand>, IAsyncRepository<Brand>
{
}

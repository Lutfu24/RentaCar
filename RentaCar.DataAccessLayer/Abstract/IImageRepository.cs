using Core.DataAccess.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Abstract;

public interface IImageRepository : IRepository<Image>, IAsyncRepository<Image>
{
}

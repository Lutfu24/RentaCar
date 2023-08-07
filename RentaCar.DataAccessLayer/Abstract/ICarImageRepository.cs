using Core.Utilities.DataAccess.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Abstract;

public interface ICarImageRepository:IRepository<CarImage>,IAsyncRepository<CarImage>
{
}

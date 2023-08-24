using Core.DataAccess.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Abstract;

public interface IColorRepository : IRepository<Color>, IAsyncRepository<Color>
{
}

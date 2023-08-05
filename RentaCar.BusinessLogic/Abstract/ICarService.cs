using RentaCar.Entities.Concrete;

namespace RentaCar.BusinessLogic.Abstract;

public interface ICarService
{
    Task<List<Car>> GetAll();
    Task<Car> GetById(int id);
    Task Add(Car car);
    Task Delete(Car car);
    Task DeleteById(int id);
    Task Update(Car car);
    Task<bool> IsExistById(int id);
}

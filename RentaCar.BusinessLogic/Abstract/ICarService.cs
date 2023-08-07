using RentaCar.Entities.Concrete;
using RentaCar.Entities.Dto.Cars;

namespace RentaCar.BusinessLogic.Abstract;

public interface ICarService
{
    Task<List<CarGetDto>> GetAll();
    Task<CarGetDto> GetById(int id);
    Task Add(CarCreateDto carDto);
    Task Delete(Car car);
    Task DeleteById(int id);
    Task Update(CarUpdateDto carDto);
    Task<bool> IsExistById(int id);
}

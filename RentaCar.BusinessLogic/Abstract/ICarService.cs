using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using RentaCar.Entities.Concrete;
using RentaCar.Entities.Dto.Cars;

namespace RentaCar.BusinessLogic.Abstract;

public interface ICarService
{
    Task<IDataResult<List<CarGetDto>>> GetAll();
    Task<IDataResult<CarGetDto>> GetById(int id);
    Task<IResult> Add(CarCreateDto carDto);
    Task<IResult> Delete(Car car);
    Task<IResult> DeleteById(int id);
    Task<IResult> Update(CarUpdateDto carDto);
    Task<IDataResult<bool>> IsExistById(int id);
}

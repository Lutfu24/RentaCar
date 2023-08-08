using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using RentaCar.BusinessLogic.Abstract;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.Entities.Concrete;
using RentaCar.Entities.Dto.Cars;

namespace RentaCar.BusinessLogic.Concrete;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Add(CarCreateDto carDto)
    {
        Car car = _mapper.Map<Car>(carDto);
        if (car is not null)
        {
            await _carRepository.AddAsync(car);
        }
        return new SuccessResult("Car added");
    }

    public async Task<IResult> Delete(Car car)
    {
        if (car is not null)
        {
            await _carRepository.DeleteAsync(car);
        }
        return new SuccessResult("Car deleted");
    }

    public async Task<IResult> DeleteById(int id)
    {
        IDataResult<CarGetDto> result = await GetById(id);
        Car car = _mapper.Map<Car>(result);
        if (car is not null)
        {
            await _carRepository.DeleteAsync(car);
        }
        return new SuccessResult($"Id: {id} car deleted");
    }

    public async Task<IDataResult<List<CarGetDto>>> GetAll()
    {
        List<Car> cars = await _carRepository.GetAllAsync(includes: new string[] {"Brand", "Color"});
        return new SuccessDataResult<List<CarGetDto>>(_mapper.Map<List<CarGetDto>>(cars),true,"Cars listed");
    }

    public async Task<IDataResult<CarGetDto>> GetById(int id)
    {
        Car car = await _carRepository.GetAsync(c => c.Id == id);
        return new SuccessDataResult<CarGetDto>(_mapper.Map<CarGetDto>(car));
    }

    public async Task<IDataResult<bool>> IsExistById(int id)
    {
        bool result = await _carRepository.IsExistAsync(c => c.Id == id);
        return new SuccessDataResult<bool>(result);
    }

    public async Task<IResult> Update(CarUpdateDto carDto)
    {
        Car existsCar = await _carRepository.GetAsync(c => c.Id == carDto.Id);
        if (existsCar is not null)
        {
            Car car = _mapper.Map(carDto, existsCar);
            await _carRepository.UpdateAsync(car);
        }
        return new SuccessResult("Car updated");
    }
}

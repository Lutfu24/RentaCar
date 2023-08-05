using RentaCar.BusinessLogic.Abstract;
using RentaCar.DataAccessLayer.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.BusinessLogic.Concrete;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task Add(Car car)
    {
        if (car is not null)
        {
            await _carRepository.AddAsync(car);
        }
    }

    public async Task Delete(Car car)
    {
        if (car is not null)
        {
            await _carRepository.DeleteAsync(car);
        }
    }

    public async Task DeleteById(int id)
    {
        Car car = await GetById(id);
        if (car is not null)
        {
            await _carRepository.DeleteAsync(car);
        }
    }

    public async Task<List<Car>> GetAll()
    {
        return await _carRepository.GetAllAsync();
    }

    public async Task<Car> GetById(int id)
    {
        return await _carRepository.GetAsync(c=>c.Id==id);
    }

    public async Task<bool> IsExistById(int id)
    {
        return await _carRepository.IsExistAsync(c=>c.Id==id);
    }

    public async Task Update(Car car)
    {
        if (car is not null)
        {
            await _carRepository.UpdateAsync(car);
        }
    }
}

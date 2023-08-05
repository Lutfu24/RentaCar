using Microsoft.AspNetCore.Mvc;
using RentaCar.BusinessLogic.Abstract;
using RentaCar.Entities.Concrete;
using RentaCar.Entities.Dto.Cars;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> GetAll()
    {
        var result = await _carService.GetAll();
        if (result.Count > 0)
        {
            return Ok();
        }
        return BadRequest();
    }

    public async Task<IActionResult> Add(CarCreateDto carCreateDto)
    {
        Car car = new Car()
        {
            ModelYear = carCreateDto.ModelYear,
            Description = carCreateDto.Description,
            DailyPrice = carCreateDto.DailyPrice,
            BrandId = carCreateDto.BrandId,
            ColorId = carCreateDto.ColorId,
            IsDeleted = false
        };
        await _carService.Add(car);
        return Ok();
    }
}

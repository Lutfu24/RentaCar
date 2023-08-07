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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _carService.GetAll();
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(CarCreateDto carCreateDto)
    {
        await _carService.Add(carCreateDto);
        return Ok();
    }
}

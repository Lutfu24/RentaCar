using Core.Utilities.Entities.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.Entities.Dto.Cars;

public class CarGetDto : IDto
{
    public CarGetDto()
    {
        CarImages = new List<CarImage>();
    }
    public int Id { get; set; }
    public DateTime ModelYear { get; set; } = default!;
    public int DailyPrice { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public List<CarImage> CarImages { get; set; }
}

using Core.Entities.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.Entities.Dto.Cars;

public class CarGetDto : IDto
{
    public int Id { get; set; }
    public DateTime ModelYear { get; set; } = default!;
    public int DailyPrice { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
}

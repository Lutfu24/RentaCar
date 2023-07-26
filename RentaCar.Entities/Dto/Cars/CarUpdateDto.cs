using Core.Utilities.Entities.Abstract;

namespace RentaCar.Entities.Dto.Cars;

public class CarUpdateDto : IDto
{
    public int Id { get; set; }
    public DateTime ModelYear { get; set; } = default!;
    public int DailyPrice { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
}

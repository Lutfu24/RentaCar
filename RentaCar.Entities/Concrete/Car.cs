using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class Car : BaseAuditableEntity
{
    public DateTime ModelYear { get; set; }
    public int DailyPrice { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public List<CarImage> CarImages { get; set; }
}

using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class CarImage : BaseAuditableEntity
{
    public string Name { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public bool IsMain { get; set; }
}

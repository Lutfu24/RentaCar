using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class Image : BaseEntity
{
    public string Name { get; set; }
    public List<CarImage> CarImages { get; set; }
}

using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class Image : BaseEntity
{
    public Image()
    {
        CarImages = new List<CarImage>();
    }
    public string Name { get; set; }
    public List<CarImage> CarImages { get; set; }
}

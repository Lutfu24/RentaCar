using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class Color : BaseEntity
{
    public Color()
    {
        Cars = new List<Car>();
    }
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
}

using RentaCar.Entities.Concrete.Common;

namespace RentaCar.Entities.Concrete;

public class Brand : BaseEntity
{
    public Brand()
    {
        Cars = new List<Car>();
    }
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
}

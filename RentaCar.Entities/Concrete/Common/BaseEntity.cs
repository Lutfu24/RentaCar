using Core.Utilities.Entities.Abstract;

namespace RentaCar.Entities.Concrete.Common;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}

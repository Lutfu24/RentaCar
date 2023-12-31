﻿namespace RentaCar.Entities.Concrete.Common;

public class BaseAuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
}

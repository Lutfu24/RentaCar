using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(p => p.ModelYear).IsRequired(true);
        builder.Property(p => p.Color).IsRequired(true);
        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(500);
    }
}

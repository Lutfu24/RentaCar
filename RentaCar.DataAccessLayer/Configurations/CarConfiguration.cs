using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(c => c.ModelYear).IsRequired(true);
        builder.Property(c => c.Color).IsRequired(true);
        builder.Property(c => c.Description).IsRequired(true).HasMaxLength(500);
        builder.HasOne(c => c.Brand)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.BrandId);

    }
}

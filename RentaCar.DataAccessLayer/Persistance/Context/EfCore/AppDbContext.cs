using Microsoft.EntityFrameworkCore;
using RentaCar.DataAccessLayer.Configurations;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
    {
    }

    public DbSet<Car> Cars { get; set; } = default!;
    public DbSet<Brand> Brands { get; set; } = default!;
    public DbSet<Color> Colors { get; set; } = default!;
    public DbSet<Image> Images { get; set; } = default!;
    public DbSet<CarImage> CarImages { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using RentaCar.DataAccessLayer.Configurations;
using RentaCar.Entities.Concrete;

namespace RentaCar.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

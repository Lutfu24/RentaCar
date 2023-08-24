using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentaCar.DataAccessLayer.Persistance.Interceptors;
using RentaCar.Entities.Concrete;
using System.Reflection;

namespace RentaCar.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseAuditableEntityInterceptor _baseAuditableEntityInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> op, BaseAuditableEntityInterceptor baseAuditableEntityInterceptor) : base(op)
    {
        _baseAuditableEntityInterceptor = baseAuditableEntityInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Image> Images { get; set; }

}

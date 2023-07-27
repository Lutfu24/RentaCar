using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;

namespace RentaCar.DataAccessLayer;

public static class DataAccessConfigurations
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        return services;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentaCar.DataAccessLayer.Persistance.Context.EfCore;
using RentaCar.DataAccessLayer.Persistance.Interceptors;

namespace RentaCar.DataAccessLayer;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddHttpContextAccessor();
        services.AddScoped<BaseAuditableEntityInterceptor>();

        return services;
    }
}

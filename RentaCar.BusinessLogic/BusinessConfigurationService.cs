using Microsoft.Extensions.DependencyInjection;
using RentaCar.BusinessLogic.Abstract;
using RentaCar.BusinessLogic.Concrete;
using System.Reflection;

namespace RentaCar.BusinessLogic;

public static class BusinessConfigurationService
{
    public static IServiceCollection AddBusinessService(this IServiceCollection service)
    {
        service.AddScoped<ICarService, CarService>();
        service.AddAutoMapper(Assembly.GetExecutingAssembly());

        return service;
    }
}

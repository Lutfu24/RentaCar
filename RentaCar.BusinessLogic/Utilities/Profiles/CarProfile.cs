using AutoMapper;
using RentaCar.Entities.Concrete;
using RentaCar.Entities.Dto.Cars;

namespace RentaCar.BusinessLogic.Utilities.Profiles;

public class CarProfile : Profile
{
	public CarProfile()
	{
		CreateMap<CarCreateDto, Car>();
		CreateMap<CarUpdateDto, Car>();
		CreateMap<Car, CarGetDto>().ReverseMap();
	}
}
